using BookWebApi.Models;
using BookWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
              _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]

        public IActionResult Get(Guid id) 
        { 
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]

        public IActionResult Create([FromBody] Book book)
        {
            if (! ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = _bookService.Add(book);
            return CreatedAtAction("Get", new {id = value.Id}, value);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(id);
            return Ok();
        }
    }
}
