using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prova1.Pages;

//  È possibile utilizzare IndexModel per fornire i dati alla pagina Index.cshtml

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

//  Possiamo aggiungere funzionalità al metodo OnGet per fornire i dati alla pagina Index.cshtml
    public void OnGet()
    {
        ViewData["Message"] = "Hello Razor from Alex"; // prova di funzionalita aggiunta
        // potevo anche metterlo nell'indexModel in Index.cshtml
    }

//  In questo modo stiamo assegnando un valore alla chiave "Message" del dizionario ViewData. Il messaggio verrà visualizzato nella pagina Index.cshtml tramite la sintassi @ViewData["Message"]

}
