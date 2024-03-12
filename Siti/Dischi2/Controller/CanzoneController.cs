using Microsoft.EntityFrameworkCore;

public class CanzoneController
{

    private Database _db = new();
    private View _view = new();


    public void AddCanzone()
    {

        //Canzone canzone = new Canzone();


        Console.Write("Enter song name:");
        var name = _view.GetInput();


        Console.Write("Enter nome artista:");
        string input = _view.GetInput();
        while (_db.GetIdFromArtist(input) == 0)
        {
            Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
            input = _view.GetInput();
        }
        int idArtist = _db.GetIdFromArtist(input);
        //canzone.ArtistaId = idArtist;

        bool trova = false;
        foreach (Canzone c in _db.Canzoni)
        {
            if (c.Titolo == name && c.ArtistaId == idArtist)
            {
                trova = true;
            }
        }

        if (trova == true)
        {
            Console.WriteLine("Canzone già presente in catalogo, nessuna modifica effettuata.");
            Thread.Sleep(3000);
        }
        else
        {
            Console.Write("Enter nome disco:");
            input = _view.GetInput();

            while (_db.GetIdFromDisco(input) == 0)
            {
                Console.Write("Disco non presente in catalogo, inseriscine uno presente: ");
                input = _view.GetInput();
            }
            int idAlbum = _db.GetIdFromDisco(input);



            Canzone canzone = new Canzone();

            canzone.Titolo = name;
            canzone.ArtistaId = idArtist;
            canzone.DiscoId = idAlbum;
            _db.Canzoni.Add(canzone);
            _db.SaveChanges();

        }

    }


    public void EliminaCanzone()
    {
        Console.Write("Enter titolo canzone da eliminare: ");
        var name = _view.GetInput();

        Console.Write("Enter artista canzone da eliminare: ");
        var temp = _view.GetInput();
        var artist = _db.GetIdFromArtist(temp);


        bool presente = false;
        foreach (Canzone c in _db.Canzoni)
        {

            if (c.Titolo == name && c.ArtistaId == artist)
            {
                _db.Remove(c);
                _db.SaveChanges();
                presente = true;
            }
        }
        if (presente == false)
        {
            Console.WriteLine($"\n\nCanzone non trovata, assicurati di aver digitato titolo e autore corretti;\n Nessuna modifica effettuata.\n\n");
            Thread.Sleep(4000);
        }
    }


    //  provare se funziona e passare a show canzoni


    public void ModificaCanzone()
    {

        Console.Write("Enter titolo canzone da modificare: ");
        var name = _view.GetInput();

        Console.Write("Enter artista canzone da modificare: ");
        var temp = _view.GetInput();
        var artist = _db.GetIdFromArtist(temp);


        bool trovato = false;

        foreach (Canzone c in _db.Canzoni)
        {


            if (c.Titolo == name && c.ArtistaId == artist)
            {


                Console.Write("\n\nEnter new song name:");
                name = _view.GetInput();


                Console.Write("Enter nome artista:");
                string input = _view.GetInput();
                while (_db.GetIdFromArtist(input) == 0)
                {
                    Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
                    input = _view.GetInput();
                }
                int idArtist = _db.GetIdFromArtist(input);


                bool trova = false;
                foreach (Canzone ca in _db.Canzoni)
                {
                    if (ca.Titolo == name && ca.ArtistaId == idArtist)
                    {
                        trova = true;
                    }
                }

                if (trova == true)
                {
                    Console.WriteLine("Canzone già presente in catalogo, nessuna modifica effettuata.");
                    Thread.Sleep(3000);
                    break;
                }
                else
                {
                    Console.Write("Enter nome disco:");
                    input = _view.GetInput();

                    while (_db.GetIdFromDisco(input) == 0)
                    {
                        Console.Write("Disco non presente in catalogo, inseriscine uno presente: ");
                        input = _view.GetInput();
                    }
                    int idAlbum = _db.GetIdFromDisco(input);




                    c.Titolo = name;
                    c.ArtistaId = idArtist;
                    c.DiscoId = idAlbum;

                    _db.SaveChanges();

                    trovato = true;
                }
            }

        }
        if (trovato == false)
        {
            Console.WriteLine($"\n\nCanzone non trovata, assicurati di aver digitato titolo e autore corretti;\nOperazione annullata;\n\n");
            Thread.Sleep(4000);
        }
    }




    public void ShowCanzoni()
    {

        var canzone = _db.Canzoni.Include(d => d.Artista).Include(d => d.Disco).ToList();
        List<string> users = new List<string>();


        foreach (var c in canzone)
        {


            users.Add($"{c.Id} - {c.Titolo} {_db.Spazio(25 - c.Titolo.Length)} {c.Artista.Nome} {_db.Spazio(15 - c.Artista.Nome.Length)} {c.Disco.Titolo} ");
        }

        _view.ShowCanzoni(users);
    }



}