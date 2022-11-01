using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? serviceTeacher;

        internal List<Teacher> teachers = new();

        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
            serviceTeacher = new TeacherServiceImpl(teacherDAO);
        }

        internal CourseDTO courseDTO = new();
        internal string errormessage = "";

        public void OnGet()
        {
            teachers = serviceTeacher!.GetAllTeachers();
        }
        public void OnPost()
        {
            // Get DTO
            courseDTO.Description = Request.Form["description"];
            // Validate DTO
            errormessage = IdValidator.Validate(int.Parse(Request.Form["teacherId"]));
            if (!errormessage.Equals(""))
            {
                OnGet();
                return;
            }

            // Get DTO
            courseDTO.TeacherId = int.Parse(Request.Form["teacherId"]);

            // Validate DTO
            errormessage = LengthValidator.Validate(courseDTO);

            //If Error return
            if (!errormessage.Equals(""))
            {
                OnGet();
                return;
            }

            try
            {
                service.InsertCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }
    }
}