using CourseManagementApp.DTO;

namespace CourseManagementApp.Validator
{
    public class LengthValidator
    {
        private LengthValidator() { }

        public static string Validate(StudentDTO? dto)
        {
            if ((dto!.Firstname!.Length < 3) || (dto!.Lastname!.Length < 3) || (dto!.Firstname!.Length > 50) || (dto!.Lastname!.Length > 50))
            {
                return "Name fields should be between 3 and 50 characters.";
            }

            return "";
        }

        public static string Validate(TeacherDTO? dto)
        {
            if ((dto!.Firstname!.Length < 3) || (dto!.Lastname!.Length < 3) || (dto!.Firstname!.Length > 50) || (dto!.Lastname!.Length > 50))
            {
                return "Name fields should be between 3 and 50 characters.";
            }

            return "";
        }

        public static string Validate(CourseDTO? dto)
        {
            if ((dto!.Description!.Length < 4) || (dto!.Description!.Length > 100))
            {
                return "Description should be between 4 and 100 characters.";
            }

            return "";
        }
    }
}