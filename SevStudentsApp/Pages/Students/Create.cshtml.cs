using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;
using System.Runtime.CompilerServices;

namespace CourseManagementApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public CreateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errormessage = "";

        public void OnPost()
        {
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errormessage = LengthValidator.Validate(studentDTO);

            if (!errormessage.Equals("")) return;

            try
            {
                service.InsertStudent(studentDTO);
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