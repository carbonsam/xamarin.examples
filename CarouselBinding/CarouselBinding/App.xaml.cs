using System.Collections.ObjectModel;
using CarouselBinding.Core.Models;
using CarouselBinding.Core.ViewModels;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CarouselBinding
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            var flowOrder = new ObservableCollection<FlowStep>
            {
                FlowStep.BlueScreen,
                FlowStep.GreenScreen,
                FlowStep.RedScreen,
                FlowStep.GreenScreen,
                FlowStep.BlueScreen
            };

            MainPage = new FlowPage(new FlowViewModel(new Flow(flowOrder)));
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
