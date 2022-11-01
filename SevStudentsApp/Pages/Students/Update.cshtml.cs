using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;

namespace CourseManagementApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService serviceCourse;

        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService serviceStudentCourse;

        internal List<Course> courses = new();
        internal List<StudentCourse> studentsCourses = new();

        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
            serviceCourse = new CourseServiceImpl(courseDAO);
            serviceStudentCourse = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errormessage = "";
        public void OnGet()
        {
            courses = serviceCourse!.GetAllCourses();
            studentsCourses = serviceStudentCourse!.GetAllStudentsCourses();
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service.GetStudent(id);

                if (student != null)
                {
                    studentDTO = ConvertToDTO(student);
                }
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errormessage = "";

            studentDTO.Id = int.Parse(Request.Form["id"]);
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errormessage = LengthValidator.Validate(studentDTO);

            if (!errormessage.Equals(""))
            {
                OnGet();
                return;
            }

            try
            {
                service.UpdateStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }

        private StudentDTO ConvertToDTO(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }
}
