namespace MauiStudentList.Model
{
    public class Student
    {
        internal string Name { get; set; }
        internal int Kor { get; set; }
        internal string Varos { get; set; }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
