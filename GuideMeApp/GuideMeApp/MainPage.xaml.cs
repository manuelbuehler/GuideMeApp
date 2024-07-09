using GuideMeApp.ViewModels;

namespace GuideMeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;


            filter.ItemsSource = new[]
            {
                "Umkreis: 10 km",
                "Ort: Appenzell",
                "Datum: 16.09.24",
                "Sexualität: Männlich"
            };
        }
    }
}
