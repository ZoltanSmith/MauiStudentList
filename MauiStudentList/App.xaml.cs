using MauiStudentList.Data;

namespace MauiStudentList
{
    public partial class App : Application
    {
        // 1. kis programokhoz megfelelő:
        internal static AppDbContext db;

        // 2. közepes és nagyobb programokhoz megfelelő:
        internal static IServiceProvider? ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}