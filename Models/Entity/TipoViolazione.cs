using System.ComponentModel.DataAnnotations;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity
{
    public class TipoViolazione
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Descrizione obbligatioria")]
        [StringLength(1000)]
        public string Descrizione { get; set; }

        //relazione
        public List<Verbale> Verbali { get; set; }
    }
}
