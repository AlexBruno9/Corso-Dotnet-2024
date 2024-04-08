using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Brani.Pages;

public class IndexModel : PageModel
{
    public required IEnumerable<Brano> Brani { get; set; }
    public string[]? ArrayFoto { get; set; }

    public void OnGet()
    {
        if (User.IsInRole("User"))
        {
            if (!System.IO.File.Exists($"wwwroot/json/Playlist/{User.Identity!.Name!}.json"))
            {

                System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", " ");
            }
        }

        var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
        Brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;



        int index = 0;

        if (Brani != null)
        {

            foreach (var brano in Brani)
            {
                index++;
            }

            ArrayFoto = new string[index];
            int i = 0;
            foreach (var brano in Brani)
            {
                ArrayFoto![i] = brano.Immagine!;
                i++;
            }
        }


    }
}
