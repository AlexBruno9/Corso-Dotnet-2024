using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;




//  AGGIUNGERE STAMPE IN ORDINE PER PREZZO, ANNO, ARTISTI

//  CONTROLLI inserimento (lettere, numeri, spazio vuoto, numeri negativi, numeri enormi)
/*  -artista
    -genere
    -disco
*/



//  -----   MAIN    -----

public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View();
        var controller = new Controller(db, view);
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
    public int ArtistaId { get; set; }

    public Artista Artista { get; set; }
    public int GenereId { get; set; }
    public Genere Genere { get; set; }

}

public class Playlist
{
    public int Id { get; set; }
    public int DiscoId { get; set; }
    public Disco Disco { get; set; }
    public int UtenteId { get; set; }
    public Utente Utente { get; set; }

}

public class Utente
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
/*
public class Tracklist
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
*/

//  MANCA TABELLA TRACKLIST




//  -----   DATABASE    -----

public class Database : DbContext
{

    public DbSet<Artista> Artisti { get; set; }
    public DbSet<Genere> Generi { get; set; }
    public DbSet<Disco> Dischi { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
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
        Console.WriteLine("9. Aggiungi disco");
        Console.WriteLine("10. Elimina disco");
        Console.WriteLine("11. Modifica disco");
        Console.WriteLine("12. Mostra dischi");
        Console.WriteLine("e. Esci");
    }


    public string GetInput()
    {
        return Console.ReadLine()!;
    }

    public void ShowArtisti(List<string> artisti)
    {
        Console.Clear();
        Console.WriteLine("\nLista artisti:");
        foreach (var a in artisti)
        {
            Console.WriteLine(a);
        }
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }

    public void ShowGeneri(List<string> generi)
    {
        Console.Clear();
        Console.WriteLine("\nLista generi:");
        foreach (var g in generi)
        {
            Console.WriteLine(g);
        }
    }

    public void ShowDischi(List<string> dischi)
    {
        Console.Clear();
        Console.WriteLine("\nLista dischi:");
        foreach (var d in dischi)
        {
            Console.WriteLine(d);
        }
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }



}




//  -----   CONTROLLER  -----

public class Controller
{
    private Database _db;
    private View _view;

    private ArtistaController _artistaController = new();
    private GenereController _genereController = new();
    private DiscoController _discoController = new();

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
            if (input == "9")
            {
                _discoController.AddDisco();
            }
            if (input == "10")
            {
                _discoController.EliminaDisco();
            }
            if (input == "11")
            {
                _discoController.ModificaDisco();
            }
            if (input == "12")
            {
                _discoController.ShowDischi();
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
        bool presente = true;
        while (presente)
        {
            presente = false;
            Console.Write("Enter artist name:");
            var name = _view.GetInput();


            foreach (Artista a in _db.Artisti)
            {
                if (a.Nome == name)
                {
                    presente = true;
                }
            }
            if (presente == true)
            {
                Console.WriteLine("\n\nArtista già presente in catalogo, riprova.");
            }
            else
            {

                Artista artista = new Artista();
                artista.Nome = name;
                _db.Artisti.Add(artista);
                _db.SaveChanges();
            }

        }

    }

    public void EliminaArtista()
    {
        Console.Write("Enter artist name:");
        var name = _view.GetInput();

        bool presente = false;
        foreach (Artista a in _db.Artisti)
        {

            if (a.Nome == name)
            {
                _db.Remove(a);
                _db.SaveChanges();
                presente = true;
            }
        }
        if (presente == false)
        {
            Console.WriteLine($"\n\nArtista '{name}' non trovato. Nessuna modifica effettuata.\n\n");
            Thread.Sleep(3000);
        }
    }



    public void ModificaArtista()
    {

        Console.Write("Enter nome artista da modificare: ");
        var name = _view.GetInput();



        Console.Write("Inserisci nome corretto: ");
        string nuovo = Console.ReadLine()!;
        bool trovato = false;

        foreach (Artista a in _db.Artisti)
        {

            if (a.Nome == name)
            {
                a.Nome = nuovo;
                _db.SaveChanges();
                trovato = true;
            }
        }
        if (trovato == false)
        {
            Console.WriteLine($"\n\nNome '{name}' non presente in catalogo. Operazione annullata;\n\n");
            Thread.Sleep(3000);
        }
    }


    public List<string> GetArtisti()
    {
        var variabile = _db.Artisti.ToList();
        List<string> artisti = new();
        foreach (var v in variabile)
        {
            artisti.Add(v.Nome!);
        }
        return artisti;
    }

    public void ShowArtisti()
    {
        var users = GetArtisti();
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
        bool presente = true;
        while (presente)
        {
            presente = false;
            Console.Write("Enter genere name:");
            var name = _view.GetInput();


            foreach (Genere g in _db.Generi)
            {
                if (g.Nome == name)
                {
                    presente = true;
                }
            }
            if (presente == true)
            {
                Console.WriteLine("\n\nGenere già memorizzato, inseriscine un altro.");
            }
            else
            {

                Genere genere = new Genere();
                genere.Nome = name;
                _db.Generi.Add(genere);
                _db.SaveChanges();
            }

        }
    }


