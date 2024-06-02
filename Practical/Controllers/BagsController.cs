using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practical.Data;
using Practical.Models;

namespace Practical.Controllers
{
    
   
    public class BagsController : Controller
    {
        private readonly mvcContext _context;

        public BagsController(mvcContext context)
        {
            _context = context;
        }

        [Route("Bags")]
        //[ApiController]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

       

        // GET: Bags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // GET: Bags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Price,Date")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bag);
        }

        // GET: Bags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Books.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }
            return View(bag);
        }

        // POST: Bags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Price,Date")] Bag bag)
        {
            if (id != bag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagExists(bag.Id))
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
            return View(bag);
        }

        // GET: Bags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // POST: Bags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bag = await _context.Books.FindAsync(id);
            _context.Books.Remove(bag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPut("update-price-2022")]
        public async Task<IActionResult> UpdatePrice2022()
        {
            var bags2022 = await _context.Books.Where(b => b.Date.Year == 2022).ToListAsync();
            bags2022.ForEach(b => b.Price = 2000);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("delete-1981")]
        public async Task<IActionResult> DeleteBooks1981()
        {
            var bags1981 = await _context.Books.Where(b => b.Date.Year == 1981).ToListAsync();
            _context.Books.RemoveRange(bags1981);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("brands-price-greater-500")]
        public async Task<IActionResult> GetBrandsPriceGreater500()
        {
            var brands = await _context.Books
                .Where(b => b.Price > 500)
                .Select(b => b.Brand)
                .ToListAsync();

            return Ok(brands);
        }

        private bool BagExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
