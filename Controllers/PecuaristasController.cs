using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marfriing.Data;
using Marfriing.Models;

namespace Marfriing.Controllers
{
    public class PecuaristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PecuaristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pecuaristas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pecuarista.ToListAsync());
        }

        // GET: Pecuaristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecuarista = await _context.Pecuarista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pecuarista == null)
            {
                return NotFound();
            }

            return View(pecuarista);
        }

        // GET: Pecuaristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pecuaristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Pecuarista pecuarista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pecuarista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pecuarista);
        }

        // GET: Pecuaristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecuarista = await _context.Pecuarista.FindAsync(id);
            if (pecuarista == null)
            {
                return NotFound();
            }
            return View(pecuarista);
        }

        // POST: Pecuaristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Pecuarista pecuarista)
        {
            if (id != pecuarista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pecuarista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PecuaristaExists(pecuarista.Id))
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
            return View(pecuarista);
        }

        // GET: Pecuaristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecuarista = await _context.Pecuarista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pecuarista == null)
            {
                return NotFound();
            }

            return View(pecuarista);
        }

        // POST: Pecuaristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pecuarista = await _context.Pecuarista.FindAsync(id);
            _context.Pecuarista.Remove(pecuarista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PecuaristaExists(int id)
        {
            return _context.Pecuarista.Any(e => e.Id == id);
        }
    }
}
