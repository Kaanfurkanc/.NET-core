using BookWebApi.Models;

namespace BookWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books;

        public BookService()
        {
            _books = new List<Book>() 
            { 
            
                new Book()
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Title = "Title",
                    Author = "Author",
                    Description = "Description",
                },

                new Book()
                {
                    Id = new Guid("117366b8-3541-4ac5-8732-860d698e26a2"),
                    Title = "Title1",
                    Author = "Author1",
                    Description = "Description1",
                },

                new Book()
                {
                    Id = new Guid("117366b8-3541-4ac5-8732-860d698e26a4"),
                    Title = "Title2",
                    Author = "Author2",
                    Description = "Description2",
                }
            };
        }
        public Book Add(Book book)
        {
            _books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            var books = MockData.GetTestBookItems();
            return books;
        }

        public Book? GetById(Guid id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            _books.Remove(GetById(id));           
        }
    }
}
