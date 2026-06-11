using MauiStudentList.Model;

namespace MauiStudentList
{
    public partial class MainPage : ContentPage
    {
        Student s = new Student();

        public MainPage()
        {
            InitializeComponent();
            Name.Text = "";
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            s.Name = Name.Text;
            //Int32.TryParse(Age.Text, out int age);
            var age = (int)Age.Value;
            s.Kor = age;
            s.Varos = City.Text;
            SaveBtn.Text = "Mentve";
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
