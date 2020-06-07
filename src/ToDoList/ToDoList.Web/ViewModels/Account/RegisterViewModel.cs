using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
