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
        else
        {
            ArrayFoto![0] = "https://upload.wikimedia.org/wikipedia/en/thumb/7/74/Rubber_Soul.jpg/220px-Rubber_Soul.jpg";
            ArrayFoto![1] = "https://upload.wikimedia.org/wikipedia/en/thumb/f/fa/Bob_Dylan_-_Blood_on_the_Tracks.jpg/220px-Bob_Dylan_-_Blood_on_the_Tracks.jpg";
            ArrayFoto![2] = "https://m.media-amazon.com/images/I/51enUo6rwSL._UXNaN_FMjpg_QL85_.jpg";
            ArrayFoto![3] = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c2/BobMarley-Legend.jpg/220px-BobMarley-Legend.jpg";
            // ArrayFoto![4] = brano.Immagine!;
            // ArrayFoto![5] = brano.Immagine!;
        }


    }
}
