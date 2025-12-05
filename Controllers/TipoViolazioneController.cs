using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Back_Progetto_S5_L5_PoliziaMunicipale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneService _tipoViolazioneService;

        public TipoViolazioneController(TipoViolazioneService tipoViolazioneService)
        {
            _tipoViolazioneService = tipoViolazioneService;
        }

        // lista tipi violazione
        public async Task<IActionResult> Index()
        {
            var lista = await _tipoViolazioneService.GetATipoViolazioniAsync();
            return View(lista);
        }

        // dettaglio tipo violazione
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violazione = await _tipoViolazioneService.GetByIdTipoViolazioneAsync(id.Value);
            if (violazione == null)
            {
                return NotFound();
            }

            return View(violazione);
        }

        // metodo get del create
        public IActionResult Create()
        {
            return View();
        }

        // creare tipo violazione
        [HttpPost]
        public async Task<IActionResult> Create(TipoViolazione violazione)
        {
            if (!ModelState.IsValid)
            {
                return View(violazione);
            }

            bool created = await _tipoViolazioneService.CreateTipoViolazioneAsync(violazione);

            return RedirectToAction(nameof(Index));
        }

        // metodo get per edit tipo violazione
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violazione = await _tipoViolazioneService.GetByIdTipoViolazioneAsync(id.Value);
            if (violazione == null)
            {
                return NotFound();
            }

            return View(violazione);
        }

        // metodo post per edit tipo violazione
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TipoViolazione violazione)
        {
            if (id != violazione.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(violazione);
            }

            bool updated = await _tipoViolazioneService.UpdateTipoViolazioneAsync(violazione);

            if (!updated)
            {
                return View(violazione);
            }

            return RedirectToAction(nameof(Index));
        }

        // conferma eliminazione tipo violazione
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var violazione = await _tipoViolazioneService.GetByIdTipoViolazioneAsync(id.Value);
            if (violazione == null)
            {
                return NotFound();
            }

            return View(violazione);
        }

        // elimina tipo violazione
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _tipoViolazioneService.DeleteTipoViolazioneAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
