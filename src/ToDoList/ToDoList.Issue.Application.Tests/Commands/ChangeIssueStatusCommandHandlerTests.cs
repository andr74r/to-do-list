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
    public class ChangeIssueStatusCommandHandlerTests
    {
        [Test]
        public void Handle_NotFoundCategory_ShouldThrowArgException()
        {
            // Arrange
            var handler = new ChangeIssueStatusCommandHandler(GetCategoryRepository().Object, GetMapper());

            var request = new ChangeIssueStatusCommand
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
        public async Task Handle_ExistingIssue_ShouldSaveChangedIssue()
        {
            // Arrange
            var categoryRepositoryMock = GetCategoryRepository();

            var handler = new ChangeIssueStatusCommandHandler(categoryRepositoryMock.Object, GetMapper());

            var request = new ChangeIssueStatusCommand
            {
                CategoryId = 1,
                IssueName = "Clean up room"
            };

            // Act
            var actual = await handler.Handle(request, CancellationToken.None);

            // Assert
            categoryRepositoryMock.Verify(x => x.SaveCategory(It.IsAny<Category>()), Times.Once);
            Assert.IsTrue(actual.IsCompleted);
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
