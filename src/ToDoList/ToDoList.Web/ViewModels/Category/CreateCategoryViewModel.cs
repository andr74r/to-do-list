using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
