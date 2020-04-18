using System.Collections.Generic;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Memory
{
    public static class Context
    {
        public static List<Category> Categories { get; set; } = new List<Category>();

        public static List<Issue> Issues { get; set; } = new List<Issue>();

        public static List<User> Users { get; set; } = new List<User>();
    }
}
