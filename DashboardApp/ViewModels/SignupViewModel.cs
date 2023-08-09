using AsyncAwaitBestPractices.MVVM;
using DashboardApp.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashboardApp.ViewModels
{
    public class SignupViewModel : BaseViewModel
    {
        #region Fields
        private string _name;
        private string _surName;
        private string _email;
        private string _login;
        private string _password;
        private string _confirmPassword;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Surname
        {
            get => _surName;
            set => SetProperty(ref _surName, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        #endregion

        public IAsyncCommand SignupCommand { get; }

        public SignupViewModel()
        {
            SignupCommand = new AsyncCommand(Signup);
        }

        private async Task Signup()
        {            
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Surname) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(ConfirmPassword))
            {
                MessagingCenter.Send(this, "Check your inputs!");
                return;
            }

            if(Password != ConfirmPassword)
            {
                MessagingCenter.Send(this, "Passwords are not same!");
                return;
            }

            var newUser = new User
            {
                Password = Password,
                Login = Login,
                Email = Email,
                Name = Name,
                Surname = Surname
            };

            UserService.AddUser(newUser);

            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
