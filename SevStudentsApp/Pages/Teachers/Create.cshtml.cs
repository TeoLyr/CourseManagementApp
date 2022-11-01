using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;
using System.Runtime.CompilerServices;

namespace CourseManagementApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        public CreateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDTO = new();
        internal string errormessage = "";

        public void OnPost()
        {
            teacherDTO.Firstname = Request.Form["firstname"];
            teacherDTO.Lastname = Request.Form["lastname"];

            errormessage = LengthValidator.Validate(teacherDTO);

            if (!errormessage.Equals("")) return;

            try
            {
                service.InsertTeacher(teacherDTO);
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
