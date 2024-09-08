using Android.App;
using Android.OS;
using CommunityToolkit.Maui;
using FiveLetters.CustomRenders;
using FiveLetters.Helpers;
using FiveLetters.Services;
using FiveLetters.ViewModel;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.LifecycleEvents;

namespace FiveLetters;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseMauiCompatibility().ConfigureMauiHandlers(handlers =>
        {
        }).ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        }).UseMauiCommunityToolkit();


        builder.Services.AddScoped<WordService>();
        builder.Services.AddScoped<UserStatsService>();

        builder.Services.AddScoped<GameViewModel>();
        builder.Services.AddScoped<HelpPageModel>();

        builder.Services.AddScoped<MainPage>();
        builder.Services.AddScoped<HelpPage>();
        return builder.Build();
    }

}

