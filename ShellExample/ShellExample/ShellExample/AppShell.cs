using System;
using ShellExample.Pages;
using Xamarin.Forms;

namespace ShellExample
{
    public class AppShell : Shell
    {
        public AppShell()
        {
            SetNavBarIsVisible(this, false);
            SetTabBarIsVisible(this, false);
            SetFlyoutItemIsVisible(this, false);

            AddShellItems();
        }

        private void AddShellItems()
        {
            // NOTE: These are root routes and must be navigated to using the "//" prefix
            // in order to reset the navigation stack
            Items.Add(CreateShellItem(AppRoutes.LoadingPage, typeof(LoadingPage), "Loading"));
            Items.Add(CreateShellItem(AppRoutes.SignInPage, typeof(SignInPage), "SignIn"));

            // NOTE: We don't want to reset the entire navigation stack to a settings page
            // so we have to push it to the stack manually (see DashboardProfilePage.xaml.cs)
            // Items.Add(CreateShellItem(AppRoutes.SettingsPage, typeof(SettingsPage), "Settings"));

            Items.Add(new TabBar
            {
                Route = AppRoutes.DashboardPage,
                Items =
                {
                    CreateTabItem(typeof(DashboardHomePage), "Home"),
                    CreateTabItem(typeof(DashboardFeedPage), "Feed"),
                    CreateTabItem(typeof(DashboardProfilePage), "Profile")
                }
            });
        }

        private static ShellItem CreateShellItem(string route, Type type, string title) => new ShellItem
        {
            Title = title,
            Route = route,
            Items =
            {
                new ShellContent
                {
                    Title = title,
                    ContentTemplate = new DataTemplate(type)
                }
            }
        };

        private static Tab CreateTabItem(Type type, string title) => new Tab
        {
            Title = title,
            Items = { new ShellContent { ContentTemplate = new DataTemplate(type), Title = title } }
        };
    }
}
