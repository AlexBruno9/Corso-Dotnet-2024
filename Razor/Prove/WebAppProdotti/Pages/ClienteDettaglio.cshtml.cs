using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;
using Newtonsoft.Json;

namespace WebAppProdotti.Pages
{
    public class ClienteDettaglioModel : PageModel
    {
        public Cliente? Cliente { get; set; }
        public void OnGet(string nome)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/clienti.json");
            var clienti = JsonConvert.DeserializeObject<List<Cliente>>(json);
            Cliente = clienti!.FirstOrDefault(p => p.Nome == nome);
        }
    }
}