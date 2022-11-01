using CourseManagementApp.Models;

namespace CourseManagementApp.DAO
{
    public interface ICourseDAO
    {   
        /// <summary>
        /// Takes user added parameters and inserts them into 
        /// the COURSES table in the database. 
        /// </summary>
        /// <param name="course"></param>
        void Insert(Course? course);
        /// <summary>
        /// Takes user added parameters and updates already existing 
        /// values in the COURSES table in the database.
        /// </summary>
        /// <param name="course"></param>
        void Update(Course? course);
        /// <summary>
        /// Deletes a Course object from the COURSES table in the database.
        /// </summary>
        /// <param name="course"></param>
        /// <returns>Returns the deleted Course.</returns>
        Course? Delete(Course? course);
        /// <summary>
        /// Finds a Course object from the COURSES table
        /// in the database, through a given id by the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns that Course object</returns>
        Course? GetCourse(int id);
        /// <summary>
        /// Creates a List with every Course object value from 
        /// the COURSES table in the database.
        /// </summary>
        /// <returns>Returns the created List</returns>
        List<Course> GetAll();
    }
}