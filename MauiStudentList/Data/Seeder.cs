namespace MauiStudentList.Data
{
    internal class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Model.Student>
                {
                    new() { Name = "John Doe", Kor = 20, Varos = "New York" },
                    new Model.Student { Name = "Jane Smith", Kor = 22, Varos = "Los Angeles" },
                    new Model.Student { Name = "Alice Johnson", Kor = 19, Varos = "Chicago" }
                };
                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }
    }
}
