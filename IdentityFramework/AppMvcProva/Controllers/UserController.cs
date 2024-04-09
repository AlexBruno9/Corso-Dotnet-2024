using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppMvcProva.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AppMvcProva.Controllers;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<UserController> _logger;

    // public UserController(ILogger<UserController> logger, UserManager<AppUser> userManager)
    // {
    //     _logger = logger;
    //     _userManager = userManager;
    // }

    public async Task<IActionResult> Index()
    {
        //memorizzo l'Utente attuale
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            //creo un ViewBag per inviare l'Alias alla index
            ViewBag.Alias = user!.NomeProfilo;
        }

        //log che visualizza la pagina selezionata
        // _logger.LogInformation("Index - PageIndex: {0}", pageIndex);

        // Inizializza gli attributi di classe nel modello
        // var model = new IndexViewModel
        // {
        //     PageIndex = pageIndex,
        //     Categoria = categoria
        // };

        // Calcola il numero di pagine e la paginazione
        // model.NumeroPagine = (int)Math.Ceiling((double)model.Immagini.Count() / 12);
        // model.Immagini = model.Immagini.Skip(((pageIndex ?? 1) - 1) * 12).Take(12).ToList();

        return View("/Home/Index");
        // return View("/Home/Index", model);
    }

  
    // [HttpPost]
    // public IActionResult Immagine()
    // {
    //     var model = new ImmagineViewModel { };
      
    //     return View(model);
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}