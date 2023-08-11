using DashboardApp.Models.Requests;
using DashboardApp.Models.Responces;
using System.Threading.Tasks;

namespace DashboardApp.Services.Interfaces
{
    public interface IAPIService
    {
        Task<BaseResponse<LoginResponce>> LoginAsync(LoginRequest loginRequest);
        Task<BaseResponse<SignupResponce>> SignupAsync(SignupRequest signupRequest);
        void SaveToken(string token);
    }
}
