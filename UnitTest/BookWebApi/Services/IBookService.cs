using BookWebApi.Models;

namespace BookWebApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(Guid id);
        Book Add(Book book);
        void Remove(Guid id);
    }
}
