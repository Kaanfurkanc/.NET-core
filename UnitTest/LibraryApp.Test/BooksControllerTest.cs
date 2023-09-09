using LibraryApp.Controllers;
using LibraryApp.Data.MockData;
using LibraryApp.Data.Models;
using LibraryApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LibraryApp.Test
{
    public class BooksControllerTest
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange

            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(n => n.GetAll()).Returns(MockData.GetTestBookItems());
            var controller  = new BooksController(mockRepo.Object);

            // Act

            var result = controller.Index();

            // Assert 

            var viewData = Assert.IsType<ViewResult>(result);
            var data = Assert.IsType<List<Book>>(viewData.ViewData.Model);
            Assert.Equal(5, data.Count);
        }

        [Theory]
        [InlineData("117366b8-3541-4ac5-8732-860d698e26a2", "117366b8-3541-4ac5-8732-860d698e26a3")]
        public void DetailsTest(string guid1, string guid2)
        {
            // Arrange
            var validGuid = new Guid(guid1);
            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(n => n.GetById(validGuid)).Returns(MockData.GetTestBookItems().FirstOrDefault(_ => _.Id == validGuid));
            var controller = new BooksController(mockRepo.Object);

            // Act 
            var result = controller.Details(validGuid);
            // Assert 

            var viewData = Assert.IsType<ViewResult>(result);
            var data = Assert.IsType<Book>(viewData.ViewData.Model);
            Assert.Equal("David Buss", data.Author);
            Assert.Equal("Evolutionary Psychology", data.Title);

            // Arrange
            var invalidGuid = new Guid(guid2);
            mockRepo.Setup(n => n.GetById(invalidGuid)).Returns(MockData.GetTestBookItems().FirstOrDefault(_ => _.Id == invalidGuid));
            // Act
            var notFoundResult = controller.Details(invalidGuid);
            // Assert 
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void CreateTest()
        {
            // Arrange

            var mockRepo = new Mock<IBookService>();
            var controller = new BooksController(mockRepo.Object);

            var newValidItem = new Book() 
            {
                Title = "Title",
                Description = "Description",
                Author = "Author",
            };

            // Act 

            var result = controller.Create(newValidItem);

            // Assert 

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index",redirectToActionResult.ActionName);
            Assert.Null(redirectToActionResult.ControllerName);


            // Arrange
            var newInvalidItem = new Book() 
            { 
                Title = "Title",
                Description = "Description",
            };
            controller.ModelState.AddModelError("Author","The Author value is required !");
            // Act
            var badRequestResult = controller.Create(newInvalidItem);

            // Assert
            Assert.IsType<BadRequestResult>(badRequestResult);
        }

        [Theory]
        [InlineData("117366b8-3541-4ac5-8732-860d698e26a2")]
        public void DeleteTest(string guid)
        {
            // Arrange

            var validGuid = new Guid(guid);
            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(n => n.GetAll()).Returns(MockData.GetTestBookItems());
            var controller = new BooksController(mockRepo.Object);

            // Act

            var result = controller.Delete(validGuid, null);

            // Assert 

            var actionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index",actionResult.ActionName);
            Assert.Null(actionResult.ControllerName);
        }
    }
}