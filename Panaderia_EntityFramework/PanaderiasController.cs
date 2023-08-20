using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Panaderia_EntityFramework.Models;

namespace Panaderia_EntityFramework
{
    public class PanaderiasController : Controller
    {
        private readonly EntityFrameworkIntroContext _context;

        public PanaderiasController(EntityFrameworkIntroContext context)
        {
            _context = context;
        }

        // GET: Panaderias
        public async Task<IActionResult> Index()
        {
              return _context.Panaderia != null ? 
                          View(await _context.Panaderia.ToListAsync()) :
                          Problem("Entity set 'EntityFrameworkIntroContext.Panaderia'  is null.");
        }

        // GET: Panaderias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Panaderia == null)
            {
                return NotFound();
            }

            var panaderia = await _context.Panaderia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panaderia == null)
            {
                return NotFound();
            }

            return View(panaderia);
        }

        // GET: Panaderias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Panaderias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Categoria,Descripcion,Precio,Disponibilidad,Ingredientes,Alergenos,Tamano,ValorNutricional,Imagen")] Panaderia panaderia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panaderia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(panaderia);
        }

        // GET: Panaderias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Panaderia == null)
            {
                return NotFound();
            }

            var panaderia = await _context.Panaderia.FindAsync(id);
            if (panaderia == null)
            {
                return NotFound();
            }
            return View(panaderia);
        }

        // POST: Panaderias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Categoria,Descripcion,Precio,Disponibilidad,Ingredientes,Alergenos,Tamano,ValorNutricional,Imagen")] Panaderia panaderia)
        {
            if (id != panaderia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panaderia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanaderiaExists(panaderia.Id))
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
            return View(panaderia);
        }

        // GET: Panaderias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Panaderia == null)
            {
                return NotFound();
            }

            var panaderia = await _context.Panaderia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panaderia == null)
            {
                return NotFound();
            }

            return View(panaderia);
        }

        // POST: Panaderias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Panaderia == null)
            {
                return Problem("Entity set 'EntityFrameworkIntroContext.Panaderia'  is null.");
            }
            var panaderia = await _context.Panaderia.FindAsync(id);
            if (panaderia != null)
            {
                _context.Panaderia.Remove(panaderia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanaderiaExists(int id)
        {
          return (_context.Panaderia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
