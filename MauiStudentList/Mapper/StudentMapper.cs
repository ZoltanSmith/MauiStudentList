using MauiStudentList.Model;
using MauiStudentList.ViewModel;

namespace MauiStudentList.Mapper
{
    internal class StudentMapper
    {
        internal StudentViewModel StudentToViewModel(Student student) //FromModel
        {
            return new StudentViewModel()
            {
                Name = student.Name,
                Kor = student.Kor,
                Varos = student.Varos
            };
        }

        internal Student ViewModelToStudent(StudentViewModel svm) //ToModel
        {
            return new Student()
            {
                Name = svm.Name,
                Kor = svm.Kor,
                Varos = svm.Varos
            };
        }
    }
}
