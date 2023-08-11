using DashboardApp.Models.Requests;
using DashboardApp.Models.Responces;
using DashboardApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DashboardApp.Services
{
    public class APIService : IAPIService
    {
        const string BaseAddress = "45.33.108.149";

        private HttpClient _httpClient;

        public APIService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public void SaveToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<BaseResponse<LoginResponce>> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/login", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseBody))
                {
                    var successResponse = JsonConvert.DeserializeObject<BaseResponse<LoginResponce>>(responseBody);
                    return successResponse;
                }
            }
            catch (Exception ex)
            {
                return default;
            }

            return default;
        }

        public async Task<BaseResponse<SignupResponce>> SignupAsync(SignupRequest signupRequest)
        {
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(signupRequest), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/signup", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseBody))
                {
                    var successResponse = JsonConvert.DeserializeObject<BaseResponse<SignupResponce>>(responseBody);
                    return successResponse;
                }
            }
            catch (Exception ex)
            {
                return default;
            }

            return default;
        }
    }
}
