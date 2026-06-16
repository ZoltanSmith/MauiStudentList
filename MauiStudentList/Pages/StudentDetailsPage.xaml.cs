using MauiStudentList.Model;
using MauiStudentList.Services;
using MauiStudentList.ViewModel;

namespace MauiStudentList
{
    public partial class MainPage : ContentPage
    {
        //Student student = new();
        StudentViewModel studentVm = new();
        StudentService studentService = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = studentVm; //itt kapcsolódik a ViewModel objektum a View-hoz
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            //student.Name = Name.Text;
            ////Int32.TryParse(Age.Text, out int age);
            //var age = (int)Age.Value;
            //student.Kor = age;
            //student.Varos = City.Text;
            studentService.SaveStudentToDatabase(studentVm);
            SaveBtn.Text = "Mentve";
            
        }
        private void ModBtn_Clicked(object sender, EventArgs e)
        {
            studentVm.Name = "teszt";
            studentVm.Kor = 99;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            DriverLicenceCb.IsChecked = !DriverLicenceCb.IsChecked;
        }

        private void TapGestureRecognizer_City_Tapped(object sender, TappedEventArgs e)
        {
            City.Text = "Budapest";
        }
    }
}
