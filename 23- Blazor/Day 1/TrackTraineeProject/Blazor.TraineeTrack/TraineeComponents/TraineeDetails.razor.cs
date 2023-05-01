using Microsoft.AspNetCore.Components;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.TraineeComponents
{
    public partial class TraineeDetails
    {
        [Parameter]
        public int TraineeId { get; set; }

        public Trainee? CurrentTrainee { get; set; }

        public Track? CurrentTrack { get; set; }

        protected override void OnInitialized()
        {

            CurrentTrainee = 
                MockContext.Trainees.FirstOrDefault(t => t.Id == TraineeId) ?? new Trainee();

            CurrentTrack =
                MockContext.Tracks.FirstOrDefault(t => t.Id == CurrentTrainee.TrackId) ?? new Track();


            base.OnInitialized();
        }
    }
}
