using BookWebApi.Controllers;
using BookWebApi.Models;
using BookWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BookWebApiTest
{
    public class BooksControllerTest
    {
        BooksController _booksController;
        IBookService _bookService;

        public BooksControllerTest()
        {
            _bookService = new BookService();
            _booksController = new BooksController(_bookService);
        }

        [Fact]
        public void GetAllTest()
        {
            // Arrange
            // Act
            var result = _booksController.GetAll();
            // Assert // We will check result type (List ,null)  and response type (ok , notfound)

            Assert.IsType<OkObjectResult>(result);

            var list = result as OkObjectResult;
            Assert.IsType<List<Book>>(list.Value);


            var listBooks = list.Value as List<Book>;
            Assert.Equal(3, listBooks.Count);
        }

        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200", "ab2bd817-98cd-4cf3-a80a-53ea0cd9c202")]

        public void GetByIdtest(string? guid1,string? guid2)
        { 
            // Arrange 
            var validGuid = new Guid(guid1);
            var invalidGuid = new Guid(guid2);

            //Act

            var notFoundResult = _booksController.Get(invalidGuid);
            var okResult = _booksController.Get(validGuid);

            //Assert 

            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.IsType<OkObjectResult>(okResult);

            var item = okResult as OkObjectResult;
            Assert.IsType<Book>(item.Value);

            var book = item.Value as Book;
            Assert.Equal(validGuid, book.Id);
        }

        [Fact]
        public void CreateTest()
        {
            // Created action test
            //Arrange 
            var completedBook = new Book() 
            { 
                Author = "Kaan Furkan Çakýroðlu",
                Title = "Unit Testing",
                Description = "XUnit framework is very useful for unit testing ",
            };

            //Act

            var createdResult = _booksController.Create(completedBook);

            //Assert 

            Assert.IsType<CreatedAtActionResult>(createdResult);

            var itemCreated = createdResult as CreatedAtActionResult;
            Assert.IsType<Book>(itemCreated.Value);

                    // Value Control 
            var createdBook = itemCreated.Value as Book;

            Assert.Equal(completedBook.Author, createdBook.Author);
            Assert.Equal(completedBook.Title, createdBook.Title);
            Assert.Equal(completedBook.Description, createdBook.Description);

            // BADREQUEST AND MODELSTATE ERROR TEST START
            // Arrange 
            var inCompletedBook = new Book()
            {
                Author = "Author",
                Description = "Description"
            };

            //Act 
            _booksController.ModelState.AddModelError("Title", "Title is a requried filed");
            var badResponse = _booksController.Create(inCompletedBook);

            // Assert 

            Assert.IsType<BadRequestObjectResult>(badResponse);

        }


        [Theory]
        [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200", "ab2bd817-98cd-4cf3-a80a-53ea0cd9c202")]
        public void DeleteTest(string guid1, string guid2)
        {
            // Arrange 
            var validGuid = new Guid(guid1);
            var invalidGuid = new Guid(guid2);

            // Act 

            var notFoundResult = _booksController.Delete(invalidGuid);

            // Assert 
            Assert.IsType<NotFoundResult>(notFoundResult);
            Assert.Equal(3, _bookService.GetAll().Count());


            // Act 

            var okResult = _booksController.Delete(validGuid);

            // Assert 

            Assert.IsType<OkResult>(okResult);
            Assert.Equal(2, _bookService.GetAll().Count());
        }
    }
}