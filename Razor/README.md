# RAZOR

Razor è una sintassi di markup per l'incorporamento di codice basato su .NET in pagine Web. La Razor sintassi è costituita da Razor markup, C# e HTML. I file contenenti in Razor genere hanno un'estensione di file.cshtml .

Razor serve per creare WebApp utilizzando Models, Pages (che comprende per ogni file una coppia di file - view e controller - ovvero .cshtml e .cshtml.cs)

- nelle view.cshtml puoi usare comandi c# ponendo una @ davanti al codice c#

# RAZOR

Razor è un motore di template di sintassi C# che consente di scrivere codice C# all'interno di file HTML. È stato introdotto con ASP.NET MVC 3 e da allora è diventato sempre più popolare per la sua semplicità e flessibilità.

Implementare test continui utilizzando il comando

```bash
dotnet watch run
```

## Sintassi

La sintassi di Razor è molto simile a quella di ASP.NET. È possibile scrivere codice C# all'interno di blocchi di codice @{ ... }`e scrivere espressioni C# all'interno di blocchi di codice`@...`.

I files creati con Razor hanno l'estensione `.cshtml`.

I blocchi di codice C# iniziano con @{ e terminano con `}`.

È possibile scrivere espressioni ed utilizzare le variabili C# all'interno di blocchi di codice @...`.

```bash
dotnet new razor -n WebAppProdotti
```

## Index.cshtml.cs

Index.cshtml.cs è una classe che eredita da PageModel e fornisce i dati alla pagina Index.cshtml. È possibile utilizzare IndexModel per fornire i dati alla pagina Index.cshtml

```csharp
using Microsoft.AspNetCore.Mvc; // IActionResult e Controller
using Microsoft.AspNetCore.Mvc.RazorPages; // PageModel
public class IndexModel : PageModel // IndexModel è una classe che eredita da PageModel
{
    private readonly ILogger<IndexModel> _logger; // _logger è un campo privato di tipo ILogger<IndexModel>
    // serve per registrare i messaggi di log relativi a IndexModel

    public IndexModel(ILogger<IndexModel> logger) // costruttore di IndexModel
    {
        _logger = logger;
    }

    public void OnGet() // metodo OnGet di IndexModel
    {

    }
}
```

Possiamo aggiungere funzionalità al metodo OnGet per fornire i dati alla pagina Index.cshtml

```csharp
public void OnGet()
{
    ViewData["Message"] = "Hello from Razor";
}
```

In questo modo stiamo assegnando un valore alla chiave "Message" del dizionario ViewData. Il messaggio verrà visualizzato nella pagina Index.cshtml tramite la sintassi @ViewData["Message"]
File: `index.cshtml`

```csharp
@page
@model IndexModel // IndexModel è il nome della classe del file Index.cshtml.cs
@{
    // la direttiva @page indica che la pagina è associata a un file Razor Page
    // la direttiva @model indica che la pagina è associata a una classe C# che fornisce i dati alla pagina
    // la direttiva @{} è usata per definire un blocco di codice C# all'interno di una pagina Razor
    // il modello di pagina IndexModel è definito nel file Index.cshtml.cs
    var nome = "Nome"; // dichiarazione di una variabile di tipo string
    var versione = 3; // dichiarazione di una variabile di tipo int
    ViewData["Title"] = "Home page"; // assegnazione di un valore alla chiave "Title" del dizionario ViewData
    ViewData["Message"] = "Hello from Razor"; // assegnazione di un valore alla chiave "Message" del dizionario ViewData
                                              // il messaggio verrà visualizzato nella pagina Index.cshtml tramite la sintassi @ViewData["Message"]
                                              // i class ai quali si riferisce sono di bootstrap e si trovano in wwwroot/lib/bootstrap/dist/css/bootstrap.css
                                              // nella pagina viene importato in automatico _layout.cshtml che a sua volta importa bootstrap.css e site.css
}
<div class="text-center">

    <h1 class="display-4">Benvenuto in Razor @nome</h1>

    <p>Versione: @versione</p>

    <p>@ViewData["Message"]</p>

</div>
```

## ViewBag

