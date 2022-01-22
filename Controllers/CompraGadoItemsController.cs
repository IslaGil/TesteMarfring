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
    public class CompraGadoItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraGadoItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompraGadoItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraGadoItem.ToListAsync());
        }

        // GET: CompraGadoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraGadoItem = await _context.CompraGadoItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compraGadoItem == null)
            {
                return NotFound();
            }

            return View(compraGadoItem);
        }

        // GET: CompraGadoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompraGadoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCompraGado,IdAnimal,Quantidade")] CompraGadoItem compraGadoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraGadoItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraGadoItem);
        }

        // GET: CompraGadoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraGadoItem = await _context.CompraGadoItem.FindAsync(id);
            if (compraGadoItem == null)
            {
                return NotFound();
            }
            return View(compraGadoItem);
        }

        // POST: CompraGadoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCompraGado,IdAnimal,Quantidade")] CompraGadoItem compraGadoItem)
        {
            if (id != compraGadoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraGadoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraGadoItemExists(compraGadoItem.Id))
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
            return View(compraGadoItem);
        }

        // GET: CompraGadoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraGadoItem = await _context.CompraGadoItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compraGadoItem == null)
            {
                return NotFound();
            }

            return View(compraGadoItem);
        }

        // POST: CompraGadoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraGadoItem = await _context.CompraGadoItem.FindAsync(id);
            _context.CompraGadoItem.Remove(compraGadoItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraGadoItemExists(int id)
        {
            return _context.CompraGadoItem.Any(e => e.Id == id);
        }
    }
}
