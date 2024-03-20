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
        public void OnGet(int? pageIndex)
        {
            var json = System.IO.File.ReadAllText("wwwroot/json/Brani.json");
            Brani = JsonConvert.DeserializeObject<List<Brano>>(json)!;



/*
            //  AGGIUNTA IMPAGINAZIONE

            numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 3.0);
            Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1) * 3).Take(3);
*/
 
        }
    }
}