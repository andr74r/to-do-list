﻿using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Commands
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, IssueDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateIssueCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IssueDto> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetCategory(request.CategoryId);

            if (category == null)
            {
                throw new System.ArgumentException($"Category with id = {request.CategoryId} does not exist");
            }

            var issue = category.AddIssue(request.IssueName);

            _categoryRepository.SaveCategory(category);

            return _mapper.Map<IssueDto>(issue);
        }
    }
}
