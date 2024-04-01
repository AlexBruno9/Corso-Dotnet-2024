using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppBrani.Pages
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

        public IActionResult OnPost(int id) // ELIMINA IL BRANO DAL CATALOGO (FILE JSON)
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