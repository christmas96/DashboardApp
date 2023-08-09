using DashboardApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashboardApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = DependencyService.Resolve<LoginViewModel>();
        }
    }
}