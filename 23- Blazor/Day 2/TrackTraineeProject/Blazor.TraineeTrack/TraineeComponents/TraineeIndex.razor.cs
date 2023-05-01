using Microsoft.AspNetCore.Components;
using SharedLibrary.Models;

namespace Blazor.TraineeTrack.TraineeComponents
{
    public partial class TraineeIndex
    {

        IEnumerable<Trainee> AllTrainees;

        [Inject]
        public ITraineeDataService traineeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllTrainees = await traineeDataService.GetAllTrainees();
        }
    }
}
