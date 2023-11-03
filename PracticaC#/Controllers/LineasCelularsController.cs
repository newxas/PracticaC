using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaC_.Models;

using Microsoft.AspNetCore.Authorization;

namespace PracticaC_.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> Details(Int64? id)
        {
            if (id != null)
            {
                return RedirectToAction("Index", "DetalleLlamadas", new { ids = id });
            }
            else
            {
                return View();
            }
        }

        private bool LineasCelularExists(int id)
        {
          return (_context.LineasCelular?.Any(e => e.MobileLineId == id)).GetValueOrDefault();
        }
    }
}
