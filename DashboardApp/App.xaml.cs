using DashboardApp.Services;
using DashboardApp.Services.Interfaces;
using DashboardApp.ViewModels;
using DashboardApp.Views;
using Xamarin.Forms;

namespace DashboardApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IUserService, UserService>();

            DependencyService.Register<LoginViewModel>();
            DependencyService.Register<SignupViewModel>();
            DependencyService.Register<DashboardViewModel>();
            DependencyService.Register<ProfileViewModel>();

            MainPage = new NavigationPage(new LoginPage());
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
