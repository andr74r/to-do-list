using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Account
{
    public class UserViewModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("isLoggedIn")]
        public bool IsLoggedIn { get; set; }
    }
}
