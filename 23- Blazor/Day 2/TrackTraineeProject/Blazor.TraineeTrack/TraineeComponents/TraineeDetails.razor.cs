using Microsoft.AspNetCore.Components;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.TraineeComponents
{
    public partial class TraineeDetails
    {
        [Parameter]
        public int TraineeId { get; set; }

        [Inject]
        public ITraineeDataService traineeDataservice { get; set; }

        [Inject]
        public ITrackDataService trackDataservice { get; set; }
        public Trainee? CurrentTrainee { get; set; }

        public Track? CurrentTrack { get; set; }

        protected async override void OnInitialized()
        {
            CurrentTrainee = await traineeDataservice.GetTraineeDetails(TraineeId);

            CurrentTrack =
                await trackDataservice.GetTrackDetails(CurrentTrainee.TrackId);

        }
    }
}
