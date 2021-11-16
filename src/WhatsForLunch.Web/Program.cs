using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WhatsForLunch.Core;
using WhatsForLunch.Web;
using WhatsForLunch.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<AppState>();
builder.Services.AddSingleton<IChoiceService, ChoiceService>();
builder.Services.AddSingleton<IChoicesRepository, ChoicesRepository>();

await builder.Build().RunAsync();