using CommunityToolkit.Mvvm.ComponentModel;
using GuideMeApp.Models;

namespace GuideMeApp.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        UserSetting userSetting;

        [ObservableProperty]
        User user;
    }
}
