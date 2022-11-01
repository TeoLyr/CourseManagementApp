using CourseManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Service;
using global::System.Linq;

namespace CourseManagementApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();

        public IndexModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        public IActionResult OnGet()
        {
            teachers = service!.GetAllTeachers();       
            return Page();
        }
    }
}
