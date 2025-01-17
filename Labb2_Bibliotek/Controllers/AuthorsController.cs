using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.Models;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Labb2_Bibliotek.DTO;
using Labb2_Bibliotek.DTOs;

namespace Labb2_Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthor()
        {
            return await _context.Author.Include(b => b.Books).ToListAsync();
        }

        // GET: api/Authors/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Author>> GetAuthor(int id)
        //{
        //    var author = await _context.Author.FindAsync(id);

        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    return author;
        //}

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //    _context.Author.Add(author);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        //}

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(CreateAuthorDTO createAuthorDto)
        {
            var author = createAuthorDto.ToAuthor();
            _context.Author.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        //------------------------------------------------------------------------------------------------------------

        //[HttpPost("{id}/Add book to author")]
        //public async Task<ActionResult<Author>> AddBookToAuthor(int id, Book book)
        //{
        //    var authorId = _context.Author.FirstOrDefault(a => a.Id == id);
        //    if (authorId == null)
        //    {
        //        return NotFound();
        //    }
        //    book.Author.Add(authorId);

        //    _context.Books.Add(book);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = book.BookId }, book);
        //}

        //[HttpPost("{id}")]
        //public async Task<ActionResult<Author>> AddBookToAuthor(int id, CreateBookDTO createBookDto)
        //{

        //    var authorId = _context.Author.FirstOrDefault(a => a.Id == id);
        //    if (authorId == null)
        //    {
        //        return NotFound();
        //    }
        //    var book = createBookDto.ToBook();
        //    book.Author.Add(authorId);

        //    _context.Books.Add(book);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = book.BookId }, book);
        //}

        [HttpPost("{id}")]
        public async Task<ActionResult<Author>> AddBookToAuthor(int id, AddBookToAuthorDTO addBookToAuthorDto)
        {

            var authorId = _context.Author.FirstOrDefault(a => a.Id == id);
            if (authorId == null)
            {
                return NotFound();
            }
            var book = addBookToAuthorDto.AddBook();
            book.Author.Add(authorId);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = book.BookId }, book);
        }


        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Author.Any(e => e.Id == id);
        }
    }
}