Razor consente di utilizzare le direttive. Le direttive sono istruzioni che vengono utilizzate per configurare le pagine web. È possibile utilizzare le direttive per definire il modello, includere file, definire namespace, ecc.
ViewBag è un oggetto dinamico che consente di passare dati tra il controller e la vista. È possibile utilizzare ViewBag per passare dati dalla vista al controller e viceversa.
In questo caso stiamo passando il titolo della pagina. È possibile utilizzare ViewBag per passare qualsiasi tipo di dati

    ViewBag.Title = "Prodotti"; // viewbag è una variabile che può essere usata in tutta la view e non solo in un blocco di codice come viewdata

```csharp
@{
    ViewBag.Title = "Prodotti";
    ViewBag.Message = "Benvenuto in Razor";
}
```

## Layout

Razor consente di creare layout per le pagine web. Un layout è un file che contiene la struttura di base di una pagina web. È possibile definire un layout e utilizzarlo in tutte le pagine web.

Di default viene utilizzato il layout `_Layout.cshtml` che si trova nella cartella `Views/Shared`.

@RenderBody() è un metodo che consente di visualizzare il contenuto della pagina web all'interno del layout

```csharp
<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    @RenderBody()
</body>
</html>
```

Per aggiungere al layout un link alla pagina Prodotto si può aggiungere il seguente codice al file \_Layout.cshtml

```csharp
<li class="nav-item">
    <a class="nav-link text-dark" asp-page="/Prodotto">Prodotto</a>
</li>
```

## Partials

Razor consente di creare viste parziali. Una vista parziale è un file che contiene una parte di una pagina web. È possibile definire una vista parziale e utilizzarla in tutte le pagine web

```csharp
@model IEnumerable<Prodotto>

<table>
    <tr>
        <th>Nome</th>
        <th>Prezzo</th>
    </tr>
    @foreach (var prodotto in Model)
    {
        <tr>
            <td>@prodotto.Nome</td>
            <td>@prodotto.Prezzo</td>
        </tr>
    }
</table>
```

Le viste parziali vengono utilizzate per creare componenti riutilizzabili. È possibile utilizzare le viste parziali per creare componenti come menu, barre laterali, intestazioni, piè di pagina, ecc.
Un esempio di utilizzo di una vista parziale è il menu. È possibile creare una vista parziale per il menu e utilizzarla in tutte le pagine web.
file `_Menu.cshtml`

```csharp

<ul>
    <li><a href="/">Home</a></li>
    <li><a href="/Prodotto">Prodotti</a></li>
</ul>
```

file `_Layout.cshtml`

```csharp
<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    <div>
        @Html.Partial("_Menu")
    </div>
    @RenderBody()
</body>
</html>
```

In questo modo stiamo utilizzando la vista parziale \_Menu.cshtml nel layout \_Layout.cshtml. È possibile utilizzare la vista parziale \_Menu.cshtml in tutte le pagine web.

## Helpers

Razor consente di creare helper. Un helper è un metodo che può essere utilizzato in una pagina web. È possibile definire un helper e utilizzarlo in tutte le pagine web.

```csharp
@helper Saluta(string nome)
{
    <p>Ciao @nome</p>
}
```

# WEB APP PRODOTTI

creare l'archetipo dell'applicazione

```bash
dotnet new razor -n CatalogoProdotti
```

## CREAZIONE DI UNA PAGINA DI PRODOTTI

- 1

Innanzitutto creiamo un modello di prodotto definito nel file `Prodotto.cs` nella cartella `Models`

Il modello si occupa di definire la struttura dei dati che verranno visualizzati nelle pagine web.

In questo caso, il modello di prodotto definisce la struttura di un prodotto, che ha un nome e un prezzo.

- 2  
  Adesso possiamo creare il modello di pagina `ProdottoModel` definito nel file `Prodotto.cshtml.cs` nella cartella `Pages`

Il modello di pagina si occupa di fornire i dati alla pagina web. In questo caso, il modello di pagina `ProdottoModel` fornisce i dati alla pagina web `Prodotto.cshtml`.

- 3

Adesso possiamo creare la view `Prodotto` definita nel file `Prodotto.cshtml` nella cartella `Pages`
La view si occupa di visualizzare i dati forniti dal modello di pagina. In questo caso, la view `Prodotto` visualizza i dati forniti dal modello di pagina `ProdottoModel`.

La pagina ha un metodo OnGet che fornisce i dati alla pagina web. Il metodo OnGet interviene quando la pagina viene richiesta. Il metodo OnGet fornisce i dati alla pagina web tramite la proprietà Prodotti. La proprietà Prodotti è di tipo IEnumerable<Prodotto> e contiene una sequenza di prodotti. La sequenza di prodotti viene visualizzata nella pagina web tramite un ciclo foreach.

