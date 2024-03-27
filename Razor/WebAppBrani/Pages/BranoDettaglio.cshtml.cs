using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebAppBrani.Pages
{
    public class BranoDettaglioModel : PageModel
    {
        public Brano? Brano { get; set; }
        public void OnGet(int id) // LEGGE I BRANI PRESENTI NEL CATALOGO
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json);
            Brano = brani!.FirstOrDefault(p => p.Id == id);
        }
    }
}