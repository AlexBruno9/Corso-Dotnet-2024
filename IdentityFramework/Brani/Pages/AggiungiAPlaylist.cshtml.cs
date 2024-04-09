using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Brani.Pages
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


            var jsonPlaylist = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
            int counter=0;
        

            if (string.IsNullOrWhiteSpace(jsonPlaylist))
            {
                
                var playlist = new List<Brano>();

                
                foreach(var brano in braniDaAggiungere)
                {
                    
                    counter++;
                    brano.Id=counter;
                    
                }

                playlist!.AddRange(braniDaAggiungere);
                System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));
            }
            else if(!string.IsNullOrWhiteSpace(jsonPlaylist))
            {
                var playlist = JsonConvert.DeserializeObject<List<Brano>>(jsonPlaylist);
         


                foreach(var brano in playlist!)
                {
                    counter++;
                }
                
                foreach(var brano in braniDaAggiungere)
                {
                    
                    counter++;
                    brano.Id=counter;
                    
                }
                

                playlist!.AddRange(braniDaAggiungere);
                System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));
            }

            return RedirectToPage("Playlist");
        }
    }
}