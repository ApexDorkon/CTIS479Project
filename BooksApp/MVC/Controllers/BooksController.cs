using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using BLL.Models;
using BLL.Services.Bases;
using BLL.DAL.Entities;

namespace MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IService<Book, BookModel> _bookService;
        private readonly IAuthor _authorService;

        public BooksController(
            IService<Book, BookModel> bookService,
            IAuthor authorService
        )
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        // GET: Books
        public IActionResult Index()
        {
            var list = _bookService.Query().ToList();
            return View(list);
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            var item = _bookService.Query().SingleOrDefault(q => q.Record.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        protected void SetViewData()
        {
            ViewData["AuthorId"] = new SelectList(
                _authorService.Query().ToList(),
                "Record.Id",
                "FullName"
            );
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel book)
        {
            if (ModelState.IsValid)
            {
                var result = _bookService.Create(book.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = book.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {
            var item = _bookService.Query().SingleOrDefault(q => q.Record.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            SetViewData();
            return View(item);
        }

        // POST: Books/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                var result = _bookService.Update(book.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = book.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int id)
        {
            var item = _bookService.Query().SingleOrDefault(q => q.Record.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Books/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _bookService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}