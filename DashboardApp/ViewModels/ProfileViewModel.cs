using AsyncAwaitBestPractices;
using System.Threading.Tasks;

namespace DashboardApp.ViewModels
{
    public  class ProfileViewModel : BaseViewModel
    {
        #region Fields
        private string _name;
        private string _surName;
        private string _email;
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
        #endregion

        public ProfileViewModel()
        {
            LoadUserData().SafeFireAndForget();
        }

        private async Task LoadUserData()
        {
            IsBusy = true;
            await Task.Delay(1000);

            var user = UserService.GetCurrentUser();

            if (user != null)
            {
                Name = user.Name;
                Surname = user.Surname;
                Email = user.Email;
            }

            await Task.Delay(1000);
            IsBusy = false;
        }
    }
}
