using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Back_Progetto_S5_L5_PoliziaMunicipale.Models.ViewModels;


namespace Back_Progetto_S5_L5_PoliziaMunicipale.Services
{
    public class VerbaleService : ServiceBase
    {

        public VerbaleService(ApplicationDbContext context) : base(context)
        {
        }

        // lista Verbali
        public async Task<List<Verbale>> GetVerbaliAsync()
        {
            try
            {
                return await _context.Verbale.Include(verbale => verbale.Anagrafica).Include(verbale => verbale.TipoViolazione).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Verbale>();
            }
        }

        // get by id Verbale
        public async Task<Verbale?> GetByIdVerbaleAsync(Guid id)
        {
            try
            {
                return await _context.Verbale.Include(verbale => verbale.Anagrafica).Include(verbale => verbale.TipoViolazione).AsNoTracking().FirstOrDefaultAsync(verbale => verbale.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        // creare Verbale
        public async Task<bool> CreateVerbaleAsync(Verbale verbale)
        {
            try
            {
                await _context.Verbale.AddAsync(verbale);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // modifica Verbale
        public async Task<bool> UpdateVerbaleAsync(Verbale verbale)
        {
            try
            {
                _context.Verbale.Update(verbale);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // elimina Verbale
        public async Task<bool> DeleteVerbaleAsync(Guid id)
        {
            try
            {
                var verbale = await _context.Verbale.FindAsync(id);
                if (verbale == null)
                    return false;

                _context.Verbale.Remove(verbale);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        // totale verbali trasgressore
        public async Task<List<GetVerbaliTrasgressoreReport>> GetVerbaliTrasgressoreAsync()
        {
            try
            {
                return await _context.Verbale
                    .Include(verbale => verbale.Anagrafica)
                    .AsNoTracking()
                    .GroupBy(verbale => new { verbale.IdAnagrafica, verbale.Anagrafica.Cognome, verbale.Anagrafica.Nome })
                    .Select(g => new GetVerbaliTrasgressoreReport
                    {
                        IdAnagrafica = g.Key.IdAnagrafica,
                        Cognome = g.Key.Cognome,
                        Nome = g.Key.Nome,
                        TotaleVerbali = g.Count()
                    })
                    .OrderBy(r => r.Cognome)
                    .ThenBy(r => r.Nome)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<GetVerbaliTrasgressoreReport>();
            }
        }
        // totale punti tras...
        public async Task<List<GetPuntiTrasgressoreReport>> GetPuntiTrasgressoreAsync()
        {
            try
            {
                return await _context.Verbale
                    .Include(verbale => verbale.Anagrafica)
                    .AsNoTracking()
                    .GroupBy(verbale => new { verbale.IdAnagrafica, verbale.Anagrafica.Cognome, verbale.Anagrafica.Nome })
                    .Select(g => new GetPuntiTrasgressoreReport
                    {
                        IdAnagrafica = g.Key.IdAnagrafica,
                        Cognome = g.Key.Cognome,
                        Nome = g.Key.Nome,
                        TotalePunti = g.Sum(v => v.DecurtamentoPunti)
                    })
                    .OrderBy(r => r.Cognome)
                    .ThenBy(r => r.Nome)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<GetPuntiTrasgressoreReport>();
            }
        }

        //violazioni decurtamento > 10 putni
        public async Task<List<ViolazioniDieciPuntiReport>> GetViolazioniDieciPuntiAsync()
        {
            try
            {
                return await _context.Verbale
                    .Include(verbale => verbale.Anagrafica)
                    .AsNoTracking()
                    .Where(verbale => verbale.DecurtamentoPunti > 10)
                    .Select(verbale => new ViolazioniDieciPuntiReport
                    {
                        IdVerbale = verbale.Id,
                        Cognome = verbale.Anagrafica.Cognome,
                        Nome = verbale.Anagrafica.Nome,
                        DataViolazione = verbale.DataViolazione,
                        Importo = verbale.Importo,
                        DecurtamentoPunti = verbale.DecurtamentoPunti
                    })
                    .OrderBy(r => r.Cognome)
                    .ThenBy(r => r.Nome)
                    .ThenBy(r => r.DataViolazione)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ViolazioniDieciPuntiReport>();
            }
        }

        // violazioni con importo > 400 euro

        public async Task<List<ViolazioniQuattrocentoEuroReport>> GetViolazioniQuattrocentoEuroAsync()
        {
            try
            {
                return await _context.Verbale
                    .Include(verbale => verbale.Anagrafica)
                    .AsNoTracking()
                    .Where(verbale => verbale.Importo > 400)
                    .Select(verbale => new ViolazioniQuattrocentoEuroReport
                    {
                        IdVerbale = verbale.Id,
                        Cognome = verbale.Anagrafica.Cognome,
                        Nome = verbale.Anagrafica.Nome,
                        DataViolazione = verbale.DataViolazione,
                        Importo = verbale.Importo,
                        DecurtamentoPunti = verbale.DecurtamentoPunti
                    })
                    .OrderBy(r => r.Importo)
                    .ThenBy(r => r.Cognome)
                    .ThenBy(r => r.Nome)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ViolazioniQuattrocentoEuroReport>();
            }
        }


    }
}
