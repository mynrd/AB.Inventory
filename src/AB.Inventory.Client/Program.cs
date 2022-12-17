using AB.Inventory.Application;
using AB.Inventory.Client.Data;
using AB.Inventory.Core.Authentication;
using AB.Inventory.Core.Models;
using AB.Inventory.Infrastructure;
using Blazored.LocalStorage;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

var config = new ABConfig();
builder.Configuration.GetSection("ABConfig").Bind(config, c => c.BindNonPublicProperties = true);
builder.Services.AddSingleton(config);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddMediatR(typeof(AB.Inventory.Application.DependencyInjection).Assembly);

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddBlazoredLocalStorage()
    .AddScoped<BlazorHeroStateProvider>()
    .AddScoped<AuthenticationStateProvider, BlazorHeroStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();