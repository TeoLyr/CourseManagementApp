using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;

namespace CourseManagementApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        internal string errormessage = "";

        public DeleteModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        public void OnGet()
        {
            StudentDTO studentDTO = new();

            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                studentDTO.Id = id;
                student = service.DeleteStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }
    }
}
