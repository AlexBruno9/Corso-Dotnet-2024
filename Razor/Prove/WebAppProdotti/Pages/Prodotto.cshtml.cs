using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ProdottoModel : PageModel
    {
        public required IEnumerable<Prodotto> Prodotti { get; set; }
        public void OnGet()
        {
            Prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 100, Disponibilita = 3, Info= " Colore: giallo", Dettaglio="Dettaglio 1" },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 200, Disponibilita = 8, Info= "Nuovo", Dettaglio="Dettaglio 2"  },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 300, Disponibilita = 30,  Info= "Modello classico", Dettaglio="Dettaglio 3"  }
            };
        }
    }
}