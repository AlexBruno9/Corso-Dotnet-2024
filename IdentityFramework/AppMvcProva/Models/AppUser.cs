using Microsoft.AspNetCore.Identity;

namespace AppMvcProva.Models;

#nullable disable
public class AppUser : IdentityUser
{
    //aggiungo le proprietà per l'utente in fase di registrazione
    public string NomeProfilo { get; set; }
    public string[] Accounts { get; set; }

}