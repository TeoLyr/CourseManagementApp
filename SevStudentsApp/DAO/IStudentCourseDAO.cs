using CourseManagementApp.Models;

namespace CourseManagementApp.DAO
{
    public interface IStudentCourseDAO
    {
        void Insert(StudentCourse? studentCourse);
        StudentCourse? Delete(StudentCourse? studentCourse);
        StudentCourse? GetStudentCourse(int id);
        List<StudentCourse> GetAll();
    }
}
