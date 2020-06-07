using System;

namespace ToDoList.Issue.Domain.Entities
{
    public class Issue
    {
        private int? _id;
        public int? Id
        {
            get
            {
                return _id;
            }
        }
        
        public bool IsCompleted { get; private set; }

        public string Name { get; private set; }

        public Issue(string name, bool isCompleted = false)
        {
            ThrowExceptionIfNameIsInvalid(name);

            IsCompleted = isCompleted;
            Name = name;
        }

        public Issue(int? id, string name, bool isCompleted = false)
            : this (name, isCompleted)
        {
            _id = id;
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


        public Issue Clone()
        {
            return new Issue(Id, Name, IsCompleted);
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
