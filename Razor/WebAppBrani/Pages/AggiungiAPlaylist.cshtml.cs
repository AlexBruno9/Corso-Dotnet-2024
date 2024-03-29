using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebAppBrani.Pages
{


    public class AggiungiAPlaylistModel : PageModel
    {



        public void OnGet(int id)
        {

        }

        public IActionResult OnPost(int[] selezionatiBrani, string titolo)  // AGGIUNGE I BRANI SELEZIONATI ALLA PLAYLIST
        {
            var jsonBrani = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var tuttiBrani = JsonConvert.DeserializeObject<List<Brano>>(jsonBrani) ?? new List<Brano>();

            var braniDaAggiungere = tuttiBrani.Where(brano => selezionatiBrani.Contains(brano.Id)).ToList();

            var jsonPlaylist = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");

            if (string.IsNullOrWhiteSpace(jsonPlaylist))
            {
                var playlist = new List<Brano>();
            }
            else
            {
                var playlist = JsonConvert.DeserializeObject<List<Brano>>(jsonPlaylist);
                playlist!.AddRange(braniDaAggiungere);


                System.IO.File.WriteAllText("wwwroot/json/Playlist.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));
            }

            // var playlist = string.IsNullOrWhiteSpace(jsonPlaylist) ? new List<Brano>() : JsonConvert.DeserializeObject<List<Brano>>(jsonPlaylist);

            // playlist!.AddRange(braniDaAggiungere);


            // System.IO.File.WriteAllText("wwwroot/json/Playlist.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));


            var json = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            var Brano = brani.FirstOrDefault(p => p.Titolo == titolo);

            int counter = 1;
            foreach (var brano in brani)
            {
                brano!.Id = counter;
                counter++;
            }

            //salva il file json formattato

            System.IO.File.WriteAllText("wwwroot/json/Playlist.json", JsonConvert.SerializeObject(brani, Formatting.Indented));

            return RedirectToPage("Playlist");
        }
    }
}