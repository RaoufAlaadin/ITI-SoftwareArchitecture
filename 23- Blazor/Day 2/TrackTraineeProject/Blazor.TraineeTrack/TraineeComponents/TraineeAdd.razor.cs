using Microsoft.AspNetCore.Components;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.TraineeComponents
{
    public partial class TraineeAdd
    {

        [Parameter]
        public int TraineeId { get; set; }

        public Trainee CurrentTrainee { get; set; } = new Trainee();

        public Track? CurrentTrack { get; set; }

        public bool Saved;


        protected override void OnInitialized()
        {
            Saved = false;


            base.OnInitialized();
        }

        protected void HandleValidSubmit()
        {
          if(CurrentTrainee == null) return;    

          var newId = MockContext.Trainees.Max(x => x.Id);
            CurrentTrainee.Id = newId + 1 ;
            MockContext.Trainees.Add(CurrentTrainee);

            Saved = true;
        }

        protected void HandleInvalidSubmit()
        {
            Saved = false;
        }

    }
}
