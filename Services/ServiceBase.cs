using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Services
{
    public abstract class ServiceBase
    {
        protected readonly ApplicationDbContext _context;

        protected ServiceBase(ApplicationDbContext context)
        {
            _context = context;
        }

        protected async Task<bool> SaveAsync()
        {
            bool result = false;

            try
            {
                result= await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }



    }
}
