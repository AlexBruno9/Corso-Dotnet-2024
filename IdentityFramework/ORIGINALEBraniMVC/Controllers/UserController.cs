using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BraniMVC.Models;
using BraniMVC.Data;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BraniMVC.Controllers;

[Authorize(Roles = "User")]
public class UserController : Controller
{


    private readonly ILogger<HomeController> _logger;


    public UserController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

  
    [HttpGet]
    public IActionResult Playlist() // LEGGE DA PLAYLIST E CREA UN ARRAY DI STRINGHE CHE PASSA I LINK AUDIO AL BOTTONE PER LA RIPRODUZIONE TOTALE
    {

        Playlist model = new PlaylistModel { };

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

    // [HttpPost]
    // public IActionResult Playlist(string action) // FUNZIONE TRACCIA SUCCESSIVA - TRACCIA PRECEDENTE
    // {

    //     PlaylistModel model = new PlaylistModel() { };

    //     switch (action)
    //     {
    //         case "previous":
    //             model.CurrentTrackIndex = (model.CurrentTrackIndex - 1 + model.Tracks.Count) % model.Tracks.Count;
    //             break;
    //         case "next":
    //             model.CurrentTrackIndex = (model.CurrentTrackIndex + 1) % model.Tracks.Count;
    //             break;
    //     }

    //     // Restituisce la stessa pagina con il nuovo brano corrente
    //     return RedirectToAction("Playlist", "User");
    // }



    [HttpGet]
    public IActionResult BranoDettaglioPlaylist(int id)
    {
        Brano model = new Brano { };

        var json = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
        var brani = JsonConvert.DeserializeObject<List<Brano>>(json);
        model = brani!.FirstOrDefault(p => p.Id == id)!;

        return View(model);

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


    [HttpGet]
    public IActionResult RimuoviDaPlaylist(int id)
    {
        Brano model = new Brano { };

        var json = System.IO.File.ReadAllText($"wwwroot/json/Playlist/{User.Identity!.Name!}.json");
        var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
        model = brani.FirstOrDefault(p => p.Id == id)!;

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


}

