class Program
{
    static void Main(string[] args)                     
    {
                    Random random=new Random();
                    int somma=0;
                    int basso, alto;
                    Console.WriteLine("Seleziona l'intervallo.");
                    Console.Write("Genera numero tra: ");
                    basso=Int32.Parse(Console.ReadLine());
                    Console.Write("e: ");
                    alto=Int32.Parse(Console.ReadLine());

                    for(int i=0;i<50;i++)
                    {

                        int numero=random.Next(basso,alto);
                        Console.Write($"Il numero generato è {numero}");

                        if(numero%3==0)   
                        {
                                if(numero%5==0)
                                {

                                    Console.Write(", è divisibile sia per 3 che per 5");

                                }
                                else
                                Console.Write(", è divisibile per 3");
                        }
                        else if(numero%5==0){

                            Console.Write(", è divisibile per 5");

                        }
                        
                        Console.Write("\n");
                    }
    }
}


// VERSIONE CON LISTE

/*
class Program
{
    static void Main(string[] args)                     
    {

                    List<int> fizz = new List<int>(); 
                    List<int> buzz = new List<int>(); 
                    List<int> fizzbuzz = new List<int>();    


                    Console.WriteLine("Seleziona l'intervallo.");
                    Console.Write("Visualizza numeri tra: ");
                    int basso=Int32.Parse(Console.ReadLine()!);
                    Console.Write("e: ");
                    int alto=Int32.Parse(Console.ReadLine()!);

                    int x=0,y=0,z=0;

                    for(int i=basso;i<=alto;i++)
                    {
                        int numero=i;
                        if(numero%3==0)   
                        {
                                if(numero%5==0)
                                {
                                   fizzbuzz.Add(numero);
                                   z++;
                                }
                                else
                                {
                                 fizz.Add(numero);
                                 x++;
                                }
                        }
                        else if(numero%5==0)
                        {
                            buzz.Add(numero);
                            y++;

                        }
                       
                    }
                    Console.Write($"\n{x} numeri divisibili per 3:\n");
                    for(int i=0;i<fizz.Count;i++){

                        Console.Write($"{fizz[i]} / ");
                    }
                    Console.Write("\n");
                    

                    Console.Write($"\n{y} numeri divisibili per 5:\n");
                    for(int i=0;i<buzz.Count;i++){

                        Console.Write($"{buzz[i]} / ");
                    }
                    Console.Write("\n");

                    Console.Write($"\n{z} numeri divisibili sia per 3 che per 5:\n");
                    for(int i=0;i<fizzbuzz.Count;i++){

                        Console.Write($"{fizzbuzz[i]} / ");
                    }
                    Console.Write("\n");

    }
}
*/

// VERSIONE CON JOIN

/*class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List<string> fizzbuzz = new List<string>();
        List<string> fizz = new List<string>();
        List<string> buzz = new List<string>();
        List<string> numero = new List<string>();
        Console.WriteLine("I numeri usciti sono:");
        for (int i = 1; i <= 100; i++)
        {
            int numeroCasuale = random.Next(1, 101);
            Console.Write($"{numeroCasuale}, ");
            if (numeroCasuale % 3 == 0 && numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista fizzbuzz
                fizzbuzz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 3 == 0)
            {
                // aggiungi il numero alla lista fizz
                fizz.Add(numeroCasuale.ToString());
            }
            else if (numeroCasuale % 5 == 0)
            {
                // aggiungi il numero alla lista buzz
                buzz.Add(numeroCasuale.ToString());
            }
            else
            {
                // aggiungi il numero alla lista numero
                numero.Add(numeroCasuale.ToString());
            }
            Thread.Sleep(30);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri FizzBuzz sono {fizzbuzz.Count} ed i numeri contenuti sono:");
        foreach (string item in fizzbuzz)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri Fizz sono {fizz.Count} ed i numeri contenuti sono {string.Join(", ", fizz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri Buzz sono {buzz.Count} ed i numeri contenuti sono {string.Join(", ", buzz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri sono {numero.Count} ed i numeri contenuti sono {string.Join(", ", numero)}");
    }
}*/

// VERSIONE CON LISTE DI STRINGHE E ORDINAMENTO

/*
        // se la lista fizzbuzz è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < fizzbuzz.Count; i++)
        {
            if (int.Parse(fizzbuzz[i]) < 10)
            {
                fizzbuzz[i] = $"0{fizzbuzz[i]}";
            }
        }
        // se la lista fizz è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < fizz.Count; i++)
        {
            if (int.Parse(fizz[i]) < 10)
            {
                fizz[i] = $"0{fizz[i]}";
            }
        }
        // se la lista buzz è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < buzz.Count; i++)
        {
            if (int.Parse(buzz[i]) < 10)
            {
                buzz[i] = $"0{buzz[i]}";
            }
        }
        // se la lista numero è contiene numeri inferiori a 10 aggiungi uno 0 davanti
        for (int i = 0; i < numero.Count; i++)
        {
            if (int.Parse(numero[i]) < 10)
            {
                numero[i] = $"0{numero[i]}";
            }
        }
        // togli gli elementi duplicati dalla lista fizzbuzz
        fizzbuzz = fizzbuzz.Distinct().ToList();
        // ordina la lista fizzbuzz
        fizzbuzz.Sort();
        // togli gli elementi duplicati dalla lista fizz
        fizz = fizz.Distinct().ToList();
        // ordina la lista fizz
        fizz.Sort();
        // togli gli elementi duplicati dalla lista buzz
        buzz = buzz.Distinct().ToList();
        // ordina la lista buzz
        buzz.Sort();
        // togli gli elementi duplicati dalla lista numero
        numero = numero.Distinct().ToList();
        // ordina la lista numero
        numero.Sort();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri FizzBuzz sono {fizzbuzz.Count} ed i numeri contenuti sono:");
        foreach (string item in fizzbuzz)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"I numeri Fizz sono {fizz.Count} ed i numeri contenuti sono {string.Join(", ", fizz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri Buzz sono {buzz.Count} ed i numeri contenuti sono {string.Join(", ", buzz)}");
        Console.WriteLine();
        Console.WriteLine($"I numeri sono {numero.Count} ed i numeri contenuti sono {string.Join(", ", numero)}");
    }
}
*/