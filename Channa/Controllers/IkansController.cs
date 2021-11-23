using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Channa.Models;

namespace Channa.Controllers
{
    public class IkansController : Controller
    {
        private readonly ikanContext _context;

        public IkansController(ikanContext context)
        {
            _context = context;
        }

        // GET: Ikans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ikan.ToListAsync());
        }

        // GET: Ikans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ikan = await _context.Ikan
                .FirstOrDefaultAsync(m => m.IdIkan == id);
            if (ikan == null)
            {
                return NotFound();
            }

            return View(ikan);
        }

        // GET: Ikans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ikans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIkan,NamaIkan,StockIkan,HargaIkan")] Ikan ikan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ikan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ikan);
        }

        // GET: Ikans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ikan = await _context.Ikan.FindAsync(id);
            if (ikan == null)
            {
                return NotFound();
            }
            return View(ikan);
        }

        // POST: Ikans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIkan,NamaIkan,StockIkan,HargaIkan")] Ikan ikan)
        {
            if (id != ikan.IdIkan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ikan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IkanExists(ikan.IdIkan))
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
            return View(ikan);
        }

        // GET: Ikans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ikan = await _context.Ikan
                .FirstOrDefaultAsync(m => m.IdIkan == id);
            if (ikan == null)
            {
                return NotFound();
            }

            return View(ikan);
        }

        // POST: Ikans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ikan = await _context.Ikan.FindAsync(id);
            _context.Ikan.Remove(ikan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IkanExists(int id)
        {
            return _context.Ikan.Any(e => e.IdIkan == id);
        }
    }
}
