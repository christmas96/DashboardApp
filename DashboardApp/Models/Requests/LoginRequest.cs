using Newtonsoft.Json;

namespace DashboardApp.Models.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonProperty("device_name")]
        public string DeviceName { get; set; }
    }
}
