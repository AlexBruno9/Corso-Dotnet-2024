
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class AggiungiProdottoModel : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }

    [BindProperty]
    public string Codice { get; set; }

    [BindProperty]
    public List<string> Categorie { get; set; }
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(json);
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid || Codice != "1234")
        {
            var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Inserimento Prodotto", Errore = "Codice non valido" };
            var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
            var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
            logs.Add(log);
            System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
            return RedirectToPage("Error", new { message = "Codice non valido" });
            // return Page(); // Ritorna alla stessa pagina mostrando gli errori di validazione
        }
        else
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
            var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
            var id = prodotti.Any() ? prodotti.Max(p => p.Id) + 1 : 1;
            Prodotto.Id = id;
            prodotti.Add(Prodotto);
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
            var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Inserimento Prodotto", Errore = "" };
            var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
            var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
            logs.Add(log);
            System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
            return RedirectToPage("Prodotti");
        }
}
}
