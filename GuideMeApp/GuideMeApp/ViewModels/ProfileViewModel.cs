using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GuideMeApp.Shared.Models;
using GuideMeApp.Shared.Services;
using GuideMeApp.Utils;

namespace GuideMeApp.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        User? user;

        readonly IUserService _userService;
        readonly IPreferencesHelper _preferencesHelper;

        public ProfileViewModel(IUserService userService, IPreferencesHelper preferencesHelper)
        {
            _userService = userService;
            _preferencesHelper = preferencesHelper;
        }

        [RelayCommand]
        async Task Load()
        {
            var userId = _preferencesHelper.GetUserId();
            User = await _userService.GetByIdAsync(userId);
        }

        [RelayCommand]
        async Task EditProfileImage()
        {
            var result = await ImageHelper.ImageFilePicker();

            if (result is null)
                return;

            using (var stream = await result.OpenReadAsync())
            {
                var byteArray = await ImageHelper.StreamToByteArrayAsync(stream);
                User.Image = byteArray;
                await _userService.UpdateAsync(User);
                OnPropertyChanged(nameof(User));
            }
        }
    }
}
