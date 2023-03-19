using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.RepoServices
{
    public interface ITrackRepository
    {
        IEnumerable<Track> GetAll();
        Track GetById(int id);
        void Add(Track track);
        void Update(Track track);
        void Delete(int id);
    }

    public class TrackRepository : ITrackRepository
    {
        public MyDbContext _context {get;}

     
        public TrackRepository( MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Track> GetAll()
        {
            return _context.Tracks.Include(t => t.Trainees).ToList();
        }

        public Track GetById(int id)
        {
            return _context.Tracks.Include(t => t.Trainees).SingleOrDefault(t => t.ID == id);
        }

        public void Add(Track track)
        {
            _context.Tracks.Add(track);
            _context.SaveChanges();
        }

        public void Update(Track track)
        {
            /* This updates by getting the exact object that is being tracked and change each of
             * it's values
             * 
             * Student stdUpdated = Context.Students.Find(id);

            stdUpdated.Name = std.Name;
            stdUpdated.Age = std.Age;
            stdUpdated.Email = std.Email;
            stdUpdated.IsActive = std.IsActive;
            stdUpdated.Password = std.Password;
            stdUpdated.DeptId = std.DeptId;

            Context.SaveChanges();*/



            /* There is also this option. 
            _context.Entry(track).State = EntityState.Modified;
             * 
             * */
            // passing a reference to the object in the local context 
            _context.Update(track);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var track = GetById(id);

            if (track != null)
            {
                _context.Tracks.Remove(track);
                _context.SaveChanges();
            }
        }
    }
}
