using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppBrani.Pages
{
    public class AggiungiBranoModel : PageModel
    {
        private readonly ILogger<AggiungiBranoModel> _logger;

        public AggiungiBranoModel(ILogger<AggiungiBranoModel> logger)
        {
            _logger = logger;
        }
        public required IEnumerable<string> Genere { get; set; }


        public void OnGet() // LEGGE I GENERI PER LA SELEZIONE NEL FORM
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/Generi.json");
            string jsonText = System.IO.File.ReadAllText(path);
            var generiList = JsonConvert.DeserializeObject<List<string>>(jsonText);
            Genere = generiList!;
        }

        // AGGIUNTA DEL NUOVO BRANO ALLA PLAYLIST
        public IActionResult OnPost(string titolo, string artista, int anno, string genere, string durata, string immagine, string audio)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            int id = brani.Max(b => b.Id);
            id++;

            brani.Add(new Brano { Titolo = titolo, Artista = artista, Anno = anno, Immagine = immagine, Id = id, Genere = genere, Audio = audio, Durata = durata });
            // salva il file json formattato
            System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));
            return RedirectToPage("Brano");
        }


    }
}