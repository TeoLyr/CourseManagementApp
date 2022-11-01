using CourseManagementApp.DTO;
using CourseManagementApp.Models;

namespace CourseManagementApp.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void InsertStudent(StudentDTO? dto);
        void UpdateStudent(StudentDTO? dto);
        Student? DeleteStudent(StudentDTO? dto);
        Student? GetStudent(int id);
    }
}
