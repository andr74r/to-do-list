namespace ToDoList.Issue.Domain.Entities
{
    public class Issue
    {
        public int? Id { get; private set; }
        
        public bool IsCompleted { get; private set; }

        public string Name { get; private set; }

        public Issue(string name, bool isCompleted = false)
        {
            ThrowExceptionIfNameIsInvalid(name);

            IsCompleted = isCompleted;
            Name = name;
        }

        public void ChangeStatus()
        {
            IsCompleted = !IsCompleted;
        }

        public void SetName(string name)
        {
            ThrowExceptionIfNameIsInvalid(name);

            Name = name;
        }

        private void ThrowExceptionIfNameIsInvalid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Issue name is invalid");
            }
        }
    }
}
