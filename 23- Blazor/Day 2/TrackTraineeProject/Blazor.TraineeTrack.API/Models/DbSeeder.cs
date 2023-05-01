using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.API.Models
{
    public static class DbSeeder
    {
        public static void Seed(MyTraineeTrackDBContext context)
        {
            
            // Check if the database already has tracks and trainees
            if (context.Tracks.Any() || context.Trainees.Any())
            {
                return; // Database has already been seeded
            }

            // Add tracks to the database
            var tracks = MockContext.Tracks;
            context.Tracks.AddRange(tracks);
            context.SaveChanges();

            // Add trainees to the database
            var trainees = MockContext.Trainees;

            // this fills in the foreign keys 
            foreach (var trainee in trainees)
            {
                trainee.Track = tracks.Single(t => t.Id == trainee.TrackId);
            }
            context.Trainees.AddRange(trainees);
            context.SaveChanges();
        }
    }
}
