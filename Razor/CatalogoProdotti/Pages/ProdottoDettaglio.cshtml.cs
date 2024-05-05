using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

    public class ProdottoDettaglioModel : PageModel
    {
        public Prodotto Prodotto { get; set; }

        public void OnGet(int id)
{
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotto = prodotti.FirstOrDefault(p => p.Id == id);
}
    }