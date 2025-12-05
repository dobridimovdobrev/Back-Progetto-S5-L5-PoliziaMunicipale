using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity
{
    public class Anagrafica
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Cognome obbligatiorio")]
        [StringLength(25)]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Nome obbligatiorio")]
        [StringLength(25)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Indirizzo obbligatiorio")]
        [StringLength(100)]
        public string Indirizzo { get; set; }
        [Required(ErrorMessage = "Citta obbligatioria")]
        [StringLength(50)]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Cap obbligatiorio")]
        [StringLength(5, MinimumLength = 5)]
        [Column(TypeName = "char(5)")]
        public string Cap { get; set; }

        [Required(ErrorMessage = "Codice Fiscale obbligatiorio")]
        [StringLength(16, MinimumLength = 16)]
        [Column(TypeName = "char(16)")]
        public string CodiceFiscale { get; set; }

        //relazione
        public List<Verbale> Verbali { get; set; }

    }
}
