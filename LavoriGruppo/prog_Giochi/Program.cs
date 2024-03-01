using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string input;



        //saluti vari 
        Console.Clear();
        Console.WriteLine("Benvenuto!");

       

        //seleziona da file giocatore 1
        string giocatore1 = VisualizzaGiocatori();
        Giocatore g1 = CreaGiocatore(giocatore1);

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("1 - gioco 1");
            Console.WriteLine("2 - gioco 2");
            Console.WriteLine("3 - gioco 3");
            Console.WriteLine("4 - esci");

            input = Console.ReadLine()!;

            switch (input)
            {
                case "1":

                    if (g1.Crediti < 1)
                    {
                        Console.WriteLine("Crediti insufficenti!");
                    }
                    else
                    {
                        g1.Crediti -= 1;
                        System.Console.WriteLine("gioco 1");//Gioco gioco = new(g1);
                    }

                    break;

                case "2":

                    if (g1.Crediti < 3)
                    {
                        Console.WriteLine("Crediti insufficenti!");
                    }
                    else
                    {
                        g1.Crediti -= 3;
                        System.Console.WriteLine("gioco 2");
                        //Gioco2(g1);
                    }
                    break;



                case "3":

                    if (g1.Crediti < 5)
                    {
                        Console.WriteLine("Crediti insufficenti!");
                    }
                    else
                    {
                        g1.Crediti -= 5;
                        System.Console.WriteLine("gioco 3");//Gioco3(g1);
                    }
                    break;

                case "4":
                    {
                        Console.WriteLine("Uscita...");
                        continua = false;
                        break;
                    }

                default:
                    Console.WriteLine($"{input} NON valido");
                    break;
            }


        }
    }

    /// <summary>
    /// Visualizza elenco giocatori della cartella giocatori e permette la selezione <br/>
    /// di uno di essi.
    /// </summary>
    /// <returns>L'oggetto di tipo Giocatore base</returns>
    public static string VisualizzaGiocatori()
    {
        string path = @"giocatori";
        string[] files = Directory.GetFiles(path);
        string sceltaGiocatore = "";
        int input;
        int conta = 1;


        if (files.Length == 0)
        {
            Console.WriteLine("Nessun file!!!");
        }
        else
        {
            //menu selezione file
            foreach (string file in files)
            {

                Console.WriteLine($"{conta} - {file.Substring(10,file.Length-15)}");
                conta++;
            }

            Console.WriteLine("Seleziona file: ");
            input = int.Parse(Console.ReadLine()!);
            input--;
            sceltaGiocatore = files[input];
        }
        return sceltaGiocatore;
    }

    public static Giocatore CreaGiocatore(string file)
    {

        string json = File.ReadAllText(file);
        dynamic obj = JsonConvert.DeserializeObject(json)!
        ;


        Giocatore g1 = new Giocatore
        {
            Nome = $"{obj.nome}",
            Punteggio = obj.punteggio,
            Crediti = obj.crediti,
            PartiteGiocate=obj.partiteGiocate,
            PartiteVinte=obj.partiteVinte
        };

        return g1;
    }
}

