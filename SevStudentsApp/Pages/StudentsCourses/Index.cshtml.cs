using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.StudentsCourses
{
    public class IndexModel : PageModel
    {

        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService serviceCourse;

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? serviceStudent;

        internal List<Student> students = new();
        internal List<Course> courses = new();
        internal List<StudentCourse> studentsCourses = new();

        public IndexModel()
        {
            serviceCourse = new CourseServiceImpl(courseDAO);
            serviceStudent = new StudentServiceImpl(studentDAO);
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        public IActionResult OnGet()
        {
            courses = serviceCourse!.GetAllCourses();
            students = serviceStudent!.GetAllStudents();
            studentsCourses = service!.GetAllStudentsCourses();
            return Page();
        }
    }
}
