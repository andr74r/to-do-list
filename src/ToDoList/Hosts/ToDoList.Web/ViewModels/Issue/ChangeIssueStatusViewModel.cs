using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Issue
{
    public class ChangeIssueStatusViewModel
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("issueName")]
        public string IssueName { get; set; }
    }
}
