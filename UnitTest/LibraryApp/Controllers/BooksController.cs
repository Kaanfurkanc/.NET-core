using LibraryApp.Data;
using LibraryApp.Data.Models;
using LibraryApp.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        public readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var result = _bookService.GetAll();
            return View(result);
        }

        public IActionResult Details(Guid id)
        {
            var result = _bookService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                _bookService.Create(book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

        public IActionResult Delete(Guid id)
        {
            var result = _bookService.GetById(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            { 
                _bookService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}