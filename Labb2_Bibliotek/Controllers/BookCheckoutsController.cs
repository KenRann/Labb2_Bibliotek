using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.Models;

namespace Labb2_Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCheckoutsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookCheckoutsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BookCheckouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCheckout>>> GetBookCheckouts()
        {
            return await _context.BookCheckouts.ToListAsync();
        }

        // GET: api/BookCheckouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCheckout>> GetBookCheckout(int id)
        {
            var bookCheckout = await _context.BookCheckouts.FindAsync(id);

            if (bookCheckout == null)
            {
                return NotFound();
            }

            return bookCheckout;
        }

        // PUT: api/BookCheckouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookCheckout(int id, BookCheckout bookCheckout)
        {
            if (id != bookCheckout.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookCheckout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCheckoutExists(id))
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

        // POST: api/BookCheckouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookCheckout>> PostBookCheckout(BookCheckout bookCheckout)
        {
            _context.BookCheckouts.Add(bookCheckout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookCheckout", new { id = bookCheckout.Id }, bookCheckout);
        }

        // DELETE: api/BookCheckouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCheckout(int id)
        {
            var bookCheckout = await _context.BookCheckouts.FindAsync(id);
            if (bookCheckout == null)
            {
                return NotFound();
            }

            _context.BookCheckouts.Remove(bookCheckout);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookCheckoutExists(int id)
        {
            return _context.BookCheckouts.Any(e => e.Id == id);
        }
    }
}
