using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppBrani.Pages
{
    public class ModificaBranoModel : PageModel
    {

        public Brano? Brano {get;set;}

     

        public void OnGet(int id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            Brano=brani.FirstOrDefault(p=>p.Id==id);
        }

        public IActionResult OnPost(int id, string titolo, string artista, int anno, string immagine, string genere, string durata)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            var Brano = brani.FirstOrDefault(p=>p.Id==id);
            Brano!.Titolo=titolo;
            Brano!.Artista=artista;
            Brano!.Anno=anno;
            Brano!.Immagine=immagine;
            Brano!.Genere=genere;
            Brano!.Durata=durata;
        
            //salva il file json formattato

            System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));
            return RedirectToPage("Brano");
        }

    }
}