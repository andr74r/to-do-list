using System.Collections.Generic;

namespace ToDoList.Issue.Core.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<IssueDto> Issues { get; set; }
    }
}
