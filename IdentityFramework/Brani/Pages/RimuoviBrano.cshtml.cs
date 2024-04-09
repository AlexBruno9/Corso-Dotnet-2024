using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Brani.Pages
{
    public class RimuoviBranoModel : PageModel
    {

        public Brano? Brano { get; set; }



        public void OnGet(int id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            Brano = brani.FirstOrDefault(p => p.Id == id);
        }

        // ELIMINA IL SINGOLO BRANO DAL CATALOGO QUANDO SI ELIMINA DALLA PAGINA DI DETTAGLIO DEL BRANO

        public IActionResult OnPost(int id) 
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            var list = brani.FirstOrDefault(p => p.Id == id);
            brani.Remove(list!);

            System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));

            return RedirectToPage("Brano");
        }

    }
}