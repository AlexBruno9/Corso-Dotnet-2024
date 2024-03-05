using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

class Artista
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    public List<Disco>? Dischi { get; set; }
}


class Disco
{
    public int Id { get; set; }
    public string? Titolo { get; set; }
    public int Anno { get; set; }
    public int ArtistaId { get; set; }
    public Artista? Artista { get; set; }
}


class Database : DbContext
{
    public DbSet<Artista> Artisti { get; set; }  //DbSet rapresenta una tabella del database in memoria

    public DbSet<Disco> Dischi { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //configura del database in memoria
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");   //imposta il db in memoria
    }

    public void InserisciArtisti(List<Artista> artisti)
    {
        Artisti.AddRange(artisti);      //addRange aggiunge una lista di clienti al database
        SaveChanges();
    }
    public void InserisciDischi(List<Disco> dischi)
    {
        Dischi.AddRange(dischi);      //addRange aggiunge una lista di clienti al database
        SaveChanges();
    }

}


class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var artisti = new List<Artista>
            {
                new Artista { Nome = "Beatles" }
            };

            db.InserisciArtisti(artisti);

            var dischi = new List<Disco>
            {
                new Disco{ Titolo = "disco1", Anno=1962, ArtistaId=1 },
                new Disco { Titolo = "disco2", Anno=1969, ArtistaId=1 }
            };


            Console.WriteLine("\ndischi per artisti");
            db.InserisciDischi(dischi);




        }
    }
}







