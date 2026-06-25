using MauiStudentList.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiStudentList.Data
{
    public interface IRepo
    {
        DbSet<Model.Student>? Students { get; set; }
        Task<List<Student>> GetAllStudentsAsync();

    }
}
