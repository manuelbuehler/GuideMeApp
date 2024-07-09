using GuideMeApp.ViewModels;

namespace GuideMeApp.Views;

public partial class MyTripsPage : ContentPage
{
	public MyTripsPage(MyTripsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}