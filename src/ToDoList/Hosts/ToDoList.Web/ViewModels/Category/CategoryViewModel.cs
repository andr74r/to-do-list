using Newtonsoft.Json;
using System.Collections.Generic;
using ToDoList.Web.ViewModels.Issue;

namespace ToDoList.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public List<IssueViewModel> Issues { get; set; }
    }
}
