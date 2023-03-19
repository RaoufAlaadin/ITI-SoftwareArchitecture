using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }


    /* IMPORTANT NOTE: 
     * [Composite Keys] can be only created using fluent API
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TraineeCourse>()
            .HasKey(tc => new { tc.TraineeID, tc.CourseID });
    }

    public DbSet<Track> Tracks { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<TraineeCourse> TraineeCourses { get; set; }

   
}