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
    public class agentmodelsController : Controller
    {
        private readonly mvcContext _context;

        public agentmodelsController(mvcContext context)
        {
            _context = context;
        }

        // GET: agentmodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agentmodel.ToListAsync());
        }

        // GET: agentmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentmodel = await _context.Agentmodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agentmodel == null)
            {
                return NotFound();
            }

            return View(agentmodel);
        }

        // GET: agentmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: agentmodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] agentmodel agentmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agentmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agentmodel);
        }

        // GET: agentmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentmodel = await _context.Agentmodel.FindAsync(id);
            if (agentmodel == null)
            {
                return NotFound();
            }
            return View(agentmodel);
        }

        // POST: agentmodels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] agentmodel agentmodel)
        {
            if (id != agentmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agentmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!agentmodelExists(agentmodel.Id))
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
            return View(agentmodel);
        }

        // GET: agentmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agentmodel = await _context.Agentmodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agentmodel == null)
            {
                return NotFound();
            }

            return View(agentmodel);
        }

        // POST: agentmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agentmodel = await _context.Agentmodel.FindAsync(id);
            _context.Agentmodel.Remove(agentmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool agentmodelExists(int id)
        {
            return _context.Agentmodel.Any(e => e.Id == id);
        }
    }
}
