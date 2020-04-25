using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Dto;
using ToDoList.Data.Repositories.IssueRepository;

namespace ToDoList.Core.Services.Issue
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public IssueService(
            IIssueRepository issueRepository,
            IMapper mapper)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public IssueDto ChangeIssueStatus(int id, bool status)
        {
            var issue = _issueRepository.GetIssue(id);

            issue.IsCompleted = status;

            _issueRepository.SaveIssue(issue);

            return _mapper.Map<IssueDto>(issue);
        }

        public IssueDto CreateIssue(string name, int categoryId)
        {
            var issue = new Data.Entities.Issue
            {
                CategoryId = categoryId,
                Name = name
            };

            _issueRepository.SaveIssue(issue);

            return _mapper.Map<IssueDto>(issue);
        }

        public void DeleteIssue(int id)
        {
            _issueRepository.DeleteIssue(id);
        }

        public IEnumerable<IssueDto> GetIssuesByCategoryId(int categoryId)
        {
            var issues = _issueRepository.GetIssuesByCategory(categoryId);

            return issues.Select(x => _mapper.Map<IssueDto>(x));
        }
    }
}
