using CourseManagementApp.DTO;

namespace CourseManagementApp.Validator
{
    public class IdValidator
    {
        public static string Validate(int id)
        {
            if (id == 0)
            {
                return "You must choose a teacher!";
            }

            return "";
        }

        public static string Validate(StudentCourseDTO? dto)
        {
            if (dto!.StudentId == 0)
            {
                return "You must choose a student!";
            }
            if (dto!.CourseId == 0)
            {
                return "You must choose a course!";
            }

            return "";
        }
    }
}