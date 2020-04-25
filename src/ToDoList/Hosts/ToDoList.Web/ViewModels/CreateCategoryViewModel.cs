using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels
{
    public class CreateCategoryViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
