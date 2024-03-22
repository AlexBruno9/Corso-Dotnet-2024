
using Microsoft.EntityFrameworkCore;



//  risolto MODIFICA CANZONE SBAGLIATO
//  risolto NON PERMETTERE INSERIMENTO DISCO SE NON ESISTONO ARTISTI O GENERI NEL DATABASE
//  risolto NON PERMETTERE INSERIMENTO CANZONE SE NON CI SONO DISCHI PRESENTI
//  +(cosa succede se per esempio elimino genere o artista di un disco salvato?)
//  VISUALIZZA PLAYLIST PER GENERE
// gestire inserimento prezzo decimale con il punto anziche la virgola
// gestire inserimento prezzo decimale con gli zeri finali (non si vedono)
// controller playlist
// - visualizza playlist non ha senso
// - elimina da playlist è da modificare (elimina da quale playlist?)
// - seleziona e mostra playlist non funziona
// in inserimento canzoni anziche inserire ome disco verranno mostrati id di quelli presenti per quell artista (gestirne il corretto inserimento)





//  -----   MAIN    -----

public class Program
{
    static void Main(string[] args)
    {
        Controller.MainMenu();
    }
}



//  -----   CLASS ARTISTA, ALBUM, GENERE, CANZONE, CANZONEPLAYLIST  -----
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



public class Canzone
{

    public int Id { get; set; }

    public string Titolo { get; set; }

    public int ArtistaId { get; set; }

    public Artista Artista { get; set; }

    public int DiscoId { get; set; }

    public Disco Disco { get; set; }
    //aggiungere durata
}



public class CanzonePlaylist
{
    public int Id { get; set; }
    public string NomePlaylist { get; set; }

    public int CanzoneId { get; set; }

    public Canzone Canzone { get; set; }
}





//  -----   DATABASE    -----

public class Database : DbContext
{


    public DbSet<Artista> Artisti { get; set; }
    public DbSet<Genere> Generi { get; set; }
    public DbSet<Disco> Dischi { get; set; }
    public DbSet<Canzone> Canzoni { get; set; }
    public DbSet<CanzonePlaylist> Playlist { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
    }

    public int GetIdFromArtist(string nome)
    {
        int id = 0;

        foreach (var a in Artisti)
        {
            if (a.Nome == nome)
            {
                id = a.Id;
            }
        }
        return id;
    }


    public int GetIdFromDisco(string nome)
    {
        int id = 0;

        foreach (Disco d in Dischi)
        {
            if (d.Titolo == nome)
            {
                id = d.Id;
            }
        }
        return id;
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

}






//  -----   VIEW    -----

public class View
{

    public static void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine(" ** MENU ** ");
        Console.WriteLine("\nARTISTI");
        Console.WriteLine(" - 1. Aggiungi artista");
        Console.WriteLine(" - 2. Elimina artista");
        Console.WriteLine(" - 3. Modifica artista");
        Console.WriteLine(" - 4. Mostra artisti");
        Console.WriteLine("\nGENERI");
        Console.WriteLine(" - 5. Aggiungi genere");
        Console.WriteLine(" - 6. Elimina genere");
        Console.WriteLine(" - 7. Modifica genere");
        Console.WriteLine(" - 8. Mostra generi");
        Console.WriteLine("\nDISCHI");
        Console.WriteLine(" - 9. Aggiungi disco");
        Console.WriteLine(" - 10. Elimina disco");
        Console.WriteLine(" - 11. Modifica disco");
        Console.WriteLine(" - 12. Mostra dischi");
        Console.WriteLine(" - 20. Mostra dettagli singolo disco");
        Console.WriteLine("\nCANZONI");
        Console.WriteLine(" - 13. Aggiungi canzone");
        Console.WriteLine(" - 14. Elimina canzone");
        Console.WriteLine(" - 15. Modifica canzone");
        Console.WriteLine(" - 16. Mostra elenco canzoni");
        Console.WriteLine("\nLA MIA PLAYLIST");
        Console.WriteLine(" - 17. Aggiungi canzone a playlist");
        Console.WriteLine(" - 18. Rimuovi canzone da playlist");
        Console.WriteLine(" - 19. Mostra playlist");
        Console.WriteLine(" - 21. Seleziona e mostra playlist");

