
public class ArtistaController : Controller
{

    public static void AddArtista()
    {
        bool presente = true;
        while (presente)
        {
            presente = false;
            Console.Write("Enter artist name:");
            var name = View.GetInput();

            foreach (var a in _db.Artisti)
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

    public static void EliminaArtista()
    {
        Console.Write("Enter artist name:");
        var name = View.GetInput();

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



    public static void ModificaArtista()
    {

        Console.Write("Enter nome artista da modificare: ");
        var name = View.GetInput();



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


    public static List<string> GetArtisti()
    {
        var variabile = _db.Artisti.ToList();
        List<string> artisti = new();
        foreach (var v in variabile)
        {
            artisti.Add(v.Nome!);
        }
        return artisti;
    }

    public static void ShowArtisti()
    {
        var users = GetArtisti();
        View.ShowArtisti(users);
    }

}