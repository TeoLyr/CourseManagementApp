using CourseManagementApp.Models;
using CourseManagementApp.DTO;

namespace CourseManagementApp.Service
{
    public interface ITeacherService
    {
        List<Teacher> GetAllTeachers();
        void InsertTeacher(TeacherDTO? dto);
        void UpdateTeacher(TeacherDTO? dto);
        Teacher? DeleteTeacher(TeacherDTO? dto);
        Teacher? GetTeacher(int id);
    }
}