Aggiungere al layout un link alla pagina Prodotto si può aggiungere il seguente codice al file \_Layout.cshtml

## AGGIUNTA DI CAMPI

Adesso possiamo aggiungere campi al modello di prodotto e visualizzarli nella pagina web

Aggiungiamo i campi al modello di pagina e visualizziamoli nella pagina web
La rotta delle immagini è `wwwroot/img/immagine1.jpg`

## AGGIUNGERE LOGGING

Il logging permette di registrare i messaggi di log relativi all'applicazione. È possibile utilizzare il logging per registrare i messaggi di log relativi al modello di pagina.

Bisogna aggiuungere questo codice al file `Prodotti.cshtml.cs`

```csharp
private readonly ILogger<IndexModel> _logger; // _logger è un campo privato di tipo ILogger<IndexModel>
    // serve per registrare i messaggi di log relativi a IndexModel

    public IndexModel(ILogger<IndexModel> logger) // costruttore di IndexModel
    {
        _logger = logger;
    }
```

A questo punto è possibile stampare i messaggi di log relativi al modello di pagina

```csharp
_logger.LogInformation("Prodotti caricati");
```

## AGGIUNGERE UNA PAGINA DI DETTAGLIO PRODOTTO

A questo punto bisogna aggiungere un link alla pagina di dettaglio prodotto nella pagina di prodotti così:

Dobbiamo essere sicuri di passare tutti i parametri necessari alla pagina di dettaglio prodotto. In questo caso, stiamo passando l'id, il nome, il prezzo, il dettaglio e l'immagine del prodotto.

In questo modo i parametri vengono passati alla pagina di dettaglio prodotto tramite la rotta.

## AGGIUNTA FILTRO PER PREZZO

Innanzitutto dobbiamo aggiungere gli argomenti al metodo OnGet del modello di pagina `ProdottiModel` per filtrare i prodotti per prezzo

## AGGIUNTA PAGINAZIONE

E' possobile aggiungere la paginazione alla pagina di prodotti. In questo modo è possibile visualizzare un numero specificato di prodotti per pagina.

Per prima cosa dobbiamo aggiungere l'argomento pageIndex al metodo OnGet del modello di pagina `ProdottiModel` per calcolare l'indice della pagina così:

file `Prodotti.cshtml.cs`

```csharp
public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex) // aggiunta di parametri per i filtri
```

Poi possiamo aggiungere la paginazione alla pagina di prodotti così:

```csharp

public int numeroPagine { get; set; } // aggiunta di una proprietà per il numero di pagine

numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0); // calcola il numero di pagine
Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6); // esegue la paginazione
```

Adesso possiamo aggiungere la paginazione alla pagina di prodotti così:

file `Prodotti.cshtml`

```csharp
<form method="get">
    <input type="hidden" name="minPrezzo" value="@Request.Query["minPrezzo"]" /> <!-- per mantenere il valore del filtro -->
    <input type="hidden" name="maxPrezzo" value="@Request.Query["maxPrezzo"]" /> <!-- per mantenere il valore del filtro -->
    @for (int i = 1; i <= Model.numeroPagine; i++)
    {
        <button type="submit" class="btn btn-dark" name="pageIndex" value="@i">@i</button>
    }
</form>
<br>
```

## DATI PRODOTTI PRESI DA JSON

comando dotnet installa newtonsoft.json

```bash
dotnet add package Newtonsoft.Json
```

E possibile utilizzare un file json per memorizzare i dati dei prodotti. In questo modo è possibile leggere i dati dal file json e fornirli alla pagina web.

Il vantaggio è che non dobbiamo passare i dati alla pagina di dettaglio, in quanto i dati sono già presenti nel file json.

file ProdottoDettaglio.cshtml.cs

Possiamo passare l'argomento Id al metodo OnGet del modello di pagina ProdottoDettaglioModel così:

```csharp
public void OnGet(int id)
{
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotto = prodotti.FirstOrDefault(p => p.Id == id);
}
```

prodotti.json sarà in wwwroot

A questo punto non è più necessario passare i dati alla pagina di dettaglio, in quanto i dati sono già presenti nel file json

I link alla pagina di dettaglio devono essere modificati in modo che l'id del prodotto venga passato alla pagina di dettaglio

file `Prodotti.cshtml`

```csharp
<td><a asp-page="ProdottoDettaglio" asp-route-id="@item.Id">Dettaglio</a></td>
```

