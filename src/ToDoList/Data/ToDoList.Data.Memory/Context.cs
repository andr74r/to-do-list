using System.Collections.Generic;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Memory
{
    internal static class Context
    {
        public static List<Category> Categories { get; set; } = new List<Category>();

        public static List<Issue> Issues { get; set; } = new List<Issue>();
    }
}
