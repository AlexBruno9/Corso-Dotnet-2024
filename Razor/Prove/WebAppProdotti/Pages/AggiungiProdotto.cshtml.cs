using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppProdotti.Pages
{
    public class AggiungiProdottoModel : PageModel
    {

        
        private readonly ILogger<AggiungiProdottoModel> _logger;

        public AggiungiProdottoModel(ILogger<AggiungiProdottoModel> logger)
        {
            _logger = logger;
        }
        

        public void OnGet()
        {
            // non fa nulla
        }

        public IActionResult OnPost(string nome, decimal prezzo, string dettaglio)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json)!;

            prodotti.Add(new Prodotto { Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio, Immagine="https://source.unsplash.com/random/300x200?sig=11&web" });
            // salva il file json formattato
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));

            return RedirectToPage("Prodotto");
        }

    }
}