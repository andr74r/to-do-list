using System.Collections.Generic;
using ToDoList.Issue.Domain.Entities;

namespace ToDoList.Issue.Infrastructure.InMemory
{
    internal static class Context
    {
        public static List<Category> Categories { get; set; } = new List<Category>();
    }
}
