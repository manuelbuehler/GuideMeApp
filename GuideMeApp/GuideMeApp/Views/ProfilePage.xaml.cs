using GuideMeApp.ViewModels;

namespace GuideMeApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}