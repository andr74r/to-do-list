using NUnit.Framework;
using System.Linq;

namespace ToDoList.Issue.Domain.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Ctor_IncorrectUserId_ShouldThrowArgException()
        {
            // Arrange
            var userId = -1;

            // Act
            var del = new TestDelegate(() => new Entities.Category(userId, "Home"));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void Ctor_IncorrectName_ShouldThrowArgException()
        {
            // Arrange
            var name = string.Empty;

            // Act
            var del = new TestDelegate(() => new Entities.Category(1, name));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void SetName_IncorrectName_ShouldThrowArgException()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");

            // Act
            var del = new TestDelegate(() => category.SetName(string.Empty));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void SetName_CorrectName_ShouldSetName()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");

            // Act
            category.SetName("Work");

            // Assert
            Assert.AreEqual("Work", category.Name);
        }

        [Test]
        public void AddIssue_UniqueIssue_ShouldAddIssue()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");

            // Act
            category.AddIssue("Clean up room");

            // Assert
            Assert.AreEqual("Clean up room", category.GetIssues().First().Name);
        }

        [Test]
        public void AddIssue_ExistingIssue_ShouldThrowArgException()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");
            category.AddIssue("Clean up room");

            // Act
            var del = new TestDelegate(() => category.AddIssue("Clean up room"));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void RemoveIssue_IssueName_ShouldRemoveIssue()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");
            category.AddIssue("Clean up room");

            // Act
            category.RemoveIssue("Clean up room");

            // Assert
            Assert.AreEqual(0, category.GetIssues().Count);
        }

        [Test]
        public void ChangeIssueName_UniqueIssueName_ShouldSetIssueName()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");
            category.AddIssue("Clean up room");

            // Act
            category.ChangeIssueName("Clean up room", "Clean out room");

            // Assert
            Assert.AreEqual("Clean out room", category.GetIssues().First().Name);
        }

        [Test]
        public void ChangeIssueName_ExistingIssueName_ShouldThrowArgException()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");
            category.AddIssue("Clean up room");
            category.AddIssue("Clean out room");

            // Act
            var del = new TestDelegate(() => category.ChangeIssueName("Clean out room", "Clean up room"));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void ChangeIssueName_IssueNotFound_ShouldThrowArgException()
        {
            // Arrange
            var category = new Entities.Category(1, "Home");
            category.AddIssue("Clean up room");

            // Act
            var del = new TestDelegate(() => category.ChangeIssueName("Clean out room", "Clean up room"));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }
    }
}
