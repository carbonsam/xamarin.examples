using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardHomePage
    {
        private bool hasModalBeenPresented;
        
        public DashboardHomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (hasModalBeenPresented)
            {
                return;
            }
            hasModalBeenPresented = true;
            
            // NOTE: Can we navigate to a modal from a TabItem? NOPE
            // await Shell.Current.GoToAsync($"{AppRoutes.HelloPage}");
            
            await Shell.Current.Navigation.PushAsync(new HelloPage());
        }
    }
}
