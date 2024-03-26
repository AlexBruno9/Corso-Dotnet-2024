using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using WebAppBrani.Pages;

namespace WebAppBrani.Pages
{
    public class PlaylistModel : PageModel
    {

        // private readonly ILogger<PlaylistModel> _logger;

        //  public PlaylistModel(ILogger<PlaylistModel> logger)
        //  {
        //      _logger = logger;
        // }



        public required IEnumerable<Brano> Playlists { get; set; }
        public string[]? arrayAudio { get; set; }
        public int lunghezzaArray{get;set;}




        private static readonly List<string> Tracks = new List<string>
        {
            // "https://guitarbackingtrack.org/wp-content/uploads/2023/05/Motley-Crue-Without-You-v3.mp3",
            // "https://guitarbackingtrack.org/wp-content/uploads/2023/05/Quo-Vadis-Silence-Calls-The-Storm.mp3",


            "https://guitarbackingtrack.org/wp-content/uploads/2023/05/Bon-Jovi-You-Give-Love-A-Bad-Name-v4.mp3",
            "https://guitarbackingtrack.org/wp-content/uploads/2023/05/Cheap-Trick-Surrender.mp3"
        };

        private static int CurrentTrackIndex = 0;

        public string CurrentTrack => Tracks[CurrentTrackIndex];



        public void OnGet()
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
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

        public IActionResult OnPost(string action)
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