using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public string? Cell { get; set; }

    public List<Prodotto>? Prodotti { get; set; }       //relazione uno a molti con la tabella prodotti

}

class Prodotto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }        // relazione con la tabella clienti

}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }  //DbSet rapresenta una tabella del database in memoria

    public DbSet<Prodotto> Prodotti { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //configura del database in memoria
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");  
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);      //addRange aggiunge una lista di clienti al database
        SaveChanges();
    }

    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);      //addRange aggiunge una lista di clienti al database
        SaveChanges();
    }


    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} {c.Cell}");    //stampa tutti
            foreach (var p in c.Prodotti!)
            {
                Console.WriteLine($"{p.Id} - {p.Nome} {p.Prezzo}");
            }
        }
    }

    public void StampaProdotti()
    {
        var prodotti = Prodotti.ToList();

        foreach (var p in prodotti)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente!.Nome} {p.Cliente.Cognome}");
        }
    }
    

}



class Program
{
    static void Main(string[] args)
    {

        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Cell = "3342218552" },
                new Cliente { Nome = "Marione", Cognome = "Rossini", Cell = "3342218558" },
                new Cliente { Nome = "Marion", Cognome = "Rossin", Cell = "3342218555" }
            };




            db.InserisciClienti(clienti);
            //db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo=10, ClienteId=1 },
                new Prodotto { Nome = "Prodotto 2", Prezzo=5, ClienteId=1 },
                new Prodotto { Nome = "Prodotto 3", Prezzo=110, ClienteId=2 },
                new Prodotto { Nome = "Prodotto 4", Prezzo=50, ClienteId=2 },
                new Prodotto { Nome = "Prodotto 5", Prezzo=5, ClienteId=3 },
                new Prodotto { Nome = "Prodotto 6", Prezzo=110, ClienteId=3 }
            };



            Console.WriteLine("\nprodotti per clienti");
            db.InserisciProdotti(prodotti);
            //db.StampaProdotti();
            

        }

    }



}