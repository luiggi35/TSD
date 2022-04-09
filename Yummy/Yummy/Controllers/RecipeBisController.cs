using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yummy.Data;
using Yummy.Models;

namespace Yummy.Controllers
{
    public class RecipeBisController : Controller
    {
        private readonly YummyContext _context;

        public RecipeBisController(YummyContext context)
        {
            _context = context;
        }

        // GET: RecipeBis
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeBis.ToListAsync());
        }

        // GET: RecipeBis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBis = await _context.RecipeBis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeBis == null)
            {
                return NotFound();
            }

            return View(recipeBis);
        }

        // GET: RecipeBis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeBis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Time,Difficulty,Numberoflikes,Ingredients")] RecipeBis recipeBis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeBis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeBis);
        }

        // GET: RecipeBis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBis = await _context.RecipeBis.FindAsync(id);
            if (recipeBis == null)
            {
                return NotFound();
            }
            return View(recipeBis);
        }

        // POST: RecipeBis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Time,Difficulty,Numberoflikes,Ingredients")] RecipeBis recipeBis)
        {
            if (id != recipeBis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeBis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeBisExists(recipeBis.Id))
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
            return View(recipeBis);
        }

        // GET: RecipeBis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeBis = await _context.RecipeBis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipeBis == null)
            {
                return NotFound();
            }

            return View(recipeBis);
        }

        // POST: RecipeBis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeBis = await _context.RecipeBis.FindAsync(id);
            _context.RecipeBis.Remove(recipeBis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeBisExists(int id)
        {
            return _context.RecipeBis.Any(e => e.Id == id);
        }
    }
}
