using BookWebAPI.Context;
using BookWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var Book = await _context.Books.ToListAsync();
            return Ok(Book);    
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = _context.Books.FirstOrDefault(book => book.Id == id);
            return Ok(book);
        }

        [HttpPost]

        public async Task<ActionResult<Book>> createBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("Put/{id}")]
        public IActionResult Put(int id, Book updateBook)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(updatedBooks => updatedBooks.Id == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }

            bookToUpdate.Title = updateBook.Title;
            bookToUpdate.PublishedDate = updateBook.PublishedDate;
            bookToUpdate.AuthorId = updateBook.AuthorId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {var bookToRemove = _context.Books.FirstOrDefault(book => book.Id==id);
            if (bookToRemove == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookToRemove);
            _context.SaveChanges();

            return NoContent();
        }

    }

    
    
}
