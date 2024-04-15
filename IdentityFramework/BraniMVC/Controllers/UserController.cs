using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BraniMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace BraniMVC.Controllers;

public class UserController : Controller
{

    private readonly ILogger<HomeController> _logger;


    public UserController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize(Roles = "User")]
    [HttpGet]
    // LEGGE DA PLAYLIST E CREA UN ARRAY DI STRINGHE CHE PASSA I LINK AUDIO AL BOTTONE PER LA RIPRODUZIONE TOTALE
    public IActionResult Playlist()
    {
        PlaylistViewModel model = new PlaylistViewModel { };

        var json = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");


        model.Playlists = JsonConvert.DeserializeObject<List<Brano>>(json)!;

        int i = 0;
        model.lunghezzaArray = 0;

        if (model.Playlists != null)
        {
            foreach (var brano in model.Playlists)
            {
                model.lunghezzaArray++;
            }

            model.arrayAudio = new string[model.lunghezzaArray];
            foreach (var brano in model.Playlists)
            {
                model.arrayAudio[i] = brano.Audio!;
                i++;
            }
        }
        return View(model);
    }

    [Authorize(Roles = "User")]
    [HttpGet]
    public IActionResult RimuoviDaPlaylist(int id)
    {
        RimuoviDaPlaylistViewModel model = new RimuoviDaPlaylistViewModel { };
        var json = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
        var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
        model.Brano = brani.FirstOrDefault(p => p.Id == id);

        return View(model);
    }


    [HttpPost]
    public IActionResult RimuoviDaPlaylist(int[] selezionatiBrani) // RIMUOVE I BRANI SELEZIONATI DALLA PLAYLIST
    {


        var jsonBrani = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
        var tuttiBrani = JsonConvert.DeserializeObject<List<Brano>>(jsonBrani) ?? new List<Brano>();

        var braniDaEliminare = tuttiBrani.Where(brano => selezionatiBrani.Contains(brano.Id)).ToList();

        foreach (var brano in braniDaEliminare)
        {
            tuttiBrani.Remove(brano);
        }

        System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", JsonConvert.SerializeObject(tuttiBrani, Formatting.Indented));

        return RedirectToAction("Playlist", "User");
    }


    
     [HttpPost]
    public IActionResult AggiungiAPlaylist(int[] selezionatiBrani, string titolo)  // AGGIUNGE I BRANI SELEZIONATI ALLA PLAYLIST
    {
        var jsonBrani = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
        var tuttiBrani = JsonConvert.DeserializeObject<List<Brano>>(jsonBrani) ?? new List<Brano>();

        var braniDaAggiungere = tuttiBrani.Where(brano => selezionatiBrani.Contains(brano.Id)).ToList();


        var jsonPlaylist = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
        int counter = 0;


        if (string.IsNullOrWhiteSpace(jsonPlaylist))
        {

            var playlist = new List<Brano>();


            foreach (var brano in braniDaAggiungere)
            {

                counter++;
                brano.Id = counter;

            }

            playlist!.AddRange(braniDaAggiungere);
            System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));
        }
        else if (!string.IsNullOrWhiteSpace(jsonPlaylist))
        {
            var playlist = JsonConvert.DeserializeObject<List<Brano>>(jsonPlaylist);



            foreach (var brano in playlist!)
            {
                counter++;
            }

            foreach (var brano in braniDaAggiungere)
            {

                counter++;
                brano.Id = counter;

            }


            playlist!.AddRange(braniDaAggiungere);
            System.IO.File.WriteAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json", JsonConvert.SerializeObject(playlist, Formatting.Indented));
        }

        return RedirectToAction("Playlist", "User");
    }



}