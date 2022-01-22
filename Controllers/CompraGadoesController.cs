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
    public class CompraGadoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraGadoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompraGadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraGado.ToListAsync());
        }

        // GET: CompraGadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraGado = await _context.CompraGado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compraGado == null)
            {
                return NotFound();
            }

            return View(compraGado);
        }

        // GET: CompraGadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompraGadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPecuarista,DataEntrega")] CompraGado compraGado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraGado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraGado);
        }

        // GET: CompraGadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraGado = await _context.CompraGado.FindAsync(id);
            if (compraGado == null)
            {
                return NotFound();
            }
            return View(compraGado);
        }

        // POST: CompraGadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPecuarista,DataEntrega")] CompraGado compraGado)
        {
            if (id != compraGado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraGado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraGadoExists(compraGado.Id))
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
            return View(compraGado);
        }

        // GET: CompraGadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraGado = await _context.CompraGado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compraGado == null)
            {
                return NotFound();
            }

            return View(compraGado);
        }

        // POST: CompraGadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraGado = await _context.CompraGado.FindAsync(id);
            _context.CompraGado.Remove(compraGado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraGadoExists(int id)
        {
            return _context.CompraGado.Any(e => e.Id == id);
        }
    }
}
