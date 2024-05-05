using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class CancellaProdottoModel : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }
    [BindProperty]
    public string Codice { get; set; }
    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto = prodotti.FirstOrDefault(p => p.Id == id);
    }
    public IActionResult OnPost(int id)
    {
        if (Codice != "1234")
{
    var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Cancellazione Prodotto", Errore = "Codice non valido" };
    var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
    var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
    logs.Add(log);
    System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
    return RedirectToPage("Error", new { message = "Codice non valido" });
}
else
{
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    prodotti = prodotti.Where(p => p.Id != id).ToList();
    System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
    var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Cancellazione Prodotto", Errore = "" };
    var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
    var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
    logs.Add(log);
    System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
    return RedirectToPage("Prodotti");
}
    }
}