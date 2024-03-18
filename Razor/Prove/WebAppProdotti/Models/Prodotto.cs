namespace WebAppProdotti.Models
{
    public class Prodotto
    {
        public string? Nome { get; set; }
        public decimal Prezzo { get; set; }
        public int Disponibilità {get;set;}
        public string? Info {get;set;}
    }
}