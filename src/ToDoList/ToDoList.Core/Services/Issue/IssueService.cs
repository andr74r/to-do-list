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

        public void CompleteIssue(int issueId)
        {
            var issue = _issueRepository.GetIssue(issueId);

            issue.IsCompleted = true;

            _issueRepository.SaveIssue(issue);
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

        public IEnumerable<IssueDto> GetIssuesByCategoryId(int categoryId)
        {
            var issues = _issueRepository.GetIssuesByCategory(categoryId);

            return issues.Select(x => _mapper.Map<IssueDto>(x));
        }

        public IssueDto UpdateIssue(IssueDto issueDto)
        {
            var issue = _mapper.Map<Data.Entities.Issue>(issueDto);

            _issueRepository.SaveIssue(issue);

            return _mapper.Map<IssueDto>(issue);
        }
    }
}
