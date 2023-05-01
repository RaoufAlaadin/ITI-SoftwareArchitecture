using SharedLibrary.Models;
using System.Net.Http.Json;

namespace Blazor.TraineeTrack
{
    public class TraineeDataService : ITraineeDataService
    {
        public HttpClient HttpClient { get; }
        public TraineeDataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Trainee>> GetAllTrainees()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Trainee>>("/api/Trainees");
        }

        public async Task<Trainee> GetTraineeDetails(int traineeId)
        {
            return await HttpClient.GetFromJsonAsync<Trainee>("/api/Trainees/" + traineeId);
        }

        public async Task UpdateTrainee(Trainee trainee)
        {
            await HttpClient.PutAsJsonAsync("/api/Trainees/" + trainee.Id, trainee);
        }

        public async Task AddTrainee(Trainee trainee)
        {
            await HttpClient.PostAsJsonAsync<Trainee>("/api/Trainees/", trainee);
        }

        public async Task DeleteTrainee(int trackId)
        {
            await HttpClient.DeleteAsync("/api/Trainees/" + trackId);
        }
    }
}
