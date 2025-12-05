using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnagraficaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anagrafica
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anagrafica.ToListAsync());
        }

        // GET: Anagrafica/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // GET: Anagrafica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anagrafica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cognome,Nome,Indirizzo,Citta,Cap,CodiceFiscale")] Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                anagrafica.Id = Guid.NewGuid();
                _context.Add(anagrafica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

        // GET: Anagrafica/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica.FindAsync(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        // POST: Anagrafica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Cognome,Nome,Indirizzo,Citta,Cap,CodiceFiscale")] Anagrafica anagrafica)
        {
            if (id != anagrafica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anagrafica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnagraficaExists(anagrafica.Id))
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
            return View(anagrafica);
        }

        // GET: Anagrafica/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // POST: Anagrafica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var anagrafica = await _context.Anagrafica.FindAsync(id);
            if (anagrafica != null)
            {
                _context.Anagrafica.Remove(anagrafica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnagraficaExists(Guid id)
        {
            return _context.Anagrafica.Any(e => e.Id == id);
        }
    }
}
