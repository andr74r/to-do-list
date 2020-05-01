using Newtonsoft.Json;

namespace ToDoList.Web.ViewModels
{
    public class UpdateCategoryViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
