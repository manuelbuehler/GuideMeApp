using GuideMeApp.Utils;

namespace GuideMeApp
{
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicense.Register();
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
