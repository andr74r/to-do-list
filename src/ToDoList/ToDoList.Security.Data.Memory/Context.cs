using System.Collections.Generic;
using ToDoList.Security.Data.Entities;

namespace ToDoList.Security.Data.Memory
{
    internal static class Context
    {
        public static List<User> Users { get; set; } = new List<User>();
    }
}
