using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class LogModel : PageModel
{
    public List<Log> Logs { get; set; }
    public int numeroPagine { get; set; }
    public void OnGet(int? pageIndex)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/log.json");
        Logs = JsonConvert.DeserializeObject<List<Log>>(json);
        Logs = Logs.OrderByDescending(l => l.Data).ThenByDescending(l => l.Ora).ToList();
        numeroPagine = (int)Math.Ceiling(Logs.Count() / 16.0);
        Logs = Logs.Skip(((pageIndex ?? 1) - 1) * 16).Take(16).ToList();
    }
}