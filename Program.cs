using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UWCApplicationForm;
using UWCApplicationForm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register application services
builder.Services.AddScoped<FormStateService>();
builder.Services.AddScoped<CareerMatchingService>();
builder.Services.AddScoped<CareerGuidanceStateService>();

await builder.Build().RunAsync();
