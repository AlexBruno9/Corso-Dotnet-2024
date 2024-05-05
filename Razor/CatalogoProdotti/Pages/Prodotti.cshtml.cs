using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class ProdottiModel : PageModel
{
    public IEnumerable<Prodotto> Prodotti { get; set; } // IEnumerable è un'interfaccia generica definita in System.Collections.Generic e rappresenta una sequenza di elementi
    public int numeroPagine { get; set; } // Aggiungi una proprietà numeroPagine di tipo int
    private readonly ILogger<ProdottiModel> _logger;

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
{
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotti = prodotti;

    numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);
    Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
}

}