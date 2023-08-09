using AsyncAwaitBestPractices.MVVM;
using DashboardApp.Services.Interfaces;
using DashboardApp.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DashboardApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private string _login;
        private string _password;
        private bool _loginError;
        #endregion

        #region Properties
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

        public bool LoginError
        {
            get => _loginError;
            set => SetProperty(ref _loginError, value);
        }
        #endregion

        public Command LoginCommand { get; }
        public IAsyncCommand SignupCommand { get; }
        public Command CloseErrorCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
            SignupCommand = new AsyncCommand(OnSignup);
            CloseErrorCommand = new Command(() => LoginError = false);
        }

        private async Task OnSignup()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignupPage());
        }

        private void OnLogin()
        {
            try
            {
                var exists = UserService.CheckIfExists(Login, Password);

                if (exists)
                {
                    App.Current.MainPage = new AppShell();
                }
                else
                {
                    LoginError = true;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