Anche la pagina prodotti può essere modificata per utilizzare i dati del file json

file `Prodotti.cshtml.cs`

```csharp
public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
{
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotti = prodotti;
    numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 6.0);
    Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 6).Take(6);
}
```

## SALVARE FILES JSON IDENTATI

Per rendere più leggibile il file json, è possibile salvare i file json identati.

file `AggiungiProdotto.cshtml.cs`:
file `ModificaProdotto.cshtml.cs`:
file `CancellaProdotto.cshtml.cs`:

```csharp

System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));

```

## AGGIUNGI PAGINA LOG

Aggiunta di una pagina di log dove si veda l'elenco delle operazioni eseguite di inserimento, modifica ed eliminazione di prodotti con data e ora ed errori di inserimento, modifica ed eliminazione di prodotti con data e ora

Log vengono salvati in un file `log.json` ed utilizzati per visualizzare l'elenco delle operazioni eseguite

file `Log.cs`

```csharp
public class Log
{
    public string Data { get; set; }
    public string Ora { get; set; }
    public string Operazione { get; set; }
    public string Errore { get; set; }
}
```

file `Log.cshtml`:

```html
@page @model LogModel @{ ViewData["Title"] = "Log"; }

<h1>@ViewData["Title"]</h1>

<table class="table">
  <thead>
    <tr>
      <th>Data</th>
      <th>Ora</th>
      <th>Operazione</th>
      <th>Errore</th>
    </tr>
  </thead>
  <tbody>
    @foreach (var log in Model.Logs) {
    <tr>
      <td>@log.Data</td>
      <td>@log.Ora</td>
      <td>@log.Operazione</td>
      <td>@log.Errore</td>
    </tr>
    }
  </tbody>
</table>
```

file `Log.cshtml.cs`:

```csharp
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public class LogModel : PageModel
{
    public List<Log> Logs { get; set; }
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/log.json");
        Logs = JsonConvert.DeserializeObject<List<Log>>(json);
    }
}
```

file `AggiungiProdotto.cshtml.cs`:

```csharp
var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Inserimento Prodotto", Errore = "" };
var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
logs.Add(log);
System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
```

file `ModificaProdotto.cshtml.cs`:

```csharp
var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Modifica Prodotto", Errore = "" };
var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
logs.Add(log);
System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
```

file `CancellaProdotto.cshtml.cs`:

```csharp
var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Cancellazione Prodotto", Errore = "" };
var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
logs.Add(log);
System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
```

aggiungere il messaggio di errore al log in caso di errore di inserimento, modifica ed eliminazione di prodotti

file `AggiungiProdotto.cshtml.cs`:

```csharp
if (Codice != "1234")
{
    var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Inserimento Prodotto", Errore = "Codice non valido" };
    var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
    var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
    logs.Add(log);
    System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
    return RedirectToPage("Error", new { message = "Codice non valido" });
}
else
{
    var log = new Log { Data = DateTime.Now.ToString("dd/MM/yyyy"), Ora = DateTime.Now.ToString("HH:mm:ss"), Operazione = "Inserimento Prodotto", Errore = "" };
    var jsonLog = System.IO.File.ReadAllText("wwwroot/json/log.json");
    var logs = JsonConvert.DeserializeObject<List<Log>>(jsonLog);
    logs.Add(log);
    System.IO.File.WriteAllText("wwwroot/json/log.json", JsonConvert.SerializeObject(logs, Formatting.Indented));
    return RedirectToPage("Prodotti");
}
```

file `ModificaProdotto.cshtml.cs`:

```csharp
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
```

file `CancellaProdotto.cshtml.cs`:

```csharp
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
```

file `log.json`

```json
[
  {
    "Data": "01/01/2021",
    "Ora": "10:00:00",
    "Operazione": "Inserimento Prodotto",
    "Errore": ""
  },
  {
    "Data": "01/01/2021",
    "Ora": "10:00:00",
    "Operazione": "Modifica Prodotto",
    "Errore": ""
  },
  {
    "Data": "01/01/2021",
    "Ora": "10:00:00",
    "Operazione": "Cancellazione Prodotto",
    "Errore": ""
  }
]
```

aggiungi il link in `_layout.cshtml`

```csharp
<a asp-page="Log" class="nav-link text-dark">Log</a>
```

## AGGIUNGI CAMPI FORM OBBLIGATORI
