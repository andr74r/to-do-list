using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels
{
    public class SaveCategoryViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
