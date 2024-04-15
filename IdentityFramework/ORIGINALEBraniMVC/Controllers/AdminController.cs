using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BraniMVC.Models;
using BraniMVC.Data;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[Authorize(Roles = "Admin")]

public class AdminController : Controller
{

	private readonly ILogger<AdminController> _logger;


	public AdminController(ILogger<AdminController> logger)
	{
		_logger = logger;
	}

	public required IEnumerable<string> Genere { get; set; }


	[HttpGet]
	public IActionResult AggiungiBrano()
	{

		Brano model = new Brano { };

		string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/Generi.json");
		string jsonText = System.IO.File.ReadAllText(path);
		var generiList = JsonConvert.DeserializeObject<List<string>>(jsonText);
		model.GenereLista = generiList!;


		return View(model);
	}


	
	[HttpPost]
	public IActionResult AggiungiBrano(string titolo, string artista, int anno, string genere, string durata, string immagine, string audio)
	{
		Brano model = new Brano { };

		var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
		var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

		int id = brani.Max(b => b.Id);
		id++;

		brani.Add(new Brano { Titolo = titolo, Artista = artista, Anno = anno, Immagine = immagine, Id = id, Genere = genere, Audio = audio, Durata = durata });
		// salva il file json formattato
		System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));
		return RedirectToAction("Brano", "Home");
	}

	


	[HttpPost]
	public IActionResult RimuoviBrani(int[] selezionatiBrani) // RIMUOVE I BRANI SELEZIONATI NELLE CHECKBOX DAL CATALOGO
	{

		var jsonBrani = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
		var tuttiBrani = JsonConvert.DeserializeObject<List<Brano>>(jsonBrani) ?? new List<Brano>();

		var braniDaEliminare = tuttiBrani.Where(brano => selezionatiBrani.Contains(brano.Id)).ToList();

		foreach (var brano in braniDaEliminare)
		{
			tuttiBrani.Remove(brano);
		}

		System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(tuttiBrani, Formatting.Indented));

		return RedirectToAction("Brano", "Home");

	}


	[HttpGet]

	public IActionResult RimuoviBrano(int id)
	{
		Brano model = new Brano { };

		var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
		var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
		model = brani.FirstOrDefault(p => p.Id == id)!;
		
		return View(model);
	}



	// ELIMINA IL SINGOLO BRANO DAL CATALOGO QUANDO SI ELIMINA DALLA PAGINA DI DETTAGLIO DEL BRANO

	[HttpPost]
	public IActionResult RimuoviBrano(int id, int bho)
	{
		// Brano model = new Brano { };

		var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
		var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
		var list = brani.FirstOrDefault(p => p.Id == id);
		brani.Remove(list!);

		System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));

		return RedirectToAction("Brano", "Home");

	}



	[HttpGet]

	public IActionResult ModificaBrano(int id) // LETTURA BRANI E GENERI PER MODIFICARE IL BRANO
	{

		Brano model = new Brano { };

		var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
		var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
		model = brani.FirstOrDefault(p => p.Id == id)!;

		string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/Generi.json");
		string jsonText = System.IO.File.ReadAllText(path);
		var generiList = JsonConvert.DeserializeObject<List<string>>(jsonText);
		model.GenereLista = generiList!;

		// return RedirectToAction("Brano", "Home");
		return View(model);


	}



	[HttpPost]

	public IActionResult ModificaBrano(int id, string titolo, string artista, int anno, string immagine, string genere, string durata) // SALVA LE MODIFICHE
	{
		var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
		var brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;
		var Brano = brani.FirstOrDefault(p => p.Id == id);
		Brano!.Titolo = titolo;
		Brano!.Artista = artista;
		Brano!.Anno = anno;
		Brano!.Immagine = immagine;
		Brano!.Genere = genere;
		Brano!.Durata = durata;

		System.IO.File.WriteAllText("wwwroot/json/Brani.json", JsonConvert.SerializeObject(brani, Formatting.Indented));


		return RedirectToAction("Brano", "Home");
		//	FORSE FARE CHE TORNI ALLA PAGE BRANODETTAGLIO MODIFICATA
	}


}