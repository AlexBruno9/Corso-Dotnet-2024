public class GenereController : Controller
{




    public static void AddGenere()
    {
        bool presente = true;
        while (presente)
        {
            presente = false;
            Console.Write("Enter genere name:");
            var name = View.GetInput();


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


    public static void EliminaGenere()
    {
        Console.Write("Enter genere name:");
        var name = View.GetInput();

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



    public static void ModificaGenere()
    {

        Console.Write("Enter nome genere da modificare: ");
        var name = View.GetInput();



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


    public static List<string> GetGeneri()
    {
        var variabile = _db.Generi.ToList();
        List<string> generi = new();
        foreach (var v in variabile)
        {
            generi.Add($"{v.Id} - {v.Nome}");
        }
        return generi;
    }

    public static void ShowGeneri()
    {
        var users = GetGeneri();
        View.ShowGeneri(users);
        Console.Write("\n\npremi un tasto per continuare");
        Console.ReadKey();
    }

}