using MauiStudentList.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiStudentList.Data
{
    internal class SQLiteRepo : IRepo
    {
        public DbSet<Student>? Students { get; set; } // erre itt nincs szükség

        IDbContextFactory<AppDbContext> factory;

        public SQLiteRepo(IDbContextFactory<AppDbContext> factory)
        {
            this.factory = factory;
        }

        async public Task<List<Student>> GetAllStudentsAsync()
        {
            using var db = await factory.CreateDbContextAsync();
            return await (db.Students?.ToListAsync());
        }
    }
}
