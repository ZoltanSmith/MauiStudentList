using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiStudentList.Model
{
    [Table("students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Range(0,110)]
        public int Kor { get; set; }

        [MinLength(1)]
        [MaxLength(512)]
        public string Varos { get; set; }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