        Console.WriteLine("\n\ne. ESCI\n");
    }


    public static string GetInput()
    {
        return Console.ReadLine()!;
    }

    public static void ShowArtisti(List<string> artisti)
    {
        Console.Clear();
        Console.WriteLine("\nLista artisti:\n");
        foreach (var a in artisti)
        {
            Console.WriteLine(a);
        }
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }

    public static void ShowGeneri(List<string> generi)
    {
        Console.Clear();
        Console.WriteLine("\nLista generi:\n");
        foreach (var g in generi)
        {
            Console.WriteLine(g);
        }
    }

    public static void ShowDischi(List<string> dischi)
    {
        Console.Clear();
        Console.WriteLine("\nLista dischi:\n");
        foreach (var d in dischi)
        {
            Console.WriteLine(d);
        }
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }

    public static void ShowCanzoni(List<string> canzoni)
    {
        Console.Clear();
        Console.WriteLine("\nLista canzoni:\n");
        foreach (var c in canzoni)
        {
            Console.WriteLine(c);
        }
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }



    // public void SelezionaPlaylist(List<CanzonePlaylist> playlist)
    // {
    //     Console.Write("Digita nome playlist: ");
    //     string select = Console.ReadLine();

    //     int counter = 0;
    //     foreach (CanzonePlaylist c in playlist)
    //     {
    //         if (c.NomePlaylist == select)
    //         {
    //             counter++;
    //             Console.WriteLine($"{counter} - {c.Canzone.Titolo} {_db.Spazio(25 - c.Canzone.Titolo.Length)} {c.Canzone.Artista.Nome} {_db.Spazio(15 - c.Canzone.Artista.Nome.Length)} {c.Canzone.Disco.Titolo} ");
    //         }
    //     }

    // }



}




//  -----   CONTROLLER  -----

public class Controller
{
    protected static readonly Database _db = new Database();

    public static void MainMenu()
    {

        while (true)
        {

            View.ShowMainMenu();               //visualizzazione del menu principale
            var input = View.GetInput();       //lettura dell input dell utente

            if (input == "1")
            {
                ArtistaController.AddArtista();
            }

            if (input == "2")
            {
                ArtistaController.EliminaArtista();
            }

            if (input == "3")
            {
                ArtistaController.ModificaArtista();
            }
            if (input == "4")
            {
                ArtistaController.ShowArtisti();
            }

            if (input == "5")
            {
                GenereController.AddGenere();
            }
            if (input == "6")
            {
                GenereController.EliminaGenere();
            }
            if (input == "7")
            {
                GenereController.ModificaGenere();
            }
            if (input == "8")
            {
                GenereController.ShowGeneri();
            }

            if (input == "9")
            {
                DiscoController.AddDisco();
            }

            if (input == "10")
            {
                DiscoController.EliminaDisco();
            }
            if (input == "11")
            {
                DiscoController.ModificaDisco();
            }
            if (input == "12")
            {
                DiscoController.ShowDischi();
            }

            if (input == "13")
            {
                CanzoneController.AddCanzone();
            }
            if (input == "14")
            {
                CanzoneController.EliminaCanzone();
            }
            if (input == "15")
            {
                CanzoneController.ModificaCanzone();
            }
            if (input == "16")
            {
                CanzoneController.ShowCanzoni();
            }
            if (input == "17")
            {
                PlaylistController.AddCanzonePlaylist();
            }
            if (input == "18")
            {
                PlaylistController.RemoveCanzonePlaylist();
            }
            if (input == "19")
            {
                PlaylistController.ShowPlaylist();
            }
            if (input == "20")
            {
                DiscoController.ShowSingoloDisco();
            }


            else if (input == "e")
            {
                break;
            }
        }

    }

}


