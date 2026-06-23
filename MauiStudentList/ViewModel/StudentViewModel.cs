using CommunityToolkit.Mvvm.Input;
using MauiStudentList.Model;
using MauiStudentList.Services;
using System.Web;
using System.Windows.Input;

namespace MauiStudentList.ViewModel
{
    public class StudentViewModel : BaseViewModel, IQueryAttributable
    {
        private string name;
        private int kor;
        private string varos;

        StudentService studentService = new();

        public string Name
        {
            get => name; set => SetProperty(ref name, value);
        }
        public int Kor
        {
            get => kor; set => SetProperty(ref kor, value);
        }
        public string Varos
        {
            get => varos; set => SetProperty(ref varos, value);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Name = HttpUtility.UrlDecode(query["SelectedStudent"].ToString());
        }

        private RelayCommand saveCommand;
        public ICommand SaveCommand => saveCommand ??= new RelayCommand(Save);

        private void Save()
        {
            //student.Name = Name.Text;
            ////Int32.TryParse(Age.Text, out int age);
            //var age = (int)Age.Value;
            //student.Kor = age;
            //student.Varos = City.Text;
            studentService.SaveStudentToDatabase(this);
          
        }
    }
}
