using CommunityToolkit.Maui.Alerts;
using MauiStudentList.Data;
using MauiStudentList.Model;
using System.Collections.ObjectModel;

namespace MauiStudentList.ViewModel
{
    public class StudentListViewModel : BaseViewModel
    {

        private ObservableCollection<Student> students;
        Student selectedStudent;

        public ObservableCollection<Student> Students
        {
            get => students; set => SetProperty(ref students, value);
        }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                SetProperty(ref selectedStudent, value);

                LoadStudent();
            }
        }

        private void LoadStudent()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (SelectedStudent != null)
                {
                    Snackbar.Make($"{SelectedStudent}").Show();
                    Toast.Make($"{SelectedStudent}").Show();
                    await Shell.Current.GoToAsync(nameof(StudentDetailsPage), new Dictionary<string, object>
                    {
                        { "SelectedStudent", SelectedStudent.Name }, //paraméter lista
                        { "masikParam", 1 }
                    });
                }
            });
            //new MainPage().ShowPageAsync(); //vh így nézett ki WF-on
        }

        //public StudentListViewModel()
        //{
        //    // 1.
        //    var dbStudents = App.db.Students?.ToList();

        //    // 2.
        //    dbStudents = App.ServiceProvider?.GetRequiredService<AppDbContext>().Students?.ToList();
        //    //2.2
        //    dbStudents = App.ServiceProvider?.GetRequiredService<IRepo>().Students?.ToList();

        //    //Students = new(dbStudents ?? []);
        //    //Students.Add(new Student() { Name = "John Doe", Kor = 20, Varos = "New York" });
        //    //Students.Add(new Student() { Name = "Jane Smith", Kor = 22, Varos = "Los Angeles" });
        //    //Students.Add(new Student() { Name = "Alice Johnson", Kor = 19, Varos = "Chicago" });
        //}
        //public StudentListViewModel(AppDbContext db)
        //{
        //    // 3.
        //    var dbStudents = db.Students?.ToList();
        //    Students = new(dbStudents ?? []);
        //}

        // 4.
        public StudentListViewModel(IRepo repo)
        {
            repo.GetAllStudentsAsync().ContinueWith(task =>
            {
                var dbStudents = task.Result;
                Students = new(dbStudents ?? []);
            });
        }
    }
}
