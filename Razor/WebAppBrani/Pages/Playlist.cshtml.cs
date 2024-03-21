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

        private readonly ILogger<PlaylistModel> _logger;

        public PlaylistModel(ILogger<PlaylistModel> logger)
        {
            _logger = logger;
        }



        public required IEnumerable<Brano> Playlists { get; set; }
        public void OnGet()
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            Playlists = JsonConvert.DeserializeObject<List<Brano>>(json)!;

        }
    }
}