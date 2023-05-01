using SharedLibrary.Models;
using System.Net.Http.Json;

namespace Blazor.TraineeTrack
{
    public class TrackDataService : ITrackDataService
    {
        public HttpClient HttpClient { get; }
        public TrackDataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Track>> GetAllTracks()
        {
            return await HttpClient.GetFromJsonAsync<IEnumerable<Track>>("/api/Tracks");
        }

        public async Task<Track> GetTrackDetails(int trackId)
        {
            return await HttpClient.GetFromJsonAsync<Track>("/api/Tracks/" + trackId);
        }

        public async Task UpdateTrack(Track track)
        {
            await HttpClient.PutAsJsonAsync("/api/Tracks/" + track.Id, track);
        }

        public async Task AddTrack(Track track)
        {
            await HttpClient.PostAsJsonAsync<Track>("/api/Tracks/", track);
        }

        public async Task DeleteTrack(int trackId)
        {
            await HttpClient.DeleteAsync("/api/Tracks/" + trackId);
        }
    }
}
