using System.Collections.Generic;
using ToDoList.Issue.Data.Entities;

namespace ToDoList.Issue.Data.Memory
{
    internal static class Context
    {
        public static List<Category> Categories { get; set; } = new List<Category>();

        public static List<Entities.Issue> Issues { get; set; } = new List<Entities.Issue>();
    }
}
