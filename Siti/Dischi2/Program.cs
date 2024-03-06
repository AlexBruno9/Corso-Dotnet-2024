using Microsoft.EntityFrameworkCore;
using SQLitePCL;



//  -----   MAIN    -----

public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();                        //db
        var view = new View();                        //interfaccia utente
        var controller = new Controller(db, view);      //funzionalita gestisce dall'apliccazione
        controller.MainMenu();
    }
}



//  -----   CLASS ARTISTA, ALBUM, GENERE  -----
public class Artista
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class Genere
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class Disco
{
    public int Id { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public double Prezzo { get; set; }
    public int Id_artista { get; set; }
    public int Id_genere { get; set; }

}






//  -----   DATABASE    -----

public class Database : DbContext
{

    public DbSet<Artista> Artisti { get; set; }
    public DbSet<Genere> Generi { get; set; }
    public DbSet<Disco> Dischi { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //configura del database in memoria
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
    }


    public void AddArtista(string name)
    {
        Artista artista = new Artista();
        artista.Nome = name;
        Artisti.Add(artista);
        SaveChanges();
    }

    public void AddGenere(string name)
    {
        Genere genere = new Genere();
        genere.Nome = name;
        Generi.Add(genere);
        SaveChanges();
    }

    public void EliminaArtista(string nome)
    {
        foreach (Artista a in Artisti)
        {

            if (a.Nome == nome)
            {
                Remove(a);
                SaveChanges();
            }
        }
    }
    public void EliminaGenere(string nome)
    {
        foreach (Genere g in Generi)
        {

            if (g.Nome == nome)
            {
                Remove(g);
                SaveChanges();
            }
        }
    }

    public void ModificaArtista(string name)
    {

        Console.Write("Inserisci nome corretto: ");
        string nuovo = Console.ReadLine()!;
        foreach (Artista a in Artisti)
        {

            if (a.Nome == name)
            {

                a.Nome = nuovo;
                SaveChanges();
            }
        }
    }

    public void ModificaGenere(string name)
    {

        Console.Write("Inserisci genere corretto: ");
        string nuovo = Console.ReadLine()!;
        foreach (Genere g in Generi)
        {

            if (g.Nome == name)
            {

                g.Nome = nuovo;
                SaveChanges();
            }
        }
    }




    public List<string> GetArtisti()
    {
        var variabile = Artisti.ToList();
        List<string> artisti = new();
        foreach (var v in variabile)
        {
            artisti.Add(v.Nome!);
        }
        return artisti;
    }

    public List<string> GetGeneri()
    {
        var variabile = Generi.ToList();
        List<string> generi = new();
        foreach (var v in variabile)
        {
            generi.Add(v.Nome!);
        }
        return generi;
    }



}



//  -----   VIEW    -----

public class View
{



    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi artista");
        Console.WriteLine("2. Elimina artista");
        Console.WriteLine("3. Modifica artista");
        Console.WriteLine("4. Mostra artisti");
        Console.WriteLine("5. Aggiungi genere");
        Console.WriteLine("6. Elimina genere");
        Console.WriteLine("7. Modifica genere");
        Console.WriteLine("8. Mostra generi");
        Console.WriteLine("e. Esci");
    }


    public string GetInput()
    {
        return Console.ReadLine()!;                      //lettura dell'input dell'utente
    }

    public void ShowArtisti(List<string> artisti)
    {
        Console.WriteLine("\nLista utenti:");
        foreach (var a in artisti)
        {
            Console.WriteLine(a);                 //visualizzazione del nome degli utenti
        }
        Console.WriteLine("\n");
    }

    public void ShowGeneri(List<string> generi)
    {
        Console.WriteLine("\nLista generi:");
        foreach (var g in generi)
        {
            Console.WriteLine(g);                 //visualizzazione del nome degli utenti
        }
        Console.WriteLine("\n");
    }



}




//  -----   CONTROLLER  -----

public class Controller
{
    private Database _db;               //riferimento al modello
    private View _view;                 //riferimento alla vista

    private ArtistaController _artistaController = new();
    private GenereController _genereController = new();

    public Controller(Database db, View view)
    {
        _db = db;                         //inizializzazione del riferimento al modello
        _view = view;                     //iniz. del riferimento alla vista
    }




    public void MainMenu()
    {

        while (true)
        {

            _view.ShowMainMenu();               //visualizzazione del menu principale
            var input = _view.GetInput();       //lettura dell input dell utente

            if (input == "1")
            {
                _artistaController.AddArtista();
            }

            if (input == "2")
            {
                _artistaController.EliminaArtista();
            }

            if (input == "3")
            {
                _artistaController.ModificaArtista();
            }
            if (input == "4")
            {
                _artistaController.ShowArtisti();
            }

            if (input == "5")
            {
                _genereController.AddGenere();
            }
            if (input == "6")
            {
                _genereController.EliminaGenere();
            }
            if (input == "7")
            {
                _genereController.ModificaGenere();
            }
            if (input == "8")
            {
                _genereController.ShowGeneri();
            }




            else if (input == "e")
            {
                break;
            }
        }

    }

}



//  -----   CONTROLLER  ARTISTA  -----


public class ArtistaController
{

    private Database _db = new();
    private View _view = new();


    public void AddArtista()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _db.AddArtista(name);
    }

    public void EliminaArtista()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _db.EliminaArtista(name);
    }

    public void ModificaArtista()
    {
        Console.WriteLine("Enter user name da modificare:");
        var name = _view.GetInput();
        _db.ModificaArtista(name);
    }

    public void ShowArtisti()
    {
        var users = _db.GetArtisti();
        _view.ShowArtisti(users);
    }

}



//  -----   CONTROLLER  GENERE  -----


public class GenereController
{

    private Database _db = new();
    private View _view = new();


    public void AddGenere()
    {
        Console.WriteLine("Enter genere:");
        var name = _view.GetInput();
        _db.AddGenere(name);
    }

    public void EliminaGenere()
    {
        Console.WriteLine("Enter genere da eliminare dal db:");
        var name = _view.GetInput();
        _db.EliminaGenere(name);
    }

    public void ModificaGenere()
    {
        Console.WriteLine("Enter user name da modificare:");
        var name = _view.GetInput();
        _db.ModificaGenere(name);
    }


    public void ShowGeneri()
    {
        var users = _db.GetGeneri();
        _view.ShowGeneri(users);
    }

}

