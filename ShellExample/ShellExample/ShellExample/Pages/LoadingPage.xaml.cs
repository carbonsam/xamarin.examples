using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellExample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Emulate long startup process
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync($"//{AppRoutes.SignInPage}");
                });
            });
        }
    }
}
