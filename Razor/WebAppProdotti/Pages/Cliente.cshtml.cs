using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ClienteModel : PageModel
    {
        public required IEnumerable<Cliente> Clienti { get; set; }
        public void OnGet()
        {

            var json = System.IO.File.ReadAllText("wwwroot/json/clienti.json");
            Clienti = JsonConvert.DeserializeObject<List<Cliente>>(json)!;


            /*
            Clienti = new List<Cliente>
            {
                new Cliente { Nome = "Alex", Cognome="Bruno", Eta=25, N_Acquisti=4, CF="12345678" },
                new Cliente { Nome = "Simone", Cognome="Ussi", Eta=35, N_Acquisti=41, CF="92345678"},
                new Cliente { Nome = "Fabio", Cognome="Andora", Eta=25, N_Acquisti=12, CF="02345678" }
            };
            */
        }
    }
}