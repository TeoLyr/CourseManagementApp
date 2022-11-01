using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        internal string errormessage = "";

        public DeleteModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        public void OnGet()
        {
            CourseDTO courseDTO = new();

            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                courseDTO.Id = id;
                course = service.DeleteCourse(courseDTO);
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