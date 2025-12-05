using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Services
{
    public class AnagraficaService : ServiceBase
    {

        public AnagraficaService(ApplicationDbContext context) : base(context)
        {
        }

        // lista anagrafe
        public async Task<List<Anagrafica>> GetAnagrafeAsync()
        {
            try
            {
                return await _context.Anagrafica.AsNoTracking().OrderBy(a => a.Cognome).ThenBy(a => a.Nome).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Anagrafica>();
            }
        }

        // get by id anagrafica
        public async Task<Anagrafica?> GetByIdAnagraficaAsync(Guid id)
        {
            try
            {
                return await _context.Anagrafica.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        // creare anagrafica
        public async Task<bool> CreateAnagraficaAsync(Anagrafica anagrafica)
        {
            try
            {
                await _context.Anagrafica.AddAsync(anagrafica);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // modifica anagrafica
        public async Task<bool> UpdateAnagraficaAsync(Anagrafica anagrafica)
        {
            try
            {
                _context.Anagrafica.Update(anagrafica);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // elimina anagrafica
        public async Task<bool> DeleteAnagraficaAsync(Guid id)
        {
            try
            {
                var anagrafica = await _context.Anagrafica.FindAsync(id);
                if (anagrafica == null)
                    return false;

                _context.Anagrafica.Remove(anagrafica);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
