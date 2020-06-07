using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Application.Commands;
using ToDoList.Issue.Core.Infrastructure;
using ToDoList.Issue.Domain.Entities;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Tests.Commands
{
    [TestFixture]
    public class DeleteCategoryCommandHandlerTests
    {
        [Test]
        public async Task Handle_DeletingCategory_ShouldDeleteCategory()
        {
            // Arrange
            var categoryRepositoryMock = GetCategoryRepository();

            var handler = new DeleteCategoryCommandHandler(categoryRepositoryMock.Object);
            var request = new DeleteCategoryCommand
            {
                CategoryId = 1
            };

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            categoryRepositoryMock.Verify(x => x.DeleteCategory(1), Times.Once);
        }

        private Mock<ICategoryRepository> GetCategoryRepository()
        {
            var mock = new Mock<ICategoryRepository>();

            mock.Setup(x => x.GetCategory(1))
                .Returns(new Category(1, "Home"));

            return mock;
        }
    }
}
