using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDvideojuegos.Models;

namespace CRUDvideojuegos.Controllers
{
    public class ConsolasController : Controller
    {
        private readonly VideojuegosContext _context;

        public ConsolasController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Consolas
        public async Task<IActionResult> Index()
        {
              return _context.Consolas != null ? 
                          View(await _context.Consolas.ToListAsync()) :
                          Problem("Entity set 'VideojuegosContext.Consolas'  is null.");
        }

        // GET: Consolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consolas == null)
            {
                return NotFound();
            }

            var consola = await _context.Consolas
                .FirstOrDefaultAsync(m => m.IdConsola == id);
            if (consola == null)
            {
                return NotFound();
            }

            return View(consola);
        }

        // GET: Consolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsola,NombreConsola,Marca,Modelo,FechaReg")] Consola consola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consola);
        }

        // GET: Consolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consolas == null)
            {
                return NotFound();
            }

            var consola = await _context.Consolas.FindAsync(id);
            if (consola == null)
            {
                return NotFound();
            }
            return View(consola);
        }

        // POST: Consolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsola,NombreConsola,Marca,Modelo,FechaReg")] Consola consola)
        {
            if (id != consola.IdConsola)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsolaExists(consola.IdConsola))
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
            return View(consola);
        }

        // GET: Consolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consolas == null)
            {
                return NotFound();
            }

            var consola = await _context.Consolas
                .FirstOrDefaultAsync(m => m.IdConsola == id);
            if (consola == null)
            {
                return NotFound();
            }

            return View(consola);
        }

        // POST: Consolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consolas == null)
            {
                return Problem("Entity set 'VideojuegosContext.Consolas'  is null.");
            }
            var consola = await _context.Consolas.FindAsync(id);
            if (consola != null)
            {
                _context.Consolas.Remove(consola);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsolaExists(int id)
        {
          return (_context.Consolas?.Any(e => e.IdConsola == id)).GetValueOrDefault();
        }
    }
}
