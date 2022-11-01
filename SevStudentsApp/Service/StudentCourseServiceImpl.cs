using CourseManagementApp.DAO;
using CourseManagementApp.DTO;
using CourseManagementApp.Models;

namespace CourseManagementApp.Service
{
    public class StudentCourseServiceImpl : IStudentCourseService
    {
        private readonly IStudentCourseDAO dao;

        public StudentCourseServiceImpl(IStudentCourseDAO dao)
        {
            this.dao = dao;
        }

        public StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                StudentCourse? studentCourse = Convert(dto);
                return dao.Delete(studentCourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<StudentCourse> GetAllStudentsCourses()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse>();
            }
        }

        public StudentCourse? GetStudentCourse(int id)
        {
            try
            {
                return dao.GetStudentCourse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudentCourse(StudentCourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                StudentCourse? studentCourse = Convert(dto);
                dao.Insert(studentCourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private StudentCourse? Convert(StudentCourseDTO dto)
        {
            if (dto == null) return null;

            return new StudentCourse()
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };
        }
    }
}
