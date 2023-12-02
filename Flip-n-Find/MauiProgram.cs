using CommunityToolkit.Maui;
using Flip_n_Find.Data;
using Flip_n_Find.Views;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Flip_n_Find
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LevelPage>();
            builder.Services.AddSingleton<ThemePage>();

            builder.Services.AddTransient<EasyPage>();
            builder.Services.AddTransient<MediumPage>();
            builder.Services.AddTransient<HardPage>();
            builder.Services.AddTransient<CongratsPage>();
            builder.Services.AddTransient<ScoreboardPage>();

            // initialise the database path and register a singleton services so the app can use a single instance of RepositoryData class throughout its lifetime.
            string dbPath = FileAccessHelper.GetFileLocalPath("FlipnFind_encrypted.db3");
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<RepositoryData>(s, dbPath));

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}