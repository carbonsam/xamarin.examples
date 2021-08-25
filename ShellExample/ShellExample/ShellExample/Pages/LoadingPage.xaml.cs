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

        protected override async void OnAppearing()
        {
            // Emulate long startup process
            await Task.Delay(5000);
            await Shell.Current.GoToAsync($"//{AppRoutes.SignInPage}");
        }
    }
}
