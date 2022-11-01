using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;
using CourseManagementApp.Service;
using CourseManagementApp.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManagementApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? serviceTeacher;

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService? serviceStudent;

        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService serviceStudentCourse;

        internal List<Teacher> teachers = new();
        internal List<Student> students = new();
        internal List<StudentCourse> studentsCourses = new();

        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
            serviceTeacher = new TeacherServiceImpl(teacherDAO);
            serviceStudentCourse = new StudentCourseServiceImpl(studentCourseDAO);
            serviceStudent = new StudentServiceImpl(studentDAO);
        }

        internal CourseDTO courseDTO = new();
        internal TeacherDTO teacherDTO = new();
        internal string errormessage = "";
        public void OnGet()
        {
            teachers = serviceTeacher!.GetAllTeachers();
            students = serviceStudent!.GetAllStudents();
            studentsCourses = serviceStudentCourse!.GetAllStudentsCourses();
            try
            {
                Course? course;
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                course = service.GetCourse(id);

                int teacherId = course!.TeacherId;
                teacher = serviceTeacher.GetTeacher(teacherId);

                if (course != null)
                {
                    courseDTO = ConvertToDTO(course);
                    teacherDTO = ConvertToDTO(teacher!);
                }
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errormessage = "";

            courseDTO.Id = int.Parse(Request.Form["id"]);
            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherId"]);

            errormessage = LengthValidator.Validate(courseDTO);

            if (!errormessage.Equals(""))
            {
                OnGet();
                return;
            }

            try
            {
                service.UpdateCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errormessage = e.Message;
                return;
            }
        }

        private CourseDTO ConvertToDTO(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                Description = course.Description,
                TeacherId = course.TeacherId
            };
        }

        private TeacherDTO ConvertToDTO(Teacher teacher)
        {
            return new TeacherDTO()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            };
        }
    }
}