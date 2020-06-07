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
    public class DeleteIssueCommandHandlerTests
    {
        [Test]
        public void Handle_NotFoundCategory_ShouldThrowArgException()
        {
            // Arrange
            var handler = new DeleteIssueCommandHandler(GetCategoryRepository().Object);

            var request = new DeleteIssueCommand
            {
                CategoryId = 2
            };

            // Act
            var del = new AsyncTestDelegate(() => handler.Handle(request, CancellationToken.None));

            // Assert
            Assert.ThrowsAsync<System.ArgumentException>(del);
        }

        [Test]
        public async Task Handle_DeletingIssue_ShouldSaveNewIssue()
        {
            // Arrange
            var categoryRepositoryMock = GetCategoryRepository();

            var handler = new DeleteIssueCommandHandler(categoryRepositoryMock.Object);

            var request = new DeleteIssueCommand
            {
                CategoryId = 1,
                IssueName = "Clean up room"
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
    }
}
