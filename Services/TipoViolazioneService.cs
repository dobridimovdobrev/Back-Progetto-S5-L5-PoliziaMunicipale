using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Services
{
    public class TipoViolazioneService : ServiceBase
    {
        public TipoViolazioneService(ApplicationDbContext context) : base(context)
        {
        }

        // lista TipoViolazione
        public async Task<List<TipoViolazione>> GetATipoViolazioniAsync()
        {
            try
            {
                return await _context.TipoViolazione.AsNoTracking().OrderBy(v => v.Descrizione).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<TipoViolazione>();
            }
        }

        // get by id TipoViolazione
        public async Task<TipoViolazione?> GetByIdTipoViolazioneAsync(Guid id)
        {
            try
            {
                return await _context.TipoViolazione.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        // creare TipoViolazione
        public async Task<bool> CreateTipoViolazioneAsync(TipoViolazione violazione)
        {
            try
            {
                await _context.TipoViolazione.AddAsync(violazione);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // modifica TipoViolazione
        public async Task<bool> UpdateTipoViolazioneAsync(TipoViolazione violazione)
        {
            try
            {
                _context.TipoViolazione.Update(violazione);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // elimina TipoViolazione
        public async Task<bool> DeleteTipoViolazioneAsync(Guid id)
        {
            try
            {
                var violazione = await _context.TipoViolazione.FindAsync(id);
                if (violazione == null)
                    return false;

                _context.TipoViolazione.Remove(violazione);
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
