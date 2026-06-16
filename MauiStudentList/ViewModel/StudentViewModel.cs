namespace MauiStudentList.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        private string name;
        private int kor;
        private string varos;

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

    }
}
