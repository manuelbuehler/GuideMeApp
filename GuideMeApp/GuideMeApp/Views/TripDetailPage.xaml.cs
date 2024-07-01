using GuideMeApp.ViewModels;

namespace GuideMeApp.Views;

public partial class TripDetailPage : ContentPage
{
	public TripDetailPage(TripDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}