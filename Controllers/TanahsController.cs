using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_097_C.Models;

namespace UCP1_PAW_097_C.Controllers
{
    public class TanahsController : Controller
    {
        private readonly tanahKavlingContext _context;

        public TanahsController(tanahKavlingContext context)
        {
            _context = context;
        }

        // GET: Tanahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tanahs.ToListAsync());
        }

        // GET: Tanahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanah = await _context.Tanahs
                .FirstOrDefaultAsync(m => m.IdTanah == id);
            if (tanah == null)
            {
                return NotFound();
            }

            return View(tanah);
        }

        // GET: Tanahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tanahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTanah,JudulTanah,AlamatTanah,Status,Harga,Luas,Foto")] Tanah tanah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tanah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tanah);
        }

        // GET: Tanahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanah = await _context.Tanahs.FindAsync(id);
            if (tanah == null)
            {
                return NotFound();
            }
            return View(tanah);
        }

        // POST: Tanahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTanah,JudulTanah,AlamatTanah,Status,Harga,Luas,Foto")] Tanah tanah)
        {
            if (id != tanah.IdTanah)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tanah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TanahExists(tanah.IdTanah))
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
            return View(tanah);
        }

        // GET: Tanahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanah = await _context.Tanahs
                .FirstOrDefaultAsync(m => m.IdTanah == id);
            if (tanah == null)
            {
                return NotFound();
            }

            return View(tanah);
        }

        // POST: Tanahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tanah = await _context.Tanahs.FindAsync(id);
            _context.Tanahs.Remove(tanah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TanahExists(int id)
        {
            return _context.Tanahs.Any(e => e.IdTanah == id);
        }
    }
}
