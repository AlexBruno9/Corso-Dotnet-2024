using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BraniMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace BraniMVC.Controllers;

public class HomeController : Controller
{



    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    public IActionResult Index()
    {

        IndexViewModel model = new IndexViewModel { };

        if (User.IsInRole("User"))
        {
            if (!System.IO.File.Exists($"wwwroot/json/Playlist/{User.Identity!.Name!}.json"))
            {

                System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", " ");
            }
        }

        var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
        model.Brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;



        int index = 0;

        if (model.Brani != null)
        {

            foreach (var brano in model.Brani)
            {
                index++;
            }

            model.ArrayFoto = new string[index];
            int i = 0;
            foreach (var brano in model.Brani)
            {
                model.ArrayFoto![i] = brano.Immagine!;
                i++;
            }
        }
        else    //  IN CASO NON CI SIANO BRANI MEMORIZZATI E QUINDI NESSUNA IMMAGINE CHE RIEMPE L'ARRAY 
        {
            model.ArrayFoto = new string[8];
            model.ArrayFoto![0] = "https://upload.wikimedia.org/wikipedia/en/thumb/7/74/Rubber_Soul.jpg/220px-Rubber_Soul.jpg";
            model.ArrayFoto![1] = "https://upload.wikimedia.org/wikipedia/en/thumb/f/fa/Bob_Dylan_-_Blood_on_the_Tracks.jpg/220px-Bob_Dylan_-_Blood_on_the_Tracks.jpg";
            model.ArrayFoto![2] = "https://m.media-amazon.com/images/I/51enUo6rwSL._UXNaN_FMjpg_QL85_.jpg";
            model.ArrayFoto![3] = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c2/BobMarley-Legend.jpg/220px-BobMarley-Legend.jpg";
            model.ArrayFoto![4] = "https://upload.wikimedia.org/wikipedia/en/thumb/1/18/EarthWindAndFireSeptember7InchSingleCover.jpg/220px-EarthWindAndFireSeptember7InchSingleCover.jpg";
            model.ArrayFoto![5] = "https://upload.wikimedia.org/wikipedia/en/8/84/MarvinGayeWhat%27sGoingOnalbumcover.jpg";
            model.ArrayFoto![6] = "https://upload.wikimedia.org/wikipedia/en/5/55/Michael_Jackson_-_Thriller.png";
            model.ArrayFoto![7] = "https://upload.wikimedia.org/wikipedia/en/1/19/Dr.DreTheChronic.jpg";
        }

        return View(model);
    }

    public IActionResult Privacy()
    {

        return View();
    }


    //[Authorize(Roles = "User, Admin")]
    [Authorize]
    [HttpGet]
    public IActionResult Brani(string cercaArtista, string cercaTitolo, int? pageIndex)
    {
        BraniViewModel model=new BraniViewModel{};

        model.PageIndex = pageIndex;
        var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
        model.Brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;


        if (!string.IsNullOrEmpty(cercaArtista))
        {
            model.Brani = model.Brani.Where(b => b.Artista!.Contains(cercaArtista, StringComparison.CurrentCultureIgnoreCase)).ToList();
            model.FiltroArtista = $"Filtro attivo - ricerca per artista: '{cercaArtista}'";
        }
        if (!string.IsNullOrEmpty(cercaTitolo))
        {
            model.Brani = model.Brani.Where(b => b.Titolo!.Contains(cercaTitolo, StringComparison.CurrentCultureIgnoreCase)).ToList();
            model.FiltroTitolo = $"Filtro attivo - ricerca per titolo brano: '{cercaTitolo}'";
        }

        if (model.Brani != null)
        {

            model.numeroPagine = (int)Math.Ceiling(model.Brani.Count() / 10.0);
            model.Brani = model.Brani.Skip(((pageIndex ?? 1) - 1) * 10).Take(10);
        }

        return View(model);

    }


    
    [Authorize]
    [HttpGet]
    public IActionResult BranoDettaglio(int id) // LEGGE I BRANI PRESENTI NEL CATALOGO
    {
        BranoDettaglioViewModel model = new BranoDettaglioViewModel { };


        var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
        var brani = JsonConvert.DeserializeObject<List<Brano>>(json);
        model.Brano = brani!.FirstOrDefault(p => p.Id == id)!;

        return View(model);

    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}


