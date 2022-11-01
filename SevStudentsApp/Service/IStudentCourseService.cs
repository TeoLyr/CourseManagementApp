using CourseManagementApp.DTO;
using CourseManagementApp.Models;

namespace CourseManagementApp.Service
{
    public interface IStudentCourseService
    {
        List<StudentCourse> GetAllStudentsCourses();
        void InsertStudentCourse(StudentCourseDTO? dto);
        StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);
        StudentCourse? GetStudentCourse(int id);
    }
}
