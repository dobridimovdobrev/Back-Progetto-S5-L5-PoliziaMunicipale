using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity
{
    public class Verbale
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Data violazione obbligatioria")]
        public DateTime DataViolazione { get; set; }

        [Required(ErrorMessage = "Indirizzo Violazione obbligatiorio")]
        [StringLength(100)]
        public string IndirizzoViolazione { get; set; }

        [Required(ErrorMessage = "Nome Agente obbligatiorio")]
        [StringLength(100)]
        public string NominativoAgente { get; set; }

        [Required(ErrorMessage = "Data trascizione verbale obbligatioria")]
        public DateTime DataTrascizioneVerbale { get; set; }

        [Required(ErrorMessage = "Importo obbligatiorio")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Importo { get; set; }

        [Required(ErrorMessage = "Decurtamento punti obbligatiorio")]
        public int DecurtamentoPunti { get; set; }

        [Required]
        public Guid IdAnagrafica { get; set; }

        [Required]
        public Guid IdTipoViolazione { get; set; }

        //relazioni uno a molti, foreign key collegamento tabelle anagrafica e tipo violazioni

        [ForeignKey(nameof(IdAnagrafica))]
        public Anagrafica? Anagrafica { get; set; }

        [ForeignKey(nameof(IdTipoViolazione))]
        public TipoViolazione? TipoViolazione { get; set; }
    }
}
