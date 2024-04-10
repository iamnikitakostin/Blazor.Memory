using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorCardGame.Client
{
    internal class Program
    {
        static async Task Main (string[] args)
        {
            var url = new Uri("https://localhost:7151/");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = url }); ;
            await builder.Build().RunAsync();

        }
    }
}
