using GuideMeApp.Views;

namespace GuideMeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TripDetailPage), typeof(TripDetailPage));
            Routing.RegisterRoute(nameof(NewTripPage), typeof(NewTripPage));
            Routing.RegisterRoute("MyTripsPage", typeof(MyTripsPage));
            Routing.RegisterRoute("NewTripPage", typeof(NewTripPage));
        }
    }
}
