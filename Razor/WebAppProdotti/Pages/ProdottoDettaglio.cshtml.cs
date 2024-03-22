using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;

namespace WebAppProdotti.Pages
{
    public class ProdottoDettaglioModel : PageModel
    {
        public Prodotto? Prodotto { get; set; }
        public void OnGet(string nome)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            Prodotto = prodotti!.FirstOrDefault(p => p.Nome == nome);
        }
    }
}