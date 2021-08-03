using CarouselBinding.Core.Models;
using CarouselBinding.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CarouselBinding
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FlowPage(new FlowViewModel(new Flow()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
