using DashboardApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashboardApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            this.BindingContext = DependencyService.Resolve<ProfileViewModel>();
        }
    }
}