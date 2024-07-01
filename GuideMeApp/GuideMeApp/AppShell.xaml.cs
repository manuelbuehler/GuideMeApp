using GuideMeApp.Models;
using GuideMeApp.Views;

namespace GuideMeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TripDetailPage), typeof(TripDetailPage));
        }
    }
}
