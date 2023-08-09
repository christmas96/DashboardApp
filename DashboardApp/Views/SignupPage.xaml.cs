using DashboardApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DashboardApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            this.BindingContext = DependencyService.Resolve<SignupViewModel>();

            MessagingCenter.Subscribe<SignupViewModel>(this, "Check your inputs!", async _ =>
            {
                await DisplayAlert("Warning", "Check your inputs!", "Okay");
            });

            MessagingCenter.Subscribe<SignupViewModel>(this, "Passwords are not same!", async _ =>
            {
                await DisplayAlert("Warning", "Passwords are not same!", "Okay");
            });
        }
    }
}