using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppProdotti.Models;

namespace WebAppProdotti.Pages
{
    public class ClienteDettaglioModel : PageModel
    {
        public Cliente? Cliente { get; set; }
        public void OnGet(string nome, string cognome, int eta, int nacquisti, string cf)
        {
            Cliente = new Cliente { Nome = nome, Cognome=cognome, Eta=eta, N_Acquisti=nacquisti, CF=cf };
        }
    }
}