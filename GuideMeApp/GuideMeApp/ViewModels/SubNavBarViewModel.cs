using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GuideMeApp.ViewModels
{
    public partial class SubNavBarViewModel : ObservableObject
    {
        [RelayCommand ]
        async Task Tap(string page)
        {
            if (Shell.Current.CurrentPage.ToString().Contains(page))
                return;

            await Shell.Current.GoToAsync(page);
        }
    }
}
