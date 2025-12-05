using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Microsoft.EntityFrameworkCore;

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

    }
}
