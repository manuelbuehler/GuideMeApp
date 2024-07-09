using CommunityToolkit.Mvvm.ComponentModel;
using GuideMeApp.Models;


namespace GuideMeApp.ViewModels
{
    [QueryProperty(nameof(Models.Trip), "Trip")]
    public partial class NewTripViewModel : ObservableObject
    {
        [ObservableProperty]
        Trip trip;
    }
}
