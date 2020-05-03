using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Issue
{
    public class CreateIssueViewModel
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
