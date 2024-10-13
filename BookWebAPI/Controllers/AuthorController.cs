using BookWebAPI.Context;
using BookWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWebAPI.Controllers
{
    [Route("Author/[controller]")]
    [ApiController]
    public class AuthorController :ControllerBase
    {
        private readonly BookContext _context;

        public AuthorController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var Author = await _context.Author.ToListAsync();
            return Ok(Author);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            var author = await _context.Author.FirstOrDefaultAsync(author => author.Id == id);
            return Ok(author);
        }

        [HttpPost]

        public async Task<ActionResult<Author>> createAuthor(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("Put/{id}")]

        public IActionResult Put(int id, Author updateAuthor)
        {
            var authorToUpdate = _context.Author.FirstOrDefault(updateAuthor => updateAuthor.Id == id);
            if (authorToUpdate == null)
            {
                return NotFound();
            }


            authorToUpdate.Name = updateAuthor.Name;
            authorToUpdate.BirthDate = updateAuthor.BirthDate;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var authorToRemove = await _context.Author.FirstOrDefaultAsync(author => author.Id == id);
            if (authorToRemove == null)
            {
                return NotFound();
            }

            _context.Author.Remove(authorToRemove);
            await _context.SaveChangesAsync();

            return NoContent();
        }





    }
}
