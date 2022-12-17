using AB.Inventory.Application;
using AB.Inventory.Client;
using AB.Inventory.Core.Authentication;
using AB.Inventory.Core.Models;
using AB.Inventory.Infrastructure;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var config = new ABConfig();
builder.Configuration.GetSection("ABConfig").Bind(config, c => c.BindNonPublicProperties = true);

builder.Services.AddSingleton(config);

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddMudServices(configuration =>
    {
        configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
        configuration.SnackbarConfiguration.HideTransitionDuration = 100;
        configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
        configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
        configuration.SnackbarConfiguration.ShowCloseIcon = false;
    })
    .AddBlazoredLocalStorage()
    .AddScoped<BlazorHeroStateProvider>()
    .AddScoped<AuthenticationStateProvider, BlazorHeroStateProvider>()
    ;

builder.Logging.SetMinimumLevel(LogLevel.None);

var app = builder.Build();
await app.RunAsync();