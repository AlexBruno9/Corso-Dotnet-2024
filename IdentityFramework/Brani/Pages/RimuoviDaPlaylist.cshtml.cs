using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Brani.Pages
{
    public class RimuoviDaPlaylistModel : PageModel
    {

        public Brano? Brano {get;set;}

     

        public void OnGet(int id)
        {
            var json = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
            var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
            Brano=brani.FirstOrDefault(p=>p.Id==id);
   
        }

        public IActionResult OnPost(int[] selezionatiBrani) // RIMUOVE I BRANI SELEZIONATI DALLA PLAYLIST
        {
            
            var jsonBrani = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
            var tuttiBrani = JsonConvert.DeserializeObject<List<Brano>>(jsonBrani) ?? new List<Brano>();

            var braniDaEliminare = tuttiBrani.Where(brano => selezionatiBrani.Contains(brano.Id)).ToList();

            foreach(var brano in braniDaEliminare)
            {
            tuttiBrani.Remove(brano);
            }

            System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", JsonConvert.SerializeObject(tuttiBrani, Formatting.Indented));

            return RedirectToPage("Playlist");
        }

    }
}