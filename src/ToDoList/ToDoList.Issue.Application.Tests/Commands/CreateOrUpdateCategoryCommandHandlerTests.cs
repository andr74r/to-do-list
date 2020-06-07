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
    public class CreateOrUpdateCategoryCommandHandlerTests
    {
        [Test]
        public void Handle_RequestHasCategoryIdAndCategoryIdNotFound_ShouldThrowArgException()
        {
            // Arrange
            var handler = new CreateOrUpdateCategoryCommandHandler(GetCategoryRepository().Object, GetMapper());
            var request = new CreateOrUpdateCategoryCommand
            {
                Id = 2
            };

            // Act
            var del = new AsyncTestDelegate(() => handler.Handle(request, CancellationToken.None));

            // Assert
            Assert.ThrowsAsync<System.ArgumentException>(del);
        }


        [Test]
        public async Task Handle_RequestHasCategoryId_ShouldUpdateCategory()
        {
            // Arrange
            var categoryRepositoryMock = GetCategoryRepository();

            var handler = new CreateOrUpdateCategoryCommandHandler(categoryRepositoryMock.Object, GetMapper());
            var request = new CreateOrUpdateCategoryCommand
            {
                Id = 1,
                Name = "Work",
                UserId = 1
            };

            // Act
            var actual = await handler.Handle(request, CancellationToken.None);

            // Assert
            categoryRepositoryMock.Verify(x => x.SaveCategory(It.IsAny<Category>()), Times.Once);
            Assert.AreEqual("Work", actual.Name);
        }

        [Test]
        public async Task Handle_NewCategory_ShouldCreateCategory()
        {
            // Arrange
            var categoryRepositoryMock = GetCategoryRepository();

            var handler = new CreateOrUpdateCategoryCommandHandler(categoryRepositoryMock.Object, GetMapper());
            var request = new CreateOrUpdateCategoryCommand
            {
                Name = "Work",
                UserId = 1
            };

            // Act
            var actual = await handler.Handle(request, CancellationToken.None);

            // Assert
            categoryRepositoryMock.Verify(x => x.SaveCategory(It.IsAny<Category>()), Times.Once);
            Assert.AreEqual("Work", actual.Name);
        }

        private Mock<ICategoryRepository> GetCategoryRepository()
        {
            var mock = new Mock<ICategoryRepository>();

            mock.Setup(x => x.GetCategory(1))
                .Returns(new Category(1, "Home"));

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
