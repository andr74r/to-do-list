namespace ToDoList.Issue.Data.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        
        public int CategoryId { get; set; }

        public bool IsCompleted { get; set; }

        public string Name { get; set; }
    }
}
