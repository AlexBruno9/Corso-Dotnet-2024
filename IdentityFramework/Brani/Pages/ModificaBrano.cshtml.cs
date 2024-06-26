using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Brani.Pages
{
    public class ModificaBranoModel : PageModel
    {

        public Brano? Brano {get;set;}

      public required IEnumerable<string> Genere { get; set; }

        public void OnGet(int id) // LETTURA BRANI E GENERI PER MODIFICARE IL BRANO
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            Brano=brani.FirstOrDefault(p=>p.Id==id);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/Generi.json");
            string jsonText = System.IO.File.ReadAllText(path);
            var prenotazioniList = JsonConvert.DeserializeObject<List<string>>(jsonText);
            Genere = prenotazioniList!;
        }

        public IActionResult OnPost(int id, string titolo, string artista, int anno, string immagine, string genere, string durata) // SALVA LE MODIFICHE
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

            System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));
            return RedirectToPage("Brano");
        }

    }
}