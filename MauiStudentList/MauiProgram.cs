using CommunityToolkit.Maui;
using MauiStudentList.Data;
using MauiStudentList.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiStudentList
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options => options.SetShouldEnableSnackbarOnWindows(true))
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // 1.
            builder.Services.AddDbContext<AppDbContext>();

            // 3. Dependency Injection (ha szükségünk van rá, akkor létrehozza)
            //builder.Services.AddSingleton<IRepo, SQLiteRepo>(); // egy példányt hoz létre, és azt használja mindenhol // pl prefenrences
            builder.Services.AddTransient<IRepo, SQLiteRepo>(); // minden alkalommal új példányt hoz létre, amikor szükség van rá // pl student object
            builder.Services.AddTransient<StudentListViewModel>();
            builder.Services.AddSingleton<StudentListPage>();
            builder.Services.AddTransient<StudentViewModel>();

            // 4. db factory
            builder.Services.AddDbContextFactory<AppDbContext>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            Seeder.Seed(db);

            // 1.
            App.db = db;

            // 2.
            App.ServiceProvider = app.Services;

            return app;
        }
    }
}
