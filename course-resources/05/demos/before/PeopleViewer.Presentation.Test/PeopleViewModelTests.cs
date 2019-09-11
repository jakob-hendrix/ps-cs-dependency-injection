using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PeopleViewer.Presentation.Test
{
    [TestClass]
    public class PeopleViewModelTests
    {
        [TestMethod]
        public void People_OnRefreshPeople_IsPopulated()
        {
            // Arrange
            var reader = new FakeReader();
            var viewModel = new PeopleViewModel(reader);

            // Act
            viewModel.RefreshPeople();

            // Assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        [TestMethod]
        public void People_OnClearPeople_IsEmpty()
        {
            // Arrange
            var reader = new FakeReader();
            var viewModel = new PeopleViewModel(reader);
            viewModel.RefreshPeople();

            Assert.IsNotNull(viewModel.People, "Invalid arrangement");
            Assert.AreNotEqual(0, viewModel.People.Count(), "Invalid arrangement");

            // Act
            viewModel.ClearPeople();

            // Assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(0, viewModel.People.Count());
        }
    }
}
