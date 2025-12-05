using Back_Progetto_S5_L5_PoliziaMunicipale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Controllers
{
    public class ReportController : Controller
    {
        private readonly VerbaleService _verbaleService;

        public ReportController(VerbaleService verbaleService)
        {
            _verbaleService = verbaleService;
        }

        // totale verbali per tras...
        public async Task<IActionResult> AllVerbali()
        {
            var data = await _verbaleService.GetVerbaliTrasgressoreAsync();
            return View(data);
        }

        //totale punti tras...
        public async Task<IActionResult> AllPunti()
        {
            var data = await _verbaleService.GetPuntiTrasgressoreAsync();
            return View(data);
        }

        //violazioni > 10 punti
        public async Task<IActionResult> DieciPunti()
        {
            var data = await _verbaleService.GetViolazioniDieciPuntiAsync();
            return View(data);
        }

        // violazioni importo >400 euro
        public async Task<IActionResult> QuattrocentoEuro()
        {
            var data = await _verbaleService.GetViolazioniQuattrocentoEuroAsync();
            return View(data);
        }
    }
}
