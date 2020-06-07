using NUnit.Framework;

namespace ToDoList.Issue.Domain.Tests
{
    [TestFixture]
    public class IssueTests
    {
        [Test]
        public void Ctor_IncorrectName_ShouldThrowArgException()
        {
            // Arrange
            var issueName = string.Empty;

            // Act
            var del = new TestDelegate(() => new Entities.Issue(issueName));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void Ctor_CorrectData_ShouldCreateObject()
        {
            // Arrange
            var issueName = "Clean up room";

            // Act
            var del = new TestDelegate(() => new Entities.Issue(issueName));

            // Assert
            Assert.DoesNotThrow(del);
        }

        [Test]
        public void ChangeIssueStatus_IssueIsCompleted_ShouldChangeToUncompleted()
        {
            // Arrange
            var issue = new Entities.Issue("Clean up room", true);

            // Act
            issue.ChangeStatus();

            // Assert
            Assert.IsFalse(issue.IsCompleted);
        }

        [Test]
        public void SetName_IncorrectName_ShouldThrowArgException()
        {
            // Arrange
            var issue = new Entities.Issue("Clean up room");

            // Act
            var del = new TestDelegate(() => issue.SetName(string.Empty));

            // Assert
            Assert.Throws<System.ArgumentException>(del);
        }

        [Test]
        public void SetName_CorrectName_ShouldSetName()
        {
            // Arrange
            var issue = new Entities.Issue("Clean up room");

            // Act
            issue.SetName("Clean out room");

            // Assert
            Assert.AreEqual("Clean out room", issue.Name);
        }
    }
}
