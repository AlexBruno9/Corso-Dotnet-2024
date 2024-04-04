using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using Brani.Pages;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;





namespace Brani.Pages
{


    [Authorize(Roles = "User")]
    
    
    public class PlaylistModel : PageModel
    {

        public required IEnumerable<Brano> Playlists { get; set; }
        public string[]? arrayAudio { get; set; }
        public int lunghezzaArray { get; set; }
        


        private static readonly List<string> Tracks = new List<string>
        {

        };

        private static int CurrentTrackIndex = 0;

        public string CurrentTrack => Tracks[CurrentTrackIndex];



        public void OnGet() // LEGGE DA PLAYLIST E CREA UN ARRAY DI STRINGHE CHE PASSA I LINK AUDIO AL BOTTONE PER LA RIPRODUZIONE TOTALE
        {
            //string userName = User.Identity!.Name!;

            var json = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");

            
            Playlists = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            int i = 0;
            lunghezzaArray = 0;

            if (Playlists != null)
            {
                foreach (var brano in Playlists)
                {
                    lunghezzaArray++;
                }

                arrayAudio = new string[lunghezzaArray];
                foreach (var brano in Playlists)
                {
                    arrayAudio[i] = brano.Audio!;
                    i++;
                }
            }
        }

        public IActionResult OnPost(string action) // FUNZIONE TRACCIA SUCCESSIVA - TRACCIA PRECEDENTE
        {
            switch (action)
            {
                case "previous":
                    CurrentTrackIndex = (CurrentTrackIndex - 1 + Tracks.Count) % Tracks.Count;
                    break;
                case "next":
                    CurrentTrackIndex = (CurrentTrackIndex + 1) % Tracks.Count;
                    break;
            }

            // Restituisce la stessa pagina con il nuovo brano corrente
            return Page();
        }
    }
}