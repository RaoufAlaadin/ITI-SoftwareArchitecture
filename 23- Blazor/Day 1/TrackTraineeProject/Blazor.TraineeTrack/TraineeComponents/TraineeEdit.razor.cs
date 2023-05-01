using Microsoft.AspNetCore.Components;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.TraineeComponents
{
    public partial  class TraineeEdit
    {

        [Parameter]
        public int TraineeId { get; set; }

        public Trainee? CurrentTrainee { get; set; }

        public Track? CurrentTrack { get; set; }

        public bool Saved;


        protected override void OnInitialized()
        {
            Saved = false;

            CurrentTrainee =
                MockContext.Trainees.FirstOrDefault(t => t.Id == TraineeId) ?? new Trainee();

            CurrentTrack =
                MockContext.Tracks.FirstOrDefault(t => t.Id == CurrentTrainee.TrackId) ?? new Track();


            base.OnInitialized();
        }

        protected void HandleValidSubmit()
        {
            var editedEmp = MockContext.Trainees.FirstOrDefault(em => em.Id == TraineeId);
            editedEmp.Name = CurrentTrainee.Name;
            editedEmp.Track = CurrentTrainee.Track;

            Saved = true;
        }

        protected void HandleInvalidSubmit()
        {
            Saved = false;
        }


    }
}
