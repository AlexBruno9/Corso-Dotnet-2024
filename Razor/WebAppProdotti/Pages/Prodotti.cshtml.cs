using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages;

public class ProdottiModel : PageModel
{
    private readonly ILogger<ProdottiModel> _logger;    //non è necessario

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public required IEnumerable<Prodotto> Prodotti { get; set; } //creo oggetto di tipo lista
    public int numeroPagine{get;set;    }
    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto {Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "Descrizione prodotto 1"},
            new Prodotto {Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "Descrizione prodotto 2"},
            new Prodotto {Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "Descrizione prodotto 3"},
            new Prodotto {Nome = "Prodotto 4", Prezzo = 150, Dettaglio = "Descrizione prodotto 4"},
            new Prodotto {Nome = "Prodotto 5", Prezzo = 250, Dettaglio = "Descrizione prodotto 5"},
            new Prodotto {Nome = "Prodotto 6", Prezzo = 350, Dettaglio = "Descrizione prodotto 6"},
            new Prodotto {Nome = "Prodotto 7", Prezzo = 100, Dettaglio = "Descrizione prodotto 7"},
            new Prodotto {Nome = "Prodotto 8", Prezzo = 200, Dettaglio = "Descrizione prodotto 8"},
            new Prodotto {Nome = "Prodotto 9", Prezzo = 300, Dettaglio = "Descrizione prodotto 9"},
            new Prodotto {Nome = "Prodotto 10", Prezzo = 150, Dettaglio = "Descrizione prodotto 10"},
            new Prodotto {Nome = "Prodotto 11", Prezzo = 250, Dettaglio = "Descrizione prodotto 11"},
            new Prodotto {Nome = "Prodotto 12", Prezzo = 350, Dettaglio = "Descrizione prodotto 12"},
            new Prodotto {Nome = "Prodotto 13", Prezzo = 200, Dettaglio = "Descrizione prodotto 13"},
            new Prodotto {Nome = "Prodotto 14", Prezzo = 300, Dettaglio = "Descrizione prodotto 14"},
            new Prodotto {Nome = "Prodotto 15", Prezzo = 150, Dettaglio = "Descrizione prodotto 15"},
            new Prodotto {Nome = "Prodotto 16", Prezzo = 250, Dettaglio = "Descrizione prodotto 16"},
            new Prodotto {Nome = "Prodotto 17", Prezzo = 350, Dettaglio = "Descrizione prodotto 17"}
        };
        if (minPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
            _logger.LogInformation("Inserito filtro minimo prezzo: {minPrezzo}", minPrezzo);
        }
        if (maxPrezzo.HasValue)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
            _logger.LogInformation("Inserito filtro max prezzo: {maxPrezzo}", maxPrezzo);
        }

        _logger.LogInformation("Prodotti filtrati per prezzo");

        numeroPagine=(int)Math.Ceiling(Prodotti.Count()/5.0);
        Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 5).Take(5);
        


        _logger.LogInformation("{pageIndex}", pageIndex);
    }
}

