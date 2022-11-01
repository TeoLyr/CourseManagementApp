using CourseManagementApp.DTO;
using CourseManagementApp.Models;

namespace CourseManagementApp.Service
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        void InsertCourse(CourseDTO? dto);
        void UpdateCourse(CourseDTO? dto);
        Course? DeleteCourse(CourseDTO? dto);
        Course? GetCourse(int id);
    }
}