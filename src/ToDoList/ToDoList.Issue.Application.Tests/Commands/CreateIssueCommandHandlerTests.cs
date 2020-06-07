using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Application.Commands;
using ToDoList.Issue.Core.Infrastructure;
using ToDoList.Issue.Domain.Entities;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Tests.Commands
{
    [TestFixture]
    public class CreateIssueCommandHandlerTests
    {
        [Test]
        public void Handle_NotFoundCategory_ShouldThrowArgException()
        {
            // Arrange
            var handler = new CreateIssueCommandHandler(GetCategoryRepository().Object, GetMapper());

            var request = new CreateIssueCommand
            {
                CategoryId = 2,
                IssueName = "Clean up room"
            };

            // Act
            var del = new AsyncTestDelegate(() => handler.Handle(request, CancellationToken.None));

            // Assert
            Assert.ThrowsAsync<System.ArgumentException>(del);
        }

        [Test]
        public async Task Handle_NewIssue_ShouldSaveNewIssue()
        {
            // Arrange
            var categoryRepositoryMock = GetCategoryRepository();

            var handler = new CreateIssueCommandHandler(categoryRepositoryMock.Object, GetMapper());

            var request = new CreateIssueCommand
            {
                CategoryId = 1,
                IssueName = "Clean out room"
            };

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            categoryRepositoryMock.Verify(x => x.SaveCategory(It.IsAny<Category>()), Times.Once);
        }

        private Mock<ICategoryRepository> GetCategoryRepository()
        {
            var mock = new Mock<ICategoryRepository>();

            var issue = new Domain.Entities.Issue("Clean up room");

            mock.Setup(x => x.GetCategory(1))
                .Returns(new Category(1, "Home", new List<Domain.Entities.Issue> { issue }));

            return mock;
        }

        private IMapper GetMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                AutoMapperIssueModule.Register(cfg);
            }));
        }
    }
}
