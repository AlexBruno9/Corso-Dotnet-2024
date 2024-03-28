using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class IndexModel : PageModel
{
    public List<Prodotto> Prodotti { get; set; }
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    }
}