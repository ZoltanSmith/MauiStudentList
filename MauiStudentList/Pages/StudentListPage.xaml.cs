using MauiStudentList.ViewModel;

namespace MauiStudentList;

public partial class StudentListPage : ContentPage
{
    //StudentListViewModel vm = new();

    public StudentListPage(StudentListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}