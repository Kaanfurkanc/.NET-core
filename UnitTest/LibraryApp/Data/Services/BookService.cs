using LibraryApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public Book Create(Book book)
        {
            _context.Books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetAll() => _context.Books.AsNoTracking().ToList();

        public Book GetById(Guid id)
        {
            return _context.Books.FirstOrDefault(book => book.Id == id);
        }

        public void Remove(Guid id)
        {
            _context.Remove(id);
        }
    }
}
