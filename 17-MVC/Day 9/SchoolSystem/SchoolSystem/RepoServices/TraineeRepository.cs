using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.RepoServices
{
    public interface ITraineeRepository
    {
        IEnumerable<Trainee> GetAll();
        Trainee GetById(int id);
        void Add(Trainee trainee);
        void Update(Trainee trainee);
        void Delete(int id);
    }

    public class TraineeRepository : ITraineeRepository
    {
        public MyDbContext _context { get; }

        public TraineeRepository( MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trainee> GetAll()
        {
            return _context.Trainees.Include(t => t.Track).Include(t => t.TraineeCourses).ToList();
        }

        public Trainee GetById(int id)
        {
            return _context.Trainees.Include(t => t.Track).Include(t => t.TraineeCourses).SingleOrDefault(t => t.ID == id);
        }

        public void Add(Trainee trainee)
        {
            _context.Trainees.Add(trainee);
            _context.SaveChanges();
        }

        public void Update(Trainee trainee)
        {
            _context.Entry(trainee).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var traineeld = GetById(id);

            if (traineeld != null)
            {
                _context.Trainees.Remove(traineeld);
                _context.SaveChanges();
            }
        }
    }
}
