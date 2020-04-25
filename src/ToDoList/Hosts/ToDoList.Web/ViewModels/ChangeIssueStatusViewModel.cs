using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels
{
    public class ChangeIssueStatusViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }
    }
}
