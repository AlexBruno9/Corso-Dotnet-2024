using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace WebAppBrani.Pages
{
    public class AggiungiAPlaylistModel : PageModel
    {

        public Brano? Brano { get; set; }



        public void OnGet(int id)
        {


            //se vogliamo trasmettere alla post il prezzo e il dettaglio per poi essere mandati alla view

            // ViewData["Titolo"]=Brano!.Titolo;
            // ViewData["Dettaglio"]=Brano.Dettaglio;
            // ViewData["Nome"]=Brano.Nome;
            //nella post possiamo usare ViewData["Prezzo"] e ViewData["Dettaglio"]
        }

        public IActionResult OnPost(int id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            Brano = brani.First(p => p.Id == id);

            var json2 = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            List<Brano> playlist = new List<Brano>();
            if (json2 != "")
            {
                playlist = JsonConvert.DeserializeObject<List<Brano>>(json2)!;
            }
       
            playlist.Add(Brano!);
            

            // var Brano = playlist.First(p=>p.Id==id);
       

            //salva il file json formattato

            System.IO.File.WriteAllText("wwwroot/json/Playlist.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));

            return RedirectToPage("Playlist");
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}