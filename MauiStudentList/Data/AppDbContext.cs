using Microsoft.EntityFrameworkCore;

namespace MauiStudentList.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Model.Student> Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var dir = FileSystem.AppDataDirectory;
            var dbPath = Path.Combine(dir, "students.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            //optionsBuilder.UseSqlite($"Data Source={dbPath};Password=ErosJelszo");
        }
    }
}
