using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.RepoServices
{
    public interface ITraineeCourseRepository
    {
        IEnumerable<TraineeCourse> GetAll();
        TraineeCourse GetById(int traineeId, int courseId);
        void Add(TraineeCourse traineeCourse);
        void Update(TraineeCourse traineeCourse);
        void Delete(int traineeId, int courseId);
    }

    public class TraineeCourseRepository : ITraineeCourseRepository
    {
        public MyDbContext _context { get; }


        public TraineeCourseRepository(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TraineeCourse> GetAll()
        {
            return _context.TraineeCourses.Include(tc => tc.Trainee).Include(tc => tc.Course).ToList();


        }

        public TraineeCourse GetById(int traineeId, int courseId)
        {
            return _context.TraineeCourses.Include(tc => tc.Trainee).Include(tc => tc.Course).SingleOrDefault(tc => tc.TraineeID == traineeId && tc.CourseID == courseId);
        }

        public void Add(TraineeCourse traineeld)
        {
            _context.TraineeCourses.Add(traineeld);
            _context.SaveChanges();
        }

        public void Update(TraineeCourse traineeld)
        {
            _context.Entry(traineeld).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int traineeld, int courseId)
        {
            var _traineeld = GetById(traineeld, courseId);

            if (_traineeld != null)
            {
                _context.TraineeCourses.Remove(_traineeld);
                _context.SaveChanges();
            }
        }
    }
}
