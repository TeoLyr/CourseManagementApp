using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.StudentsCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService service;

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? serviceStudent;

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? serviceCourse;

        internal List<Course> courses = new();
        internal List<Student> students = new();

        public CreateModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
            serviceStudent = new StudentServiceImpl(studentDAO);
            serviceCourse = new CourseServiceImpl(courseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        internal string errormessage = "";

        public void OnGet()
        {
            students = serviceStudent!.GetAllStudents();
            courses = serviceCourse!.GetAllCourses();
        }
        public void OnPost()
        {
            studentCourseDTO.StudentId = int.Parse(Request.Form["studentId"]);
            studentCourseDTO.CourseId = int.Parse(Request.Form["courseId"]);

            errormessage = IdValidator.Validate(studentCourseDTO);
            if (!errormessage.Equals(""))
            {
                OnGet();
                return;
            }

            try
            {
                service.InsertStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentsCourses/Index");
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Cannot insert duplicate key in object 'dbo.STUDENTS_COURSES'")){
                    errormessage = "This student is already assigned to this course.";
                    OnGet();
                }
                else
                {
                    errormessage = e.Message;
                }
                return;
            }
        }
    }
}
