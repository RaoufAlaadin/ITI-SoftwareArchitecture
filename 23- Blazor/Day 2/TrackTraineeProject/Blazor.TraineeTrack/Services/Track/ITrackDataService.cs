using SharedLibrary.Models;


namespace Blazor.TraineeTrack
{
    public interface ITrackDataService
    {
        Task<IEnumerable<Track>> GetAllTracks();
        Task<Track> GetTrackDetails(int trackId);
        Task AddTrack(Track track);
        Task UpdateTrack(Track track);
        Task DeleteTrack(int trackId);

    }
}
