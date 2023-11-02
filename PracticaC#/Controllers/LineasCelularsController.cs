using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaC_.Models;

namespace PracticaC_.Controllers
{
    public class LineasCelularsController : Controller
    {
        private readonly AppDBContext _context;

        public LineasCelularsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: LineasCelulars
        public async Task<IActionResult> Index()
        {
              return _context.LineasCelular != null ? 
                          View(await _context.LineasCelular.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.LineasCelulars'  is null.");
        }

        // GET: LineasCelulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LineasCelular == null)
            {
                return NotFound();
            }

            var lineasCelular = await _context.LineasCelular
                .FirstOrDefaultAsync(m => m.MobileLineId == id);
            if (lineasCelular == null)
            {
                return NotFound();
            }

            return View(lineasCelular);
        }

        // GET: LineasCelulars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LineasCelulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MobileLineId,MobileLine,Description")] LineasCelular lineasCelular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineasCelular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lineasCelular);
        }

        // GET: LineasCelulars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LineasCelular == null)
            {
                return NotFound();
            }

            var lineasCelular = await _context.LineasCelular.FindAsync(id);
            if (lineasCelular == null)
            {
                return NotFound();
            }
            return View(lineasCelular);
        }

        // POST: LineasCelulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MobileLineId,MobileLine,Description")] LineasCelular lineasCelular)
        {
            if (id != lineasCelular.MobileLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineasCelular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineasCelularExists(lineasCelular.MobileLineId))
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
            return View(lineasCelular);
        }

        // GET: LineasCelulars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LineasCelular == null)
            {
                return NotFound();
            }

            var lineasCelular = await _context.LineasCelular
                .FirstOrDefaultAsync(m => m.MobileLineId == id);
            if (lineasCelular == null)
            {
                return NotFound();
            }

            return View(lineasCelular);
        }

        // POST: LineasCelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LineasCelular == null)
            {
                return Problem("Entity set 'AppDBContext.LineasCelulars'  is null.");
            }
            var lineasCelular = await _context.LineasCelular.FindAsync(id);
            if (lineasCelular != null)
            {
                _context.LineasCelular.Remove(lineasCelular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineasCelularExists(int id)
        {
          return (_context.LineasCelular?.Any(e => e.MobileLineId == id)).GetValueOrDefault();
        }
    }
}
