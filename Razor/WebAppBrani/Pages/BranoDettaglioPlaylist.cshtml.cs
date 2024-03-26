using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebAppBrani.Pages
{
    public class BranoDettaglioPlaylistModel : PageModel
    {
        public Brano? Brano { get; set; }
        public void OnGet(int id)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Playlist.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json);
            Brano = brani!.FirstOrDefault(p => p.Id == id);
        }
    }
}