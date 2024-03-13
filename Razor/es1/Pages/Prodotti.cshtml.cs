using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace es1.Pages;


public class ProdottiModel : PageModel
{


/*    private readonly ILogger<ProdottiModel> _logger;

    public ProvaModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }
*/

    public required IEnumerable<Prodotto> Prodotti {get;set;}

    public void OnGet()
    {
        Prodotti = new List<Prodotto>
        {
            new Prodotto{Nome="Prodotto 1", Prezzo=100, Dettaglio="descr1"},
            new Prodotto{Nome="Prodotto 2", Prezzo=200,  Dettaglio="descr2"},
            new Prodotto{Nome="Prodotto 3", Prezzo=300,  Dettaglio="descr3"}
        };   
    }


}