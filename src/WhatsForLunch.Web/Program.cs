using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WhatsForLunch.Core;
using WhatsForLunch.Web.Services;

namespace WhatsForLunch.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<AppState>();
            builder.Services.AddSingleton<IChoiceService, ChoiceService>();
            builder.Services.AddSingleton<IChoicesRepository, ChoicesRepository>();

            builder.Services.AddBaseAddressHttpClient();

            await builder.Build().RunAsync();
        }
    }
}