    public void EliminaGenere()
    {
        Console.Write("Enter genere name:");
        var name = _view.GetInput();

        bool presente = false;
        foreach (Genere g in _db.Generi)
        {

            if (g.Nome == name)
            {
                _db.Remove(g);
                _db.SaveChanges();
                presente = true;
            }
        }
        if (presente == false)
        {
            Console.WriteLine($"\n\nGenere '{name}' non trovato. Nessuna modifica effettuata.\n\n");
            Thread.Sleep(3000);
        }
    }



    public void ModificaGenere()
    {

        Console.Write("Enter nome genere da modificare: ");
        var name = _view.GetInput();



        Console.Write("Inserisci nome corretto: ");
        string nuovo = Console.ReadLine()!;
        bool trovato = false;

        foreach (Genere g in _db.Generi)
        {

            if (g.Nome == name)
            {
                g.Nome = nuovo;
                _db.SaveChanges();
                trovato = true;
            }
        }
        if (trovato == false)
        {
            Console.WriteLine($"\n\nGenere '{name}' non presente in catalogo. Operazione annullata;\n\n");
            Thread.Sleep(3000);
        }
    }


    public List<string> GetGeneri()
    {
        var variabile = _db.Generi.ToList();
        List<string> generi = new();
        foreach (var v in variabile)
        {
            generi.Add($"{v.Id} - {v.Nome}");
        }
        return generi;
    }

    public void ShowGeneri()
    {
        var users = GetGeneri();
        _view.ShowGeneri(users);
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }

}



//  -----   CONTROLLER  DISCO  -----


public class DiscoController
{

    private Database _db = new();
    private View _view = new();
    private GenereController _genereController = new();
    //private ArtistaController _artistaController = new();

    public int GetIdFromArtist(string nome)
    {
        int id = 0;

        foreach (var a in _db.Artisti)
        {
            if (a.Nome == nome)
            {
                id = a.Id;
            }
        }
        return id;
    }


    public void AddDisco()
    {
        Disco disco = new Disco();

        Console.Write("Enter titolo:");
        var input = _view.GetInput();
        disco.Titolo = input;

        Console.Write("Enter anno:");
        int anno = Int32.Parse(Console.ReadLine());
        disco.Anno = anno;

        Console.Write("Enter prezzo:");
        double prezzo = Double.Parse(Console.ReadLine());
        disco.Prezzo = prezzo;

        Console.Write("Enter nome artista:");
        input = _view.GetInput();

        while (GetIdFromArtist(input) == 0)
        {
            System.Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
            input = _view.GetInput();
        }

        disco.ArtistaId = GetIdFromArtist(input);


        var users = _genereController.GetGeneri();
        _view.ShowGeneri(users);
        Console.Write("\nSeleziona genere:");

        int id = Int32.Parse(Console.ReadLine());
        disco.GenereId = id;



        _db.Dischi.Add(disco);
        _db.SaveChanges();
    }



    public void EliminaDisco()
    {
        Console.Write("Enter album name:");
        var name = _view.GetInput();

        bool presente = false;
        foreach (Disco d in _db.Dischi)
        {

            if (d.Titolo == name)
            {
                _db.Remove(d);
                _db.SaveChanges();
                presente = true;
            }
        }
        if (presente == false)
        {
            Console.WriteLine($"\n\nGenere '{name}' non trovato. Nessuna modifica effettuata.\n\n");
            Thread.Sleep(3000);
        }
    }


    //  --------------------ARRIVATO QUI---------------------------------------
    //  fare controllo anno
    //  controllo prezzo
    //  controllo id

    public void ModificaDisco()
    {


        Console.Write("Enter disco da modificare:");
        var name = _view.GetInput();

        //  MODIFICA


        foreach (Disco g in _db.Dischi)
        {


            if (g.Titolo == name)
            {

                Console.Write("Enter titolo:");
                var input = _view.GetInput();
                g.Titolo = input;
                int anno;

                
                Console.Write("Enter anno:");
                try
                {
                anno = Int32.Parse(Console.ReadLine());  
                }   
                catch(Exception)
                {
                    Console.WriteLine("Digita un valore corretto.");
                    return;
                }
                g.Anno = anno;


                Console.Write("Enter prezzo:");
                double prezzo = Double.Parse(Console.ReadLine());
                g.Prezzo = prezzo;

                Console.Write("Enter ID artista:");
                int id = Int32.Parse(Console.ReadLine());
                g.ArtistaId = id;

                var users = _genereController.GetGeneri();
                _view.ShowGeneri(users);
                Console.Write("Enter ID genere:");
                id = Int32.Parse(Console.ReadLine());
                g.GenereId = id;
                _db.SaveChanges();
            }
        }
    }

    public string Spazio(int spazioTitolo)
    {
        string spazi = " ";

        while (spazioTitolo > 0)
        {
            spazi += " ";
            spazioTitolo--;
        }

        return spazi;

    }



    public void ShowDischi()
    {

        var disco = _db.Dischi.Include(d => d.Artista).ToList();
        List<string> users = new List<string>();


        foreach (var d in disco)
        {


            users.Add($"{d.Titolo} {Spazio(20 - d.Titolo.Length)} {d.Artista.Nome} {Spazio(12 - d.Artista.Nome.Length)} ({d.Anno})");
        }

        _view.ShowDischi(users);
    }

}

