using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaC_.Models;

namespace PracticaC_.Controllers
{
    [Authorize]
    public class DetalleLlamadasController : Controller
    {
        private readonly AppDBContext _context;

        public DetalleLlamadasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: DetalleLlamadas
        public async Task<IActionResult> Index( Int64? ids)
        {
            return _context.DetalleLlamadas != null ?
                        View(await _context.DetalleLlamadas.Where(x => x.MobileLine == ids).ToListAsync()) :
                        Problem("Entity set 'AppDBContext.DetalleLlamadas'  is null.");
            //return _context.DetalleLlamadas != null ? 
            //            View(await _context.DetalleLlamadas.ToListAsync()) :
            //            Problem("Entity set 'AppDBContext.DetalleLlamadas'  is null.");
        }

        // GET: DetalleLlamadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleLlamadas == null)
            {
                return NotFound();
            }

            var detalleLlamadas = await _context.DetalleLlamadas
                .FirstOrDefaultAsync(m => m.CallDetailId == id);
            if (detalleLlamadas == null)
            {
                return NotFound();
            }

            return View(detalleLlamadas);
        }

        // GET: DetalleLlamadas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetalleLlamadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CallDetailId,MobileLine,CalledPartyNumber,CalledPartyDescription,DateTime,Duration,TotalCost")] DetalleLlamadas detalleLlamadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleLlamadas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleLlamadas);
        }

        // GET: DetalleLlamadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleLlamadas == null)
            {
                return NotFound();
            }

            var detalleLlamadas = await _context.DetalleLlamadas.FindAsync(id);
            if (detalleLlamadas == null)
            {
                return NotFound();
            }
            return View(detalleLlamadas);
        }

        // POST: DetalleLlamadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CallDetailId,MobileLine,CalledPartyNumber,CalledPartyDescription,DateTime,Duration,TotalCost")] DetalleLlamadas detalleLlamadas)
        {
            if (id != detalleLlamadas.CallDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleLlamadas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleLlamadasExists(detalleLlamadas.CallDetailId))
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
            return View(detalleLlamadas);
        }

        // GET: DetalleLlamadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleLlamadas == null)
            {
                return NotFound();
            }

            var detalleLlamadas = await _context.DetalleLlamadas
                .FirstOrDefaultAsync(m => m.CallDetailId == id);
            if (detalleLlamadas == null)
            {
                return NotFound();
            }

            return View(detalleLlamadas);
        }

        // POST: DetalleLlamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleLlamadas == null)
            {
                return Problem("Entity set 'AppDBContext.DetalleLlamadas'  is null.");
            }
            var detalleLlamadas = await _context.DetalleLlamadas.FindAsync(id);
            if (detalleLlamadas != null)
            {
                _context.DetalleLlamadas.Remove(detalleLlamadas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleLlamadasExists(int id)
        {
          return (_context.DetalleLlamadas?.Any(e => e.CallDetailId == id)).GetValueOrDefault();
        }
    }
}
