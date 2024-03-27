using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebAppBrani.Pages;

public class IndexModel : PageModel
{
public required IEnumerable<Brano> Brani { get; set; }
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
        Brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
        
    }
}
