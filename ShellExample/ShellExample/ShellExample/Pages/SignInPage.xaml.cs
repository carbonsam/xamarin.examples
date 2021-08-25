using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void SignInButtonOnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{AppRoutes.DashboardPage}");
        }
    }
}
