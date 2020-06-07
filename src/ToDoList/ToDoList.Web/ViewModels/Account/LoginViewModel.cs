using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
