using CourseManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Service;

namespace CourseManagementApp.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        internal string errormessage = "";

        public DeleteModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        public void OnGet()
        {
            TeacherDTO teacherDTO = new();

            try
            {
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacherDTO.Id = id;
                teacher = service.DeleteTeacher(teacherDTO);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }
    }
}
