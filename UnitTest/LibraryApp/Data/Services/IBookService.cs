using LibraryApp.Data.Models;

namespace LibraryApp.Data.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(Guid id);
        Book Create(Book book);
        void Remove(Guid id);
    }
}
