using Back_Progetto_S5_L5_PoliziaMunicipale.Services;
using Microsoft.EntityFrameworkCore;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Anagrafica> Anagrafica { get; set; }
        public DbSet<TipoViolazione> TipoViolazione { get; set; }
        public DbSet<Verbale> Verbale { get; set; }
    }
}
