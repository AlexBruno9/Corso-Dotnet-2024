using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ProdottoDettaglioModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ProdottoDettaglioModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public required Prodotto Prodotto { get; set; }
        public void OnGet(string nome, string dettaglio, decimal prezzo)
        {
            Prodotto = new Prodotto { Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio };
            _logger.LogInformation("Dettaglio prodotti");
        }
    }
}