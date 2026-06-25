using MauiStudentList.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiStudentList.Data
{
    public class AppDbContext : DbContext, IRepo
    {
        public DbSet<Student>? Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var dir = FileSystem.AppDataDirectory;
            var dbPath = Path.Combine(dir, "students.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            //optionsBuilder.UseSqlite($"Data Source={dbPath};Password=ErosJelszo");
        }

        // erre itt nincs szükség
        public Task<List<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
