
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class ModificaProdottoModel : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }
    [BindProperty]
    public string Codice { get; set; }
    public List<string> Categorie { get; set; }
    public void OnGet(int Id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
        var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
        Prodotto = prodotti.FirstOrDefault(p => p.Id == Id);

        var jsonCategorie = System.IO.File.ReadAllText("wwwroot/json/categorie.json");
        Categorie = JsonConvert.DeserializeObject<List<string>>(jsonCategorie);
    }
    public IActionResult OnPost(int Id)
    {
        if (Codice != "1234")
        {
            var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Modifica Prodotto", Errore = "Codice non valido" };
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
            var prodotto = prodotti.FirstOrDefault(p => p.Id == Id);
            prodotto.Id = Id;
            prodotto.Nome = Prodotto.Nome;
            prodotto.Prezzo = Prodotto.Prezzo;
            prodotto.Dettaglio = Prodotto.Dettaglio;
            prodotto.Immagine = Prodotto.Immagine;
            prodotto.Quantita = Prodotto.Quantita;
            prodotto.Categoria = Prodotto.Categoria;
            System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
            var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Modifica Prodotto", Errore = "" };
            var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
            var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
            logs.Add(log);
            System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
            return RedirectToPage("Prodotti");
        }
    }
}
