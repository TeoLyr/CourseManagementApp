using CourseManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;

namespace CourseManagementApp.Pages.Teachers
{
    public class UpdateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService serviceCourse;

        internal List<Course> courses = new();

        public UpdateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
            serviceCourse = new CourseServiceImpl(courseDAO);
        }

        internal TeacherDTO teacherDTO = new();
        internal string errormessage = "";
        public void OnGet()
        {
            courses = serviceCourse!.GetAllCourses();
            try
            {
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacher = service.GetTeacher(id);

                if (teacher != null)
                {
                    teacherDTO = ConvertToDTO(teacher);
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

            teacherDTO.Id = int.Parse(Request.Form["id"]);
            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            errormessage = LengthValidator.Validate(teacherDTO);

            if (!errormessage.Equals("")) return;

            try
            {
                service.UpdateTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }

        private TeacherDTO ConvertToDTO(Teacher teacher)
        {
            return new TeacherDTO()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            };
        }
    }
}
