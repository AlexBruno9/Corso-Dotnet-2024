using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppBrani.Pages
{
    public class RimuoviDaPlaylistModel : PageModel
    {

        public Brano? Brano {get;set;}

     

        public void OnGet(int id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            Brano=brani.FirstOrDefault(p=>p.Id==id);
            //se vogliamo trasmettere alla post il prezzo e il dettaglio per poi essere mandati alla view

            // ViewData["Titolo"]=Brano!.Titolo;
            // ViewData["Artista"]=Brano.Artista;
            // ViewData["Anno"]=Brano.Anno;
            //nella post possiamo usare ViewData["Prezzo"] e ViewData["Dettaglio"]
        }

        public IActionResult OnPost(int id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            var playlist = brani.FirstOrDefault(p=>p.Id==id);
            brani.Remove(playlist!);
            //salva il file json formattato

            System.IO.File.WriteAllText("wwwroot/json/Playlist.json", JsonConvert.SerializeObject(brani, Formatting.Indented));

            return RedirectToPage("Playlist");
        }

    }
}