using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Back_Progetto_S5_L5_PoliziaMunicipale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;

        public AnagraficaController(AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }
        // la lista
        public async Task<IActionResult> Index()
        {
            var lista = await _anagraficaService.GetAnagrafeAsync();
            return View(lista);
        }

        // angrafica by id
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficaService.GetByIdAnagraficaAsync(id.Value);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // metodo get del create
        public IActionResult Create()
        {
            return View();
        }

        // creare anagrafica
        [HttpPost]
        public async Task<IActionResult> Create(Anagrafica anagrafica)
        {
            if (!ModelState.IsValid)
            {
                return View(anagrafica);
            }

            bool created = await _anagraficaService.CreateAnagraficaAsync(anagrafica);

            return RedirectToAction(nameof(Index));
        }

        // metodo get per edit anagrafica
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficaService.GetByIdAnagraficaAsync(id.Value);
            if (anagrafica == null)
            {
                return NotFound();
            }
            return View(anagrafica);
        }

        // metodo post per edit anagrafica
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Anagrafica anagrafica)
        {
            if (id != anagrafica.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(anagrafica);
            }

            bool updated = await _anagraficaService.UpdateAnagraficaAsync(anagrafica);

            if (!updated)
            {
                return View(anagrafica);
            }

            return RedirectToAction(nameof(Index));
        }

        // conferma eliminazione anagrafica
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _anagraficaService.GetByIdAnagraficaAsync(id.Value);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }
        // elimina anagrafica
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _anagraficaService.DeleteAnagraficaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
