using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class RicercaProdottiModel : PageModel
{
    public List<Prodotto> Prodotti { get; set; }
    public List<string> Categorie { get; set; }
    public int numeroPagine { get; set; }
    public void OnGet(string nome, decimal? minPrezzo, decimal? maxPrezzo, string categoria, int? pageIndex)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotti = prodotti;
        
        if (!string.IsNullOrEmpty(nome))
        {
            Prodotti = Prodotti.Where(p => p.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }
        if (minPrezzo != null)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo).ToList();
        }
        if (maxPrezzo != null)
        {
            Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo).ToList();
        }
        if (!string.IsNullOrEmpty(categoria))
        {
            Prodotti = Prodotti.Where(p => p.Categoria.ToLower() == categoria.ToLower()).ToList();
        }
        var jsonCategorie = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonCategorie);

        numeroPagine = (int)(Prodotti.Count() / 6.0);
    Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6).ToList();
    
    }
}