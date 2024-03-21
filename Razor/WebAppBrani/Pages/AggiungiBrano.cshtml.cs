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

        public int calcolaId(){
             var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            int id=1;
            foreach(Brano b in brani)
            {
                if(b.Id>=id)
                {
                    id=b.Id+1;
                }
            }
            return id;
        }

        public IActionResult OnPost(int id, string titolo, string artista, int anno, string genere, string durata, string immagine)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            id=calcolaId();

            brani.Add(new Brano { Titolo = titolo, Artista = artista, Anno = anno, Immagine = immagine, Id = id, Genere=genere, Durata=durata});
            // salva il file json formattato
            System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));
            return RedirectToPage("Brano");
        }

    }
}