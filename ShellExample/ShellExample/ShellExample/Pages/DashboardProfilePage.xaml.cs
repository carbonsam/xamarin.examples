using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardProfilePage
    {
        public DashboardProfilePage()
        {
            InitializeComponent();
        }

        private async void SettingsButtonOnClicked(object sender, EventArgs e)
        {
            // NOTE: You might think we can do this, but we can't (since we're inside a TabBar)
            // and relative routing is not allowed in that context.
            // await Shell.Current.GoToAsync($"/{AppRoutes.SettingsPage}");

            await Shell.Current.Navigation.PushAsync(new SettingsPage());
        }

        private async void SignOutButtonOnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{AppRoutes.SignInPage}");
        }
    }
}
