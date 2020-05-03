using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Common.Validators;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Data.Repositories;

namespace ToDoList.Issue.Core.Services.Issue
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;
        private readonly IEntityValidator<Data.Entities.Issue> _validator;

        public IssueService(
            IIssueRepository issueRepository,
            IMapper mapper,
            IEntityValidator<Data.Entities.Issue> validator)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
            _validator = validator;
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

            if (!_validator.IsValid(issue))
            {
                throw new ArgumentException("Issue is invalid");
            }

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
