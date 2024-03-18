using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ProdottoDettaglioModel : PageModel
    {
        public Prodotto? Prodotto { get; set; }
        public void OnGet(string nome, decimal prezzo, int disponibilita, string info,  string dettaglio)
        {
            Prodotto = new Prodotto { Nome = nome, Prezzo = prezzo, Disponibilita=disponibilita, Info=info, Dettaglio=dettaglio };
        }
    }
}