using CourseManagementApp.DAO.DBUtil;
using CourseManagementApp.Models;
using System.Data.SqlClient;

namespace CourseManagementApp.DAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public StudentCourse? Delete(StudentCourse? studentCourse)
        {
            if (studentCourse == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "DELETE FROM STUDENTS_COURSES WHERE STUDENT_ID = @studentId AND COURSE_ID = @courseId";

                using SqlCommand command = new(sql, conn);

                command.Parameters.AddWithValue("@studentId", studentCourse.StudentId);
                command.Parameters.AddWithValue("@courseId", studentCourse.CourseId);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? studentCourse : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentsCourses = new List<StudentCourse>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM STUDENTS_COURSES";

                using SqlCommand command = new(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse studentCourse = new()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)

                    };

                    studentsCourses.Add(studentCourse);
                }
                return studentsCourses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse? GetStudentCourse(int id)
        {
            StudentCourse? studentCourse = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM STUDENTS_COURSES WHERE STUDENT_ID = @id";

                using SqlCommand command = new(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    studentCourse = new StudentCourse()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };
                }
                return studentCourse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(StudentCourse? studentCourse)
        {
            if (studentCourse == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "INSERT INTO STUDENTS_COURSES " +
                    "(STUDENT_ID, COURSE_ID) VALUES" +
                    "(@studentId, @courseId)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@studentId", studentCourse.StudentId);
                command.Parameters.AddWithValue("@courseId", studentCourse.CourseId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
