using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.StudentsCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService service;

        internal string errormessage = "";

        public DeleteModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        public void OnGet()
        {
            StudentCourseDTO studentCourseDTO = new();

            try
            {
                StudentCourse? studentCourse;

                studentCourseDTO.StudentId = int.Parse(Request.Query["studentId"]);
                studentCourseDTO.CourseId = int.Parse(Request.Query["courseId"]);

                studentCourse = service.DeleteStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentsCourses/Index");

            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }
    }
}
