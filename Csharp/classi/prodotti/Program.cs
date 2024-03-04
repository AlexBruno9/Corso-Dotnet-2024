

class Ordine
{
    public int Id {get;set;}
    public int ProdottoId {get; set;}
    public Prodotto Prodotto {get; set;}
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti {get; set;}
}


public void InserisciOrdini

public void StampaOrdini()
{
    var ordini = Ordini.Include(o=>o.Prodotto).ThenInclude (p=>p.Cliente).ToList();
    foreach (var o in ordini)
    {
        Console.Writeline($"{o.Id} - {o.Prodotto.Nome} - {o.Prodotto.Cliente.Nome} {o.Prodotto.Cliente.Nome.Cognome}")
    }
}
















