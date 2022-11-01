using CourseManagementApp.DAO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? serviceTeacher;

        internal List<Teacher> teachers = new();
        internal List<Course> courses = new();

        public IndexModel()
        {
            service = new CourseServiceImpl(courseDAO);
            serviceTeacher = new TeacherServiceImpl(teacherDAO);
        }

        public IActionResult OnGet()
        {
            courses = service!.GetAllCourses();
            teachers = serviceTeacher!.GetAllTeachers();
            return Page();
        }
    }
}