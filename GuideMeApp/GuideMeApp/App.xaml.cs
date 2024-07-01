using Microsoft.EntityFrameworkCore;

namespace GuideMeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var optionsBuilder = new DbContextOptionsBuilder<GuideMeContext>();
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GuideMe;Integrated Security=True;");

            //var dbContext = new GuideMeContext(optionsBuilder.Options);

            MainPage = new AppShell();
        }
    }
}
