using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

using WebAppBrani.Pages;

namespace WebAppBrani.Pages
{
    public class BranoModel : PageModel
    {

        private readonly ILogger<BranoModel> _logger;

        public BranoModel(ILogger<BranoModel> logger)
        {
            _logger = logger;
        }

        public required IEnumerable<Brano> Brani { get; set; }
        public int numeroPagine { get; set; }
        public string? FiltroArtista { get; set; }
        public string? FiltroTitolo { get; set; }
        public void OnGet(string cercaArtista, string cercaTitolo, int? pageIndex) // FILTRA BRANI PER NOME ARTISTA E TITOLO BRANO
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            Brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;

            if (!string.IsNullOrEmpty(cercaArtista))
            {
                Brani = Brani.Where(p => p.Artista == cercaArtista);
                FiltroArtista = $"Filtro attivo - ricerca per artista: '{cercaArtista}'";
            }
            if (!string.IsNullOrEmpty(cercaTitolo))
            {
                Brani = Brani.Where(p => p.Titolo == cercaTitolo);
                FiltroTitolo = $"Filtro attivo - ricerca per titolo brano: '{cercaTitolo}'";
            }

            numeroPagine = (int)Math.Ceiling(Brani.Count() / 10.0);
            Brani = Brani.Skip(((pageIndex ?? 1) - 1) * 10).Take(10);
        }
    }
}