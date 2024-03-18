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
                new Prodotto { Nome = "Prodotto 1", Prezzo = 100, Disponibilità = 3, Info= " Colore: giallo" },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 200, Disponibilità = 8, Info= "Nuovo"  },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 300, Disponibilità = 30,  Info= "Modello classico"  }
            };
        }
    }
}