using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ProdottoModel : PageModel
    {

        private readonly ILogger<ProdottoModel> _logger;

        public ProdottoModel(ILogger<ProdottoModel> logger)
        {
            _logger = logger;
        }

        public required IEnumerable<Prodotto> Prodotti { get; set; }
        public int numeroPagine { get; set; }
        public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
        {
            Prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 100, Disponibilita = 3, Info= " Colore: giallo", Dettaglio="Dettaglio 1" },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 200, Disponibilita = 8, Info= "Nuovo", Dettaglio="Dettaglio 2"  },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 300, Disponibilita = 23,  Info= "Modello classico", Dettaglio="Dettaglio 3"},
                  new Prodotto { Nome = "Prodotto 4", Prezzo = 100, Disponibilita = 3, Info= " Colore: blu", Dettaglio="Dettaglio 4" },
                new Prodotto { Nome = "Prodotto 5", Prezzo = 200, Disponibilita = 86, Info= "Nuovo", Dettaglio="Dettaglio 5"  },
                new Prodotto { Nome = "Prodotto 6", Prezzo = 300, Disponibilita = 30,  Info= "Modello classico", Dettaglio="Dettaglio 6"},
                  new Prodotto { Nome = "Prodotto 7", Prezzo = 100, Disponibilita = 33, Info= " Colore: rosso", Dettaglio="Dettaglio 7" },
                new Prodotto { Nome = "Prodotto 8", Prezzo = 200, Disponibilita = 8, Info= "Nuovo", Dettaglio="Dettaglio 8"  },
                new Prodotto { Nome = "Prodotto 9", Prezzo = 300, Disponibilita = 30,  Info= "Modello classico", Dettaglio="Dettaglio 9"},
                  new Prodotto { Nome = "Prodotto 10", Prezzo = 100, Disponibilita = 13, Info= " Colore: verde", Dettaglio="Dettaglio 10" },
                new Prodotto { Nome = "Prodotto 11", Prezzo = 200, Disponibilita = 8, Info= "Nuovo", Dettaglio="Dettaglio 11"  },
                new Prodotto { Nome = "Prodotto 12", Prezzo = 300, Disponibilita = 30,  Info= "Modello classico", Dettaglio="Dettaglio 12"}

            };
            if (minPrezzo.HasValue)
            {
                Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
                // aggiungi un log

                _logger.LogInformation("minPrezzo: {minPrezzo}", minPrezzo);
            }
            if (maxPrezzo.HasValue)
            {
                Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
                // aggiungi un log
                _logger.LogInformation("maxPrezzo: {maxPrezzo}", maxPrezzo);

            }


            // AGGIUNTA IMPAGINAZIONE

            numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 3.0);
            Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 3).Take(3);
            
            // Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 5).Take(5);
            // numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 2.0);

            /*
            Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 4).Take(4);
            // Skip() e Take() sono metodi di estensione definiti in System.Collections.Generic e consentono di eseguire la paginazione
            // Skip() consente di ignorare un numero specificato di elementi
            // Take() consente di restituire un numero specificato di elementi
            // ?? è l'operatore di coalescenza null che restituisce il valore sinistro se non è null, altrimenti restituisce il valore destro
            // in questo caso, se pageIndex ha un valore, viene utilizzato per calcolare l'indice della pagina, altrimenti viene utilizzato il valore 1
            // aggiungi un log
            _logger.LogInformation("pageIndex: {pageIndex}", pageIndex);
            */
        }
    }
}