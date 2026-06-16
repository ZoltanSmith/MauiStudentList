using MauiStudentList.Mapper;
using MauiStudentList.ViewModel;

namespace MauiStudentList.Services
{
    internal class StudentService
    {
        StudentMapper studentMapper = new();
        //db instance

        internal void SaveStudentToDatabase(StudentViewModel svm)
        {
            var student = studentMapper.ViewModelToStudent(svm);
            // save to db
        }
    }
}
