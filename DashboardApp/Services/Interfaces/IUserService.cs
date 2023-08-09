using DashboardApp.Models;

namespace DashboardApp.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);

        User GetCurrentUser();

        bool CheckIfExists(string login, string pass);
    }
}
