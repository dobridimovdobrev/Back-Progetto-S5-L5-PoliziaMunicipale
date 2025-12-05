using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Back_Progetto_S5_L5_PoliziaMunicipale.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly AnagraficaService _anagraficaService;
        private readonly TipoViolazioneService _tipoViolazioneService;

        public VerbaleController(
            VerbaleService verbaleService,
            AnagraficaService anagraficaService,
            TipoViolazioneService tipoViolazioneService)
        {
            _verbaleService = verbaleService;
            _anagraficaService = anagraficaService;
            _tipoViolazioneService = tipoViolazioneService;
        }

        // lista verbali
        public async Task<IActionResult> Index()
        {
            var lista = await _verbaleService.GetVerbaliAsync();
            return View(lista);
        }

        // dettaglio verbale
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verbale = await _verbaleService.GetByIdVerbaleAsync(id.Value);
            if (verbale == null)
            {
                return NotFound();
            }

            return View(verbale);
        }

        // metodo get del create
        public async Task<IActionResult> Create()
        {
            await CaricaSelectListAsync();
            return View();
        }

        // creare verbale
        [HttpPost]
        public async Task<IActionResult> Create(Verbale verbale)
        {
            if (!ModelState.IsValid)
            {
                await CaricaSelectListAsync();
                return View(verbale);
            }

            bool created = await _verbaleService.CreateVerbaleAsync(verbale);

            return RedirectToAction(nameof(Index));
        }

        // metodo get per edit verbale
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verbale = await _verbaleService.GetByIdVerbaleAsync(id.Value);
            if (verbale == null)
            {
                return NotFound();
            }

            await CaricaSelectListAsync();
            return View(verbale);
        }

        // metodo post per edit verbale
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Verbale verbale)
        {
            if (id != verbale.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                await CaricaSelectListAsync();
                return View(verbale);
            }

            bool updated = await _verbaleService.UpdateVerbaleAsync(verbale);

            if (!updated)
            {
                await CaricaSelectListAsync();
                return View(verbale);
            }

            return RedirectToAction(nameof(Index));
        }

        // conferma eliminazione verbale
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verbale = await _verbaleService.GetByIdVerbaleAsync(id.Value);
            if (verbale == null)
            {
                return NotFound();
            }

            return View(verbale);
        }

        // elimina verbale
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _verbaleService.DeleteVerbaleAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // metodo privato per caricare le select
        private async Task CaricaSelectListAsync()
        {
            var anagrafiche = await _anagraficaService.GetAnagrafeAsync();
            var tipiViolazione = await _tipoViolazioneService.GetATipoViolazioniAsync();

            ViewBag.Anagrafiche = new SelectList(anagrafiche, "Id", "Cognome");
            ViewBag.TipiViolazione = new SelectList(tipiViolazione, "Id", "Descrizione");
        }
    }
}
