using GuideMeApp.ViewModels;

namespace GuideMeApp.Views;

public partial class NewTripPage : ContentPage
{
	public NewTripPage(NewTripViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}