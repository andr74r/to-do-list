namespace ToDoList.Security.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PasswordHash { get; set; }
    }
}
