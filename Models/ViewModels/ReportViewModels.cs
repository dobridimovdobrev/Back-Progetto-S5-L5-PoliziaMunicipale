namespace Back_Progetto_S5_L5_PoliziaMunicipale.Models.ViewModels
{
    // totale verbali per trasgressore
    public class GetVerbaliTrasgressoreReport
    {
        public Guid IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public int TotaleVerbali { get; set; }
    }

    // totale punti trasgressore
    public class GetPuntiTrasgressoreReport
    {
        public Guid IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public int TotalePunti { get; set; }
    }

    // violazioni con > 10 punti
    public class ViolazioniDieciPuntiReport
    {
        public Guid IdVerbale { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataViolazione { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }

    // violazioni importo > 400 euro
    public class ViolazioniQuattrocentoEuroReport
    {
        public Guid IdVerbale { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataViolazione { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
