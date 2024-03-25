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

        public IActionResult OnPost(int[] selezionatiBrani)
        {
            // var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            // var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            // Brano = brani.First(p => p.Id == id);

            // var json2 = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            // List<Brano> playlist = new List<Brano>();
            // if (json2 != "")
            // {
            //     playlist = JsonConvert.DeserializeObject<List<Brano>>(json2)!;
            // }

            // playlist.Add(Brano!);

            var jsonBrani = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            var tuttiBrani = JsonConvert.DeserializeObject<List<Brano>>(jsonBrani) ?? new List<Brano>();

            var braniDaAggiungere = tuttiBrani.Where(brano => selezionatiBrani.Contains(brano.Id)).ToList();

            var jsonPlaylist = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            var playlist = string.IsNullOrWhiteSpace(jsonPlaylist) ? new List<Brano>() : JsonConvert.DeserializeObject<List<Brano>>(jsonPlaylist) ?? new List<Brano>();

            playlist.AddRange(braniDaAggiungere);


            System.IO.File.WriteAllText("wwwroot/json/Playlist.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));

            return RedirectToPage("Playlist");
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}