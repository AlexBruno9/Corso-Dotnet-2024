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

        public void OnGet()
        {
            // non fa nulla
        }

        public IActionResult OnPost(int id, string titolo, string artista, int anno, string immagine)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            brani.Add(new Brano { Titolo = titolo, Artista = artista, Anno = anno, Immagine = immagine, Id = id });
            // salva il file json formattato
            System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));
            return RedirectToPage("Brano");
        }

    }
}