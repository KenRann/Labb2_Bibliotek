using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.Models;

namespace Labb2_Bibliotek.Controllers
{
    public class BookCheckoutsController : Controller
    {
        private readonly AppDbContext _context;

        public BookCheckoutsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BookCheckouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookCheckouts.ToListAsync());
        }

        // GET: BookCheckouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCheckout = await _context.BookCheckouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCheckout == null)
            {
                return NotFound();
            }

            return View(bookCheckout);
        }

        // GET: BookCheckouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCheckouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckedOutDate,ReturnDate,ÍsReturned")] BookCheckout bookCheckout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCheckout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCheckout);
        }

        // GET: BookCheckouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCheckout = await _context.BookCheckouts.FindAsync(id);
            if (bookCheckout == null)
            {
                return NotFound();
            }
            return View(bookCheckout);
        }

        // POST: BookCheckouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckedOutDate,ReturnDate,ÍsReturned")] BookCheckout bookCheckout)
        {
            if (id != bookCheckout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCheckout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCheckoutExists(bookCheckout.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookCheckout);
        }

        // GET: BookCheckouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCheckout = await _context.BookCheckouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCheckout == null)
            {
                return NotFound();
            }

            return View(bookCheckout);
        }

        // POST: BookCheckouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCheckout = await _context.BookCheckouts.FindAsync(id);
            if (bookCheckout != null)
            {
                _context.BookCheckouts.Remove(bookCheckout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCheckoutExists(int id)
        {
            return _context.BookCheckouts.Any(e => e.Id == id);
        }
    }
}
