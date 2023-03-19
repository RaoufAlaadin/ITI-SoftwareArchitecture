using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApplication1.Model
{
    public class StudentCourseDBContext: DbContext
    {
        /* 
         * request serivce of type DBContextOptions<StudentCourseDBContext> 
         * So we are using inegration.
         */
        public StudentCourseDBContext(DbContextOptions<StudentCourseDBContext> options):base(options) { 
        
        
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }  
    }
}
