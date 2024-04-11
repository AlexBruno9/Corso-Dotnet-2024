using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    // Aggiungi qui le proprietà personalizzate per i fornitori
    public string? Nome { get; set; }
    public string? Codice { get; set; }
    public bool Stato { get; set; }
}

// è un model (classe) aka gli utenti avranno questi campi