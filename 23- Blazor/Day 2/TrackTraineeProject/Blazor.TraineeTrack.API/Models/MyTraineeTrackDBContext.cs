using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.API.Models
{
    public class MyTraineeTrackDBContext:DbContext
    {

        public MyTraineeTrackDBContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Track> Tracks { get; set; }


    }
}
