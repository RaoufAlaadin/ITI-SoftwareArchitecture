using Blazor.TraineeTrack;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace Blazor.TraineeTrack
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient<ITraineeDataService, TraineeDataService>(
              client => client.BaseAddress = new Uri("https://localhost:7157")
              );


            builder.Services.AddHttpClient<ITrackDataService, TrackDataService>(
                c => c.BaseAddress = new Uri("https://localhost:7157")
                );

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}