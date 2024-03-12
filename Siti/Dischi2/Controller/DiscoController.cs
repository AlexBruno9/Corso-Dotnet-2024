

using Microsoft.EntityFrameworkCore;

public class DiscoController
{

    private Database _db = new();
    private View _view = new();
    private GenereController _genereController = new();



    public int InsertEControlloInt()
    {
        int val;
    label1:
        try
        {
            val = Int32.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.Write("Inserire valore numerico: ");
            goto label1;
        }
        return val;
    }

    public double InsertEControlloDouble()
    {
        double val;
    label1:
        try
        {
            val = Double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.Write("Inserire valore numerico: ");
            goto label1;
        }
        return val;
    }


        //  NON  PERMETTERE INSERIMENTO SE NON ESISTONO ARTISTI O GENERI NEL DATABASE

    public void AddDisco()
    {
        Disco disco = new Disco();

        Console.Write("Enter titolo:");
        var input = _view.GetInput();
        disco.Titolo = input;

        Console.Write("Enter anno:");
        int anno = InsertEControlloInt();
        while (anno < 1600)
        {
            Console.Write("Enter anno plausibile:");
            anno = InsertEControlloInt();
        }
        disco.Anno = anno;

        Console.Write("Enter prezzo:");                 //inserire il decimale con la virgola (non il punto)
        double prezzo = InsertEControlloDouble();
        while (prezzo <= 0)
        {
            Console.Write("Enter prezzo plausibile:");
            prezzo = InsertEControlloDouble();
        }
        disco.Prezzo = prezzo;

        Console.Write("Enter nome artista:");
        input = _view.GetInput();

        while (_db.GetIdFromArtist(input) == 0)
        {
            System.Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
            input = _view.GetInput();
        }

        disco.ArtistaId = _db.GetIdFromArtist(input);


        var users = _genereController.GetGeneri();
        _view.ShowGeneri(users);

        bool trovato = false;
        int id = 0;

        while (trovato == false)
        {
            Console.Write("\nSeleziona genere:");
            id = InsertEControlloInt();

            foreach (Genere g in _db.Generi)
            {
                if (g.Id == id)
                {
                    trovato = true;
                }
            }
            if (trovato == false)
            {
                Console.WriteLine("\n\nID genere non trovato.");
                Thread.Sleep(1000);
                _view.ShowGeneri(users);
            }
        }

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
            Console.WriteLine($"\n\nAlbum '{name}' non trovato. Nessuna modifica effettuata.\n\n");
            Thread.Sleep(3000);
        }
    }



    public void ModificaDisco()
    {


        Console.Write("Enter titolo disco da modificare: ");
        var name = _view.GetInput();
        Console.Write("Enter artista disco da modificare: ");
        string artista = Console.ReadLine();

        int artId = _db.GetIdFromArtist(artista);

        //  MODIFICA        


        bool trovato = false;
        foreach (Disco d in _db.Dischi)
        {

            if (d.Titolo == name && d.ArtistaId == artId)
            {
                trovato = true;
                Console.WriteLine("\n\nMODIFICA:");
                Console.Write("Enter titolo: ");
                var input = _view.GetInput();
                d.Titolo = input;
                int anno;



                Console.Write("Enter anno: ");
                anno = InsertEControlloInt();
                while (anno < 1600)
                {
                    Console.Write("Enter anno plausibile: ");
                    anno = InsertEControlloInt();
                }
                d.Anno = anno;



                Console.Write("Enter prezzo: ");                 //inserire il decimale con la virgola (non il punto)
                double prezzo = InsertEControlloDouble();
                while (prezzo <= 0)
                {
                    Console.Write("Enter prezzo plausibile: ");
                    prezzo = InsertEControlloDouble();
                }
                d.Prezzo = prezzo;




                Console.Write("Enter nome artista: ");
                string art = _view.GetInput();

                while (_db.GetIdFromArtist(art) == 0)
                {
                    Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
                    art = _view.GetInput();
                }

                d.ArtistaId = _db.GetIdFromArtist(art);




                var users = _genereController.GetGeneri();
                _view.ShowGeneri(users);

                bool trovaGenere = false;
                int id = 0;

                while (trovaGenere == false)
                {
                    Console.Write("\nSeleziona genere:");
                    id = InsertEControlloInt();

                    foreach (Genere g in _db.Generi)
                    {
                        if (g.Id == id)
                        {
                            trovaGenere = true;
                        }
                    }
                    if (trovaGenere == false)
                    {
                        Console.WriteLine("\n\nID genere non trovato.");
                        Thread.Sleep(1000);
                        _view.ShowGeneri(users);
                    }
                }

                d.GenereId = id;

                _db.SaveChanges();
                break;
            }
        }
        if (trovato == false)
        {
            Console.WriteLine("\n\nDisco non trovato in catalogo.\n\n");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("\n\nModifica effettuata con successo.\n\n");
            Thread.Sleep(3000);
        }

    }




    public void ShowDischi()
    {

        var disco = _db.Dischi.Include(d => d.Artista).Include(d => d.Genere).ToList();
        List<string> users = new List<string>();


        foreach (var d in disco)
        {


            users.Add($"{d.Titolo} {_db.Spazio(25 - d.Titolo.Length)} {d.Artista.Nome} {_db.Spazio(15 - d.Artista.Nome.Length)} ({d.Anno})");
        }

        _view.ShowDischi(users);
    }



    public void ShowSingoloDisco()
    {

        Console.Write("\n\nEnter titolo: ");
        var name = _view.GetInput();

        Console.Write("Enter artista: ");
        var temp = _view.GetInput();
        int IdArtist = _db.GetIdFromArtist(temp);

        bool trovato = false;
        var disco = _db.Dischi.Include(d => d.Artista).Include(d => d.Genere).ToList();

        foreach (Disco d in _db.Dischi)
        {

            if (d.Titolo == name && d.ArtistaId == IdArtist)
            {
                trovato = true;
                Console.Clear();
                Console.WriteLine($"{d.Titolo}({d.Anno}) {_db.Spazio(25 - d.Titolo.Length)} {d.Artista.Nome} {_db.Spazio(15 - d.Artista.Nome.Length)} \t\tgenere: {d.Genere.Nome} {_db.Spazio(10 - d.Genere.Nome.Length)} valore: {d.Prezzo}");

                Console.WriteLine("\nTracklist:");

                int counter = 0;
                foreach (Canzone c in _db.Canzoni)
                {
                    if (d.Id == c.DiscoId)
                    {
                        counter++;
                        Console.WriteLine($"{counter} - {c.Titolo}");
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine("Nessuna canzone contenuta in questo disco è presente in database.\n");
                }

                Console.Write("\n\npremi un tasto per continuare");
                Console.ReadKey();
                break;

            }

        }
        if (trovato == false)
        {
            Console.WriteLine("\n\nDisco non trovato in catalogo\n\n");
            Thread.Sleep(3000);
        }

    }



}


