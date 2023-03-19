using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.RepoServices
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
    }

    public class CourseRepository : ICourseRepository
    {
        public  MyDbContext _context { get; }

        public CourseRepository( MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(c => c.TraineeCourses).ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Include(c => c.TraineeCourses).SingleOrDefault(c => c.ID == id);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
