using BookWebApi.Controllers;
using BookWebApi.Models;
using BookWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTest.Medium.Test
{
    public class BooksControllerTest
    {
        [Fact]
        public void GetAll_ReturnsOkResultWithBooks()
        {
            // Arrange
            var mockService = new Mock<IBookService>();
            mockService.Setup(n => n.GetAll()).Returns(MockData.GetTestBookItems());
            var booksController = new BooksController(mockService.Object);

            // Act
            var result = booksController.GetAll();

            // Assert 
            Assert.IsType<OkObjectResult>(result);
            var bookList = result as OkObjectResult;
            Assert.IsType<List<Book>>(bookList.Value);
        }
    }
}
