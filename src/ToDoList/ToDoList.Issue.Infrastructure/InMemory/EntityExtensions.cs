using System.Reflection;

namespace ToDoList.Issue.Infrastructure.InMemory
{
    public static class EntityExtensions
    {
        public static void SetId(this object obj, int id)
        {
            var prop = obj.GetType().GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance);
            prop.SetValue(obj, id);
        }
    }
}
