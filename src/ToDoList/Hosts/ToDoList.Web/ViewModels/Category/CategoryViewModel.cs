using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels.Category
{
    public class CategoryViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
