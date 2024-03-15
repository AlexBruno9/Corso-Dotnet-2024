using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Accordion.Models;

namespace Accordion.Pages;

public class PrivacyModel : PageModel
{

    
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    
    public required IEnumerable<Prodotto> Prodotti { get; set; } //creo oggetto di tipo lista

    public void OnGet()
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

    }
}

