# Corso-Dotnet-2024



<details>
<summary>01 - DICHIARAZIONE CARATTERE STRINGA</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        string nome= "Alex";
        Console.WriteLine($"Ciao {nome}!");  //interpolaz. di stringhe  MEGLIO
        Console.WriteLine("Ciao "+ nome+"!");    //interpolaz. con operatore
    }
}
```

</details>

<details>
<summary>02 - DICHIARAZIONE INTERO, BOOLEANO, DECIMALE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        //  intero
        int eta=10;
        Console.WriteLine($"Hai {eta} anni.");

        //  booleano
        bool maggiorenne=true;
        Console.WriteLine($"Sei maggiorenne? {maggiorenne}.");

        //  decimale    (ma ci sono anche float e double)
        decimal altezza = 1.80m;
        Console.WriteLine($"Sei alto {altezza}.");
    }
}
```

</details>

<details>
<summary>03 - DICHIARAZIONE CARATTERE DI TIPO DATA</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1980,1,1);
        Console.WriteLine($"Sei nato il {dataDiNascita}.");
    }
}
```

</details>

<details>
<summary>04 - DICHIARAZIONE DATA, METODO ToShortDateString / ToLongDateString</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        DateTime dataDiNascita = new DateTime(1980,1,1);
        //  ToShortDateString
        Console.WriteLine($"Sei nato il {dataDiNascita.ToShortDateString()}");
        //  ToLongDateString
        Console.WriteLine($"Sei nato il {dataDiNascita.ToLongDateString()}");
    }
}
```

</details>

<details>
<summary>05 - SOMMA</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        //  INTERI
        int a=10;
        int b=10;
        int c=a+b;
        Console.WriteLine($"La somma di {a} e {b} è {c}.");

        //  DECIMALI
        decimal d=1.5m;
        decimal e=a+b+c;
        Console.WriteLine($"La somma di {a} e {b} e {d} è {e}.");
    }
}
```

</details>

<details>
<summary>06 - CONFRONTO STRINGHE/INTERI</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        //  CONFRONTO STRINGHE CON BOOL
        string nome1= "Alex";
        string nome2= "Alexa";
        bool uguali = nome1==nome2;
        bool diversi = nome1!=nome2;
        Console.WriteLine($"I due nomi sono uguali? {uguali}");
        Console.WriteLine($"I due nomi sono diversi? {diversi}");

        //  CONFRONTO INT CON BOOL
        int a=10;
        int b=20;
        bool maggiore= a>b;
        bool minore= a<b;

        Console.WriteLine($"a è maggiore di b? {maggiore}");
        Console.WriteLine($"a è minore di b? {minore}");
        Console.WriteLine($"b è maggiore di a? {minore}");
        Console.WriteLine($"b è minore di a? {maggiore}");
    }
}
```

</details>

<details>
<summary>07 - DICHIARARE ARRAY DI STRINGHE/INTERI</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        //  ARRAY DI STRING - VERSIONE LUNGA
        string[] nome = new string[3];
        nome[0]= "Alex";
        nome[1]= "Mario";
        nome[2]= "Luigi";
        Console.WriteLine($"Ciao {nome[0]}, {nome[1]} e {nome[2]}!");

        // ARRAY DI INTERI - VERSIONE LUNGA
        int[] numeri = new int[3];
        numeri[0]= 10;
        numeri[1]= 20;
        numeri[2]= 5;
        numeri[3]= numeri[0]+numeri[1]+numeri[2]
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}, la somma è {numeri[3]}");

    }
}
//array ha numero predeterminato di elementi
//si può inserire elemento in zona specifica
//deve contenere dati dello stesso tipo
```

</details>

<details>
<summary>08 - ARRAY METODO .Length</summary>

```C#
    {
        string[] nomi = new string[3];
        nomi[0]= "Alex";
        nomi[1]= "Mario";
        Console.WriteLine($"Il numero degli elementi è {nomi.Length}");
    }
//il metodo length funzina sia con array di int che di stringhe
```

</details>

<details>
<summary>09 - DICHIARARE LISTA DI STRINGHE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();                         //diamond invece di quadre
        nomi.Add("Alex");
        nomi.Add("Mario");
        nomi.Add("Luigi");
        Console.WriteLine($"Ciao {nomi[0]}, {nomi[1]} e {nomi[2]}!");
    }
}
//aggiunta di un elemento attraverso un metodo (in questo caso metodo Add)
//ogni elemento deve essere tra parentesi, e viene inserito nell'ordine in cui li mettiamo
```

</details>

<details>
<summary>10 - DICHIARARE LISTA DI INTERI</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        List<int> numeri = new List<int>();
        numeri.Add(10);
        numeri.Add(5);
        numeri.Add(20);
        numeri.Add(numeri[0]+numeri[1]+numeri[2]);
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}, il totale è {numeri[0+1+2]}!");
    }
}
```

</details>

<details>
<summary>11 - DICHIARARE LISTA DI STRINGHE - METODO .Count</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        nomi.Add("Alex");
        nomi.Add("Mario");
        nomi.Add("Luigi");
        Console.WriteLine($"I nomi sono {nomi[0]}, {nomi[1]} e {nomi[2]}!");
        Console.WriteLine($"I nomi sono {nomi.Count}!");
    }
}

```

</details>

<details>
<summary>12 - DICHIARARE PILA DI STRINGHE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        Stack<string> nomi = new Stack<string>();
        nomi.Push("Alex");
        nomi.Push("Mario");
        nomi.Push("Luigi");
        Console.WriteLine($"Ciao {nomi.Pop()}, {nomi.Pop()} e {nomi.Pop()}!");
    }
}
```

</details>

<details>
<summary>13 - DICHIARARE CODA DI STRINGHE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        Queue<string> nomi = new Queue<string>();
        nomi.Enqueue("Alex");
        nomi.Enqueue("Mario");
        nomi.Enqueue("Luigi");
        Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()} e {nomi.Dequeue()}!");
    }
}
```

</details>

<details>
<summary>14 - DICHIARAZIONI SEMPLIFICATE</summary>

```C#
int[] numeri = new int[] {1,2,3,4,5}                                                //iniz.array interi
string[] nomi = new string[] {"Alex", "Luigi"}                                      //iniz array stringhe
List<int> listnumeri = new List<int> {1,2,3,4,5}                                    //iniz list interi
List<string> listanomi = new List<string> {"Mario","Luigi"}                         //iniz.list string
Stack<int> pilanumeri = new Stack<int> (new int[] {1,2,3,4,5})                      //iniz.pila interi
Queue<string> codanomi = new Queue<string>(new string[] {"Mario","Luigi"} )         //iniz. coda string
```

</details>

<details>
<summary>15 - REMOVE/INSERT/ADD IN LIST</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        List<int> numeri = new List<int>{10, 5, 20};
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}\n");


        numeri.Insert(2, 100);
        Console.WriteLine($"Aggiungo 100 in posizione [2]");
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]} e {numeri[3]}\n");


        numeri.Remove(100);
        Console.WriteLine($"Rimuovo 100");
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]} e {numeri[2]}\n");


        numeri.Add(50);
        Console.WriteLine($"Aggiungo 50");
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]} e {numeri[3]}\n");

    }
}
```

</details>

<details>
<summary>16 - REMOVE (x numero/x indice)</summary>

```C#

class Program
{
    static void Main(string[] args)
    {
        List<int> numeri = new List<int>{10, 5, 20, 10, 4, 5};
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]}, {numeri[3]} e {numeri[4]}, {numeri[5]}\n");

        //  PER NUMERO
        numeri.Remove(10);
        Console.WriteLine($"Rimuovo 10");
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]},  {numeri[2]} e {numeri[3]}\n");

        //  PER INDICE
        numeri.Remove(numeri[0]);
        numeri.Remove(numeri[0]);
        Console.WriteLine($"Rimuovo i primi due numeri  ");
        Console.WriteLine($"I numeri sono {numeri[0]}, {numeri[1]}, {numeri[2]} e {numeri[3]}\n");

    }
}
```

</details>

<details>
<summary>17 - ARRAY JOIN</summary>

```C#
class Program
{
    static void Main(string[] args)
    {

        string[] nomi=new[]{"Alex", "Simo", "Fabio", "Ale"};                //Join và con le stringhe. Se vuoi interi devi renderle stringhe

        string nomiconcatenati=string.Join(", ", nomi);                      //unisce tutti gli elementi dell'array nomi in una singola stringa, separati da virgola e spazio
        Console.WriteLine($"Array nomi: {nomiconcatenati}");
    }
}
```

</details>

<details>
<summary>18 - IF</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        int a=10;
        int b=20;
        if(a>b){
            Console.WriteLine($"{a} è maggiore di {b}");
        }
        else if(a<b)
            {
                Console.WriteLine($"{a} è minore di {b}");
            }
            else
            {
            Console.WriteLine($"{a} è uguale a {b}");
            }
    }
}
```

</details>

<details>
<summary>19 - SWITCH</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        int a=100;
        switch(a)
        {
            case 10:
                Console.WriteLine($"{a} è uguale a 10");
                break;
            case 20:
                Console.WriteLine($"{a} è uguale a 20");
                break;
            default:
                Console.WriteLine($"{a} NON è uguale a 10 o 20");
                break;
        }
    }
}
```

</details>

<details>
<summary>20 - DICHIARARE DIZIONARIO DI STRINGHE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        //  ESEMPIO 1
        Dictionary<string, string> nomi = new Dictionary<string, string>();
        nomi.Add("Mario", "Rossi");
        nomi.Add("Luigi", "Verdi");
        nomi.Add("Paolo", "Bianchi");
        Console.WriteLine($"Ciao {nomi["Mario"]}, {nomi["Luigi"]} e {nomi["Paolo"]}");

        //  ESEMPIO 2
         Dictionary<string, int> nomi = new Dictionary<string, int>
        {
        {"Scarpa", 54335},
        {"Maglia", 21325},
        {"Felpa", 64567}
        };
        Console.WriteLine($"Codici: {nomi["Scarpa"]}, {nomi["Maglia"]} e {nomi["Felpa"]}");
    }
}
```

</details>

<details>
<summary>21 - CICLO FOR</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        for(int i=0;i<5;i++){
            Console.WriteLine($"Il valore di i è {i}");
        }
    }
}
```

</details>

<details>
<summary>22 - CICLO FOREACH</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        // ciclo foreach con array di string
        string[] nomi = new string[3];
        nomi[0]= "Mario";
        nomi[1]= "Luigi";
        nomi [2]= "Paolo";

        foreach(string nome in nomi)
        {
        Console.WriteLine($"Ciao {nome}");
        }

        //ciclo foreach con lista di string
        List<string> nomi = new List<string>();
        nomi.Add("Mario");
        nomi.Add("Luigi");
        nomi.Add("Paolo");

        //List<string> nomi = new List<string>{"Mario","Luigi","Paolo"};

        foreach(string nome in nomi){

        Console.WriteLine($"Ciao {nome}");
    }
    }
}
```

</details>

<details>
<summary>23 - CICLO FOREACH + PROPRIETA' KEYS</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        //utilizzare ciclo foreach e la proprietà keys per scoprire quali chiavi sono presenti in un dizionario
        Dictionary<string, int> eta = new Dictionary<string, int>
        {
        {"Mario", 25},
        {"Luigi", 30},
        {"Paolo", 23}
        };

    foreach(string chiave in eta.Keys){

        Console.WriteLine($"Il signor {chiave} ha {eta[$"{chiave}"]} anni");
    }
    }
}
```

</details>

<details>
<summary>24 - ES. SU STRUTTURE, CICLI, CONDIZIONI</summary>

```C#
//FACCIO UN CICLO SU UN ARRAY DI STRINGHE, SE TROVO IL NOME MARIO LO AGGIUNGE AD UNA NUOVA LISTA CON .Add

class Program
{
    static void Main(string[] args)
    {
        string[] nome = new string[8];
        nome[0]= "Alex";
        nome[1]= "Mario";
        nome[2]= "Luigi";
        nome[3]= "Mario";
        nome[4]= "Luigi";
        nome[5]= "Alex";
        nome[6]= "Mario";
        nome[7]= "Luigi";


        List<string> lista = new List<string>();
        int i=0;
        foreach(string nomi in nome){

        if(nomi=="Mario"){

            lista.Add(nomi);
            i++;
        }

        }

        Console.WriteLine($"\nI nomi sono {i}:");
        foreach(string names in lista){
        Console.WriteLine($"{names} ");
        }
        Console.WriteLine($"\n");
    }
}
```

</details>

<details>
<summary>25 - PARSE / CONVERSIONI</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        int intero = 1;
        double decimale = 1.4;

        string stringa = "2";

        int decimaleAInt = Convert.ToInt32(decimale);                   //DOUBLE TO INT
        int sommaInt = intero + decimaleAInt;
        double sommaDec = intero + decimale;                            //questa non richiede la conversione da int a double

        Console.WriteLine($"Somma intera di int+double={sommaInt}");
        Console.WriteLine($"Somma decimale di int+double={sommaDec}");

        int stringaAInt = Int32.Parse(stringa);                          //STRING TO INT
        sommaInt = intero + stringaAInt;
        Console.WriteLine($"Somma interi con stringa={sommaInt}");

        string intAString = intero.ToString();                           //INT A STRING
        string sommaStringhe = stringa + intAString;
        Console.WriteLine($"Somma stringhe={sommaStringhe}");

    }
}
```

</details>

<details>
<summary>26 - WHILE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        string[] nome = new string[3];
        nome[0]= "Alex";
        nome[1]= "Mario";
        nome[2]= "Luigi";


        int i=0;
        while(i<nome.Length)
        {
         Console.WriteLine($"Ciao {nome[i]}");
         i++;
        }
    }
}
```

</details>

<details>
<summary>27 - RILEVA COMBINAZIONE TASTI PREMUTI</summary>

```C#

// non si possono utilizzare combinazioni già utilizzate da vscode
// se non ctrl + C col comando TreatControlCAsInput
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Premi 'Ctrl' + 'N' per terminare...");

        while (true)

        {   //aspetto finchè non viene premuto un tasto
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            //verifica se il tasto Ctrl è tenuto premuto
            if((keyInfo.Modifiers & ConsoleModifiers.Control) !=0)
            {
                //controlo se il tasto premuto è N
                if(keyInfo.Key == ConsoleKey.N)

                {
                    Console.WriteLine("Combinazione CTRL + N rilevata, uscita in corso...");
                    break;
                }

            }
        }
    }
}
```

</details>

<details>
<summary>28 - SWITCH - GESTIONE INPUT COMPLESSI</summary>

```C#
class Program   //gestione di input complessi
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci un comando speciale (es: cmd:info, cmd:exit): ");

        while(true)
        {

            string? input = Console.ReadLine();

            //analizza l'input per vedere se segue un formato specifico
            if(input.StartsWith("cmd:"))
            {

                string comando = input.Substring(4);

                switch (comando.ToLower())
                {

                    case "info":
                        Console.WriteLine("Comando 'info' riconosciuto. Mostrando le informazioni...");
                        break;
                    case "name":
                        Console.WriteLine("Comando 'name' riconosciuto. Name: Alex...");
                        break;
                    case "exit":
                        Console.WriteLine("Comando riconosciuto. Uscita in corso...");
                        return;
                    default:
                        Console.WriteLine($"Comando '{comando}' non riconosciuto.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input non valido. Inserisci un comando.");
            }

            Console.WriteLine("\nInserisci un altro comando:");
        }
    }
}
```

</details>

<details>
<summary>29 - SWITCH + READLINE</summary>

```C#
class Program   //gestione di input complessi
{
    static void Main(string[] args)
    {


        Console.WriteLine("Inserisci il tuo nome: ");
        string? nome=Console.ReadLine();


        while(true)
        {

            Console.WriteLine("\nSeleziona opzione: ");
            Console.WriteLine("ciao - salutami");
            Console.WriteLine("exit - esci");

            string? input = Console.ReadLine();

                switch (input.ToLower())
                {

                    case "ciao":
                        Console.WriteLine($"\nCiao {nome}!");
                        break;
                    case "exit":
                        Console.WriteLine("\nComando riconosciuto. Uscita in corso...");
                        return;
                    default:
                        Console.WriteLine("\nOpzione non riconosciuta.");
                        break;
                }
        }
    }
}
```

</details>

<details>
<summary>30 - DRAG & DROP</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Trascina un file qui e premi invio");
        string filePath = Console.ReadLine().Trim('"');       //rimuove le virgolette che possono apparire nel percorso

        try
        {
            string content = File.ReadAllText(filePath);
            Console.WriteLine("Contenuto del file:");
            Console.WriteLine(content);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore!!!: {ex.Message}");
        }
    }
}
```

</details>

<details>
<summary>31 - NASCONDI CURSORE, CLEAR, BEEP, TITOLO</summary>

```C#
class Program
{
    static void Main(string[] args)
    {

        Console.Clear();
        Console.WriteLine("Seleziona l'opzione:\n1 - mostra cursore\n2 - nascondi cursore\n3 - clear console\n4 - beep\n5 - beep lungo\n6 - titolo\ne - esci");

        while(true)
        {
            Console.WriteLine("Digita...");
            string? input = Console.ReadLine();


            switch(input)
            {

                case "1":
                Console.CursorVisible=false;
                break;

                case "2":
                Console.CursorVisible=true;
                break;

                case "3":
                Console.Clear();
                break;

                case "4":
                    Console.Beep();
                    break;

                case "5":
                    Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Inserisci la durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());

                    Console.Beep(freq, ms);
                    break;

                case "6":
                    Console.Title = "La mia app";
                    break;

                case "e":
                    return;

                default:
                    Console.WriteLine("Opzione inesistente, riprova: ");
                    break;

            }
        }
    }
}
```

</details>

<details>
<summary>32 - DO WHILE</summary>

```C#
class Program
{
    static void Main(string[] args)
    {

        Console.Clear();        //pulisce schermo iniziale
        bool continua=true;
        do
        {
            Console.Clear();        //pulisce schermo e mantiene il menu nella stessa posizione

            //stampa il menù
            Console.WriteLine("Menù di selezione:");
            Console.WriteLine("1 - opzione uno");
            Console.WriteLine("2 - opzione due");
            Console.WriteLine("3 - opzione tre");
            Console.WriteLine("4 - esci");
            Console.Write("Scegli un'opzione: ");
            string? scelta=Console.ReadLine();

            switch(scelta){

                case "1":
                    Console.WriteLine("Hai selezionato l'opzione uno");
                    break;

                case "2":
                    Console.WriteLine("Hai selezionato l'opzione due");
                    break;

                case "3":
                    Console.WriteLine("Hai selezionato l'opzione tre");
                    break;

                case "4":
                    Console.WriteLine("Uscita in corso...");
                    continua=false;
                    break;

                default:
                    Console.WriteLine("Selezione non valida.");
                    break;
            }

            if(continua)
            {
                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();      //aspetta che l'utente prema un tasto prima di mostrare di nuovo il menù
            }
        }
        while(continua);
    }
}
```

</details>

<details>
<summary>33 - TIMER + TASK</summary>

```C#
class Program
{
    static async Task Main(string[] args)
    {

        int timeoutInSeconds=5;                                                         //imposta tempo d'attesa
        Task inputTask=Task.Run(()=>
        {
            Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi: ");
            return Console.ReadLine();
        });

        Task delayTask = Task.Delay(TimeSpan.FromSeconds(timeoutInSeconds));

        if (await Task.WhenAny(inputTask, delayTask)==inputTask)
        {                                                                               //l'utente ha inserito un input
            string input=await(inputTask as Task<string>);
            Console.WriteLine($"Hai inserito {input}.");
        }
        else
        {
            Console.WriteLine("Tempo scaduto!");
        }
    }

    //Task.WhenAny viene usato per attendere che uno dei due task si completi
}
```

</details>

<details>
<summary>34 - TIMER</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        int timeoutInSeconds=5;
        Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi: ");

        bool inputReceived=false;                                                       //inizializza input come non ricevuto finche non si verifica il console.KeyAvaiable

        string? input="";                                                               /*iniz. var string chiamata input con una stringa vuota cosi puoi assegnare un valore a
                                                                                        input all'interno del ciclo e puoi accedere a quel valore anche al di fuori del ciclo*/

        DateTime endTime= DateTime.Now.AddSeconds(timeoutInSeconds);                    /*DateTime.Now restituisce l'ora corrente. Il metodo AddSeconds (timeoutInSeconds) aggiunge il numero specificato di secondi (in questo caso, il valore della variabile timeoutInSeconds) all'ora corrente. Il risultato è un DateTime che rppresenta il momento esatto quando il tempo di attesa è in scadenza.*/

        while(DateTime.Now < endTime)                                                   /*il ciclo while (DateTime.Now<endtime) continua a eseguirsi finchè l'ora corrente
                                                                                        (DateTime.Now) è inferiore a endTime. Questo significa che il ciclo continuerà a
                                                                                        girare per la durata specificata da timeoutInSeconds(5)*/
        {

            if(Console.KeyAvailable)                                                    /*viene utilizzato per verificare se è stato premuto un tasto, permettendo al programma
                                                                                        di reagire immediatamente all'input dell'utente senza bloccare l'esecuzione*/
            {

                input=Console.ReadLine();
                inputReceived=true;                                                     /*dato che il valore di input viene controllato dopo il ciclo per verificare se l'utente
                                                                                        ha fornito un input, inizializzandola con una stringa vuota si stabilisce un valore di
                                                                                        partenza noto. Se input rimane una stringa vuota dopo il ciclo, significa che l'utente
                                                                                        non ha inserito alcun dato*/
                break;
            }

            Thread.Sleep(100);                                                          //piccola pausa per ridurre il peso sulla CPU
        }
        if(inputReceived)
        {
            Console.WriteLine($"Hai inserito: {input}");
        }
        else{

            Console.WriteLine("Tempo scaduto!");
        }
    }
}
```

</details>

<details>
<summary>35 - SPLIT</summary>

```C#
class Program
{
    static void Main(string[] args)
    {

        string frase = "The quick brown fox jumps over the lazy dog.";
        string[] parole = frase.Split(' ');

        foreach (var parola in parole)
        {
            Console.WriteLine($"{parola} ");
        }
    }
}
```

</details>

<details>
<summary>36 - RANDOM</summary>

```C#
class Program
{
    //genera 10 numeri random e fai somma
    static void Main(string[] args)
    {
        Random random=new Random();                                         //generatore numeri casuali

        int somma=0;
        for(int i=0;i<10;i++){

            int numero=random.Next(1, 11);                                  //genera numeru casuali tra 1 e 10, si dice che l'intervallo è [1,11) cioè l'intervallo semiaperto
            somma+=numero;
            Console.WriteLine($"Il numero casuale è {numero}");
        }
        Console.WriteLine($"La somma è {somma}");
    }
}
```

</details>

<details>
<summary>37 - COLORI</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Qua non metto colore");
        Console.BackgroundColor=ConsoleColor.Red;
        Console.WriteLine("Cosi coloro il background");
        Console.ResetColor();
        Console.ForegroundColor=ConsoleColor.Yellow;
        Console.WriteLine("Cosi coloro le scritte");
        Console.ResetColor();
        Console.WriteLine("Cosi torno al default");
    }
}
```

</details>

<details>
<summary>38 - ESTRARRE NOME RANDOM DA ARRAY / LISTA</summary>

```C#

//  ESTRARRE NOME RANDOM DA ARRAY
class Program
{
    static void Main(string[] args)
    {
        string[] nomi = ["Mario", "Alex", "Luigi"];
        Random random=new Random();
        int indice=random.Next(0,3);                                        //(0, nomi.Lenght)
        Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");
    }
}


//  ESTRARRE NOME RANDOM DA LISTA
class Program
{
    static void Main(string[] args)
    {
        List<string> nomi = new List<string>();
        string nome="";
        while(nome!="x")    //  NOMI IMMESSI DA INPUT
        {
            Console.WriteLine("Inserisci un nome (x per terminare): ");
            nome=Console.ReadLine();
            if(nome!="x")
            {
                nomi.Add($"{nome}");
            }
        }

        Random random=new Random();
        int indice=random.Next(0,nomi.Count);
        Console.WriteLine($"\nIl nome sorteggiato è {nomi[indice]}\n");
    }
}
```

</details>

<details>
<summary>39 - ETICHETTA</summary>

```C#
class Program
{
    static void Main(string[] args)
    {
        int input=1;
        etichetta:
            switch(input)
            {
                case 1:Console.WriteLine("Caso 1");
                    break;
                case 2:Console.WriteLine("Caso 2");
                    break;
                case 0:Console.WriteLine("esci...");
                    return;
            }

            Console.Write("\nDigita input (1, 2, 0): ");
            input=Int32.Parse(Console.ReadLine()!);
            goto etichetta;
    }
}
```

</details>

<details>
<summary>40 - TRY / CATCH</summary>

```C#

//  per gestire System.IO.FileNotFoundException (se si tenta di leggere un file inesistente)
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string contenuto=File.ReadAllText("file.txt");
            Console.WriteLine(contenuto);
        }

        catch(Exception e)
        {
            Console.WriteLine("Il file non esiste");
            return;
        }
    }
}

//  per gestire System.IndexOutOfRangeException (se si tenta di accedere ad un indice inesistente)
class Program
{
    static void Main(string[] args)
    {
        int[]numeri={1,2,3};
        try
        {
            Console.WriteLine(numeri[3]);
        }

        catch(Exception e)
        {
            Console.WriteLine("Indice non valido");
            return;
        }
    }
}

//  per gestire System.NullReferenceException (se si tenta di accede a oggetto null)
class Program
{
    static void Main(string[] args)
    {
        string nome="null";
        try
        {
            Console.WriteLine(nome.Length);
        }

        catch(Exception e)
        {
            Console.WriteLine("Nome non valido");
            return;
        }
    }
}


//  per gestire Out of memory
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] numeri=new int[int.MaxValue];  //valore massimo che puo contenere un int (2.147.483.591) percio il progr. si blocca se vai oltre
        }

        catch(Exception e)
        {
            Console.WriteLine("Memoria insufficiente");
            return;
        }
    }
}

//  per gestire System.FormatException
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero=int.Parse("ciao");   //il metodo .Parse genera un'eccezione perche ciao non è numero
        }

        catch(Exception e)
        {
            Console.WriteLine("Numero non valido");
            return;
        }
    }
}


//  per gestire System.ArgumentNullException & System.OverflowException
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int numero=int.Parse(null);   //il metodo .Parse genera un'eccezione perche ciao non è numero
                                          //se metto un numero troppo grosso genero un errore System.OverflowException
        }

        catch(Exception e)
        {
            Console.WriteLine("Numero non valido");
            Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
            Console.WriteLine($"CODICE ERRORE: {e.HResult}");
            return;
        }
    }
}

//  System.IO.FileNotFoundException + FINALLY (qui inutile ma d'esempio)
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string contenuto=File.ReadAllText("testo.txt");
            Console.WriteLine(contenuto);
        }

        catch(Exception e)
        {
            Console.WriteLine("Il file non esiste");
            return;
        }
        finally
        {
            Console.WriteLine("Il file è stato chiuso");
        }
    }
}

//  Vogliamo verificare che un numero inserito dall'utente sia compreso un intervallo specifico

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Inserisci un numero tra 1 e 100: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            if (numero < 1 || numero > 100)
            {
                throw new ArgumentOutOfRangeException("Il numero deve essere compreso tra 1 e 100.");
            }

            Console.WriteLine($"Il numero inserito è: {numero}");
        }
        catch (FormatException)
        {
            Console.WriteLine("L'input non è un numero valido.");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Si è verificato un errore imprevisto: {e.Message}");
        }
    }
}

```

</details>


<details>
<summary>41 - LETTURA FILE .TXT</summary>

```C#

// legge un testo e lo stampa
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.txt";                          //il file dev'essere nella stessa cartella del programma
        string[]lines= File.ReadAllLines(path);             //legge tutte le righe del file

        foreach(string line in lines)
        {
            Console.WriteLine(line);                        //stampa la riga
        }
    }
}

// fa la stessa cosa ma in modo più controllato, l'altro era alla cazzo, questo crea una copia da leggere
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.txt";                          //il file dev'essere nella stessa cartella del programma
        string[]lines= File.ReadAllLines(path);             //legge tutte le righe del file
        string[]nomi=new string[lines.Length];              //crea array di stringhe con lunghezza del numero di righe del file

        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i];                               //assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }

        foreach(string nome in nomi)
        {
            Console.WriteLine(nome);                        //stampa la riga
        }
    }
}

// fa la stessa cosa ma aggiunge all'array le righe secondo un criterio (es. quelle che iniziano con A)
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.txt";                          //il file dev'essere nella stessa cartella del programma
        string[]lines= File.ReadAllLines(path);             //legge tutte le righe del file
        string[]nomi=new string[lines.Length];              //crea array di stringhe con lunghezza del numero di righe del file

        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i];                               //assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }

        bool vuoto=true;
        foreach(string nome in nomi)
        {
            if(nome.StartsWith('a'))
            {

                Console.WriteLine(nome);                        //stampa la riga
                vuoto=false;
            }
        }

        if(vuoto)
        {
            Console.WriteLine("Non ci sono righe che iniziano con questa lettera.");
        }
    }
}

// se volessi usare un LAMBDA   (e non uso il bool)

    if(!nomi.Any(nome=>nome.StartsWith('a')))
```

</details>

<details>
<summary>42 - CREAZIONE FILE .TXT</summary>

```C#

// parto da un txt e voglio creare un nuovo txt solo con la mia sElezione (es.le righe che iniziano con 'a')
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.txt";                          //il file dev'essere nella stessa cartella del programma
        string[]lines= File.ReadAllLines(path);             //legge tutte le righe del file
        string[]nomi=new string[lines.Length];              //crea array di stringhe con lunghezza del numero di righe del file

        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i];                               //assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
        }


        string path2=@"test2.txt";
        File.Create(path2).Close();                         //crea il file e lo chiude

        foreach(string nome in nomi)
        {
            if(nome.StartsWith('a'))
            {

                File.AppendAllText(path2, nome + "\n");
            }
        }
    }
}

```

</details>

<details>
<summary>43 - STAMPARE DATI PRESI DA UN FILE .TXT</summary>

```C#

// programma che legge un file di testo txt contenente dei nomi ed utilizza il metodo random per sorteggiare il nome da stampare
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.txt";
        string[]lines= File.ReadAllLines(path);
        string[]nomi=new string[lines.Length];
        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i];
        }


        Random random = new Random();
        int index = random.Next(nomi.Length);
        Console.WriteLine(nomi[index]);
    }
}


// programma che legge un file di testo txt contenente dei nomi ed utilizza il metodo random per sorteggiare un nome
// poi aggiumge il nome ad un file txt, se il file non esiste prima lo crea
// se il nome è gia presente nel file, non lo aggiunge e ti dice che è già esistente
class Program
{
    static void Main(string[] args)
    {

        string path = @"test.txt";
        string[]lines= File.ReadAllLines(path);
        string[]nomi=new string[lines.Length];
        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i];                                              //assegna ad ogni elem dell'array il valore della riga corrispondente
        }

        Random random = new Random();
        int index = random.Next(nomi.Length);                               //genera numero casuale tra 0 e lunghezza dell'array
        Console.WriteLine(nomi[index]);                                     //stampa il nome corrispondente dell indice generato casualmente
        string path2=@"test2.txt";

        if(!File.Exists(path2))
        {
            File.Create(path2).Close();                                     //crea il file
        }
        if(!File.ReadAllLines(path2).Contains(nomi[index]))                 //controlla se il sorteggiato è gia presente
        {
            File.AppendAllText(path2, nomi[index]+"\n");                    //scrive la riga nel file
        }
        else
        {
            Console.WriteLine("Il nome è gia presente nel file");
        }

    }
}
```

</details>

<details>
<summary>44 - STAMPARE DATI PRESI DA UN FILE .CSV</summary>

```C#
class Program
{
    static void Main(string[]args)
    {

        string path=@"test.csv";
        string[]lines=File.ReadAllLines(path);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }

    }
}

//  programma che legge un file csv creando un array di stringhe per ogni riga del file e divide ogni riga in un array di stringhe utilizzando la virgola come separatore

class Program
{
    static void Main(string[]args)
    {

        string path=@"test.csv";
        string[]lines=File.ReadAllLines(path);

        string[][]nomi=new string[lines.Length][];

        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i].Split(',');
        }


        foreach(string[] nome in nomi)
        {
                foreach(string n in nome)
                {
                    Console.WriteLine(n);
                }
                Console.WriteLine();
        }

    }
}

//  programma che legge un file csv creando un array di stringhe per ogni riga del file e divide ogni riga in un array di stringhe utilizzando la virgola come separatore
//  poi crea un file csv per ogni riga del file con il nome del file che corrisponde al nome della prima colonna ed il contenuto del file che corrisponde al contenuto
//  delle altre colonne disponibile

using System.Security.Cryptography;

class Program
{
    static void Main(string[]args)
    {

        string path=@"test.csv";                    //Il file deve essre nella stessa cartella del prog
        string[]lines=File.ReadAllLines(path);      //legge tutte le righe del file

        string[][]nomi=new string[lines.Length][];  //crea array di string con lunghezza del numero righe del file

        for(int i=0;i<lines.Length;i++)
        {
            nomi[i]=lines[i].Split(',');            //assegna ad ogni elemento dell'array il val della riga corrispondente dvisa ini u narray di stringhe con virgola come separatore
        }


        foreach(string[] nome in nomi)
        {
                string path2=nome[0]+".csv";        //il file deve essere nella stessa cartella
                File.Create(path2).Close();         //crea il file
                for(int i=1;i<nome.Length;i++)
                {
                    File.AppendAllText(path2, nome[i]+"\n");    //scrive la riga del file
                }
        }
        File.Delete("nome.csv");    //elimino il file csv che contiene le intestazioni delle colonne
    }
}

```

</details>

<details>
<summary>45 - CREAZIONE E MODIFICA FILE .CSV</summary>

```C#



// programma che chiede di inserire una serie di nomi cognomi eta, andando a capo ogni volta, e li salva in un file csv

class Program
{
    static void Main(string[]args)
    {

        string path=@"test.csv";
        File.Create(path).Close();

        while(true)
        {
            Console.WriteLine("Inserisci nome, cognome e età");
            string nome=Console.ReadLine()!;
            string cognome=Console.ReadLine()!;
            string eta=Console.ReadLine()!;

            File.AppendAllText(path, nome+","+cognome+","+eta+"\n");
            Console.WriteLine("Vuoi inserire un altro nome? (s/n)");

            string risposta=Console.ReadLine()!;

            if(risposta=="n")
            {
                break;
            }
        }

    }
}


// programma che chiede di inserire una serie di nomi cognomi eta, andando a capo ogni volta, e li salva in un file csv
// se il nome è gia presente nel file non lo aggiunge

class Program
{
    static void Main(string[] args)
    {

        string path=@"test.csv";
        File.Create(path).Close();

        while(true)
        {
            Console.WriteLine("Inserisci nome, cognome e età");
            string nome=Console.ReadLine()!;
            string cognome=Console.ReadLine()!;
            string eta=Console.ReadLine()!;
            string[]lines=File.ReadAllLines(path);
            bool found=false;

            foreach(string line in lines)
            {
                if(line.StartsWith(nome))
                {
                    found=true;
                    break;
                }
            }

            if(!found)
            {
                File.AppendAllText(path, nome+","+cognome+","+eta+"\n");
            }
            else
            {
                Console.WriteLine("Il nome è gia presente nel file");
            }


            Console.WriteLine("Vuoi inserire un altro nome? (s/n)");
            string risposta=Console.ReadLine()!;
            if(risposta=="n")
            {
                break;
            }
        }

    }
}



// programma che chiede di inserire una serie di nomi cognomi eta, andando a capo ogni volta, e li salva in un file csv
// se il nome è gia presente nel file modifica solo l'eta

class Program
{
    static void Main(string[] args)
    {

        string path=@"test.csv";
        File.Create(path).Close();

        while(true)
        {
            Console.WriteLine("Inserisci nome, cognome e età");
            string nome=Console.ReadLine()!;
            string cognome=Console.ReadLine()!;
            string eta=Console.ReadLine()!;


            if(!File.ReadAllLines(path).Any(line=>line.StartsWith(nome)))       //uso lambda ma andava bene un bool
            {
                File.AppendAllText(path, nome+","+cognome+","+eta+"\n");
            }
            else
            {
                string[]lines=File.ReadAllLines(path);
                string[][]nomi=new string[lines.Length][];

                for(int i=0;i<lines.Length;i++)
                {
                    nomi[i]=lines[i].Split(",");
                }

                for(int i=0;i<nomi.Length;i++)
                {
                    if(nomi[i][0]==nome)
                    {
                        nomi[i][2]=eta;
                    }
                }

                File.Delete(path);
                File.Create(path).Close();

                foreach(string[]n in nomi)
                {
                    File.AppendAllText(path,n[0]+","+n[1]+","+n[2]+"\n");
                }
            }

            Console.WriteLine("Vuoi inserire un altro nome? (s/n)");
            string risposta=Console.ReadLine()!;
            if(risposta=="n")
            {
                break;
            }
        }

    }
}

```

</details>

<details>
<summary>46 - LETTURA FILE .CSV DA INPUT</summary>

```C#

// programma che chiede legge file csv da input
class Program
{
    static void Main(string[] args)
    {

            string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), ".*.csv");

            foreach(string file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("Quale file vuoi leggere?");
            string fileScelto = Console.ReadLine()!;

            string[] lines=File.ReadAllLines(fileScelto);

            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
    }
}

// programma che elimina file csv chiedendolo da input
class Program
{
    static void Main(string[] args)
    {

            string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), ".*.csv");

            foreach(string file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("Quale file vuoi eliminare?");
            string fileScelto = Console.ReadLine()!;

            if(File.Exists(fileScelto))
            {
                File.Delete(fileScelto);
            }
            else
            {
                Console.WriteLine("Il file non esiste.");
            }

    }
}



// programma che legge quali file csv sono presenti nella cartella del programma e stampa i nomi dei files come se fossero elementi di un menu
//poi chiede quale leggere e lo stampa
class Program
{
    static void Main(string[] args)
    {

            string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");   //legge tutti i file csv nella cartella

            foreach(string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));                                  //stampa solo il nome del file
            }

            Console.WriteLine("Quale file vuoi leggere?");
            string fileScelto = Console.ReadLine()!;                                        //legge il nome del file scelto

            if(File.Exists(fileScelto))                                                     //controlla se il file esiste
            {
                string[] lines= File.ReadAllLines(fileScelto);                              //legge tutte le righe del file
                foreach(string line in lines)
                {
                    Console.WriteLine(line);                                                //stampa la riga
                }
            }
            else
            {
                Console.WriteLine("Il file non esiste.");
            }

    }
}


// programma che legge quali file csv sono presenti nella cartella del programma e stampa i nomi dei files come se fossero elementi di un menu
// poi puoi scegliere se leggere o eliminare un file
class Program
{
    static void Main(string[] args)
    {
           // Console.WriteLine("\n");
            Console.Clear();
            string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");   //legge tutti i file csv nella cartella

            foreach(string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));                                  //stampa solo il nome del file
            }

            Console.Write("\nVuoi leggere o eliminare un file? (l/e): ");
            string risposta=Console.ReadLine()!;

            if(risposta=="l")
            {
                Console.Write("Quale file vuoi leggere? ");
                string fileScelto = Console.ReadLine()!;

                if(File.Exists(fileScelto))
                {

                    string[] lines= File.ReadAllLines(fileScelto);                              //legge tutte le righe del file
                    foreach(string line in lines)
                    {
                        Console.WriteLine(line);                                                //stampa la riga
                    }
                }
                else
                {
                    Console.WriteLine("Il file non esiste.");
                }

            }

            else if(risposta=="e")
                    {
                        Console.Write("Quale file vuoi eliminare? ");
                        string fileScelto = Console.ReadLine()!;

                        if(File.Exists(fileScelto))
                        {
                            File.Delete(fileScelto);
                        }
                        else
                        {
                            Console.WriteLine("Il file non esiste.");
                        }
                    }

             else
             {
                Console.WriteLine("Selezione non disponibile.");
             }

    }
}


// programma che legge quali file csv sono presenti nella cartella del programma e stampa i nomi dei files come se fossero elementi di un menu
// poi puoi scegliere se leggere o eliminare un file
// versione con try e catch
class Program
{
    static void Main(string[] args)
    {
           // Console.WriteLine("\n");
            Console.Clear();
            string[] files=Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");   //legge tutti i file csv nella cartella

            foreach(string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));                                  //stampa solo il nome del file
            }

            Console.Write("\nVuoi leggere o eliminare un file? (l/e): ");
            string risposta=Console.ReadLine()!;



            if(risposta=="l")
            {
                Console.Write("Quale file vuoi leggere? ");
                string fileScelto = Console.ReadLine()!;


                try
                {

                    string[] lines= File.ReadAllLines(fileScelto);                              //legge tutte le righe del file
                    foreach(string line in lines)
                    {
                        Console.WriteLine(line);                                                //stampa la riga
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Il file non esiste.");
                }
            }

            else if(risposta=="e")
                    {
                        Console.Write("Quale file vuoi eliminare? ");
                        string fileScelto = Console.ReadLine()!;

                        try
                        {
                            File.Delete(fileScelto);
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("Il file non esiste.");
                        }
                    }

             else
             {
                Console.WriteLine("Selezione non disponibile.");
             }

    }
}



```

</details>

<details>
<summary>47 - FUNZIONI</summary>

```C#
class Program
{
    static void Main(string[]args)
    {

       Console.WriteLine("Inserisci un numero");
       int numero=int.Parse(Console.ReadLine()!);

       StampaPari(numero);

       Console.WriteLine("Inserisci un messaggio");
       string messaggio=(Console.ReadLine()!);
       Console.WriteLine("Quante volte vuoi stamparlo?");
       int volte=int.Parse(Console.ReadLine()!);

       Stampa(messaggio, volte);


    }

    static bool Pari(int numero)                //restituisce valore booleano
    {
        return numero%2==0;
    }

    static void StampaPari(int numero)
    {
        if(Pari(numero))
        {
            Console.WriteLine("Il numero è pari");
        }
        else
        {
            Console.WriteLine("Il numero è dispari");
        }
    }

    static void Stampa(string messaggio, int volte)
    {
        for(int i=0;i<volte;i++)
        {
            Console.WriteLine(messaggio);
        }
    }

}
```

</details>

<details>
<summary>48 - LETTURA FILE .JSON </summary>

```C#

/*------------------------------------
{
"nome": "antonio",
"cognome": "rossi",
"eta": 20
}------------------------------------
*/

//per utilizzare file json bisogna installare il pacchetto Newtonsoft.Json
// il comando va inserito nella root del progetto

using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path=@"test.json";
        string json=File.ReadAllText(path);
        Console.WriteLine(json);
    }
}


//  versione con deserializzazione di file
//  qui viene  usati Newtonsoft.Json
//  crei un oggeto del file da cui estrapoli le chiavi

using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path=@"test.json";
        string json=File.ReadAllText(path);
        dynamic obj=JsonConvert.DeserializeObject(json)!;
        Console.WriteLine($"nome: {obj.nome} cognome: {obj.cognome} eta: {obj.eta}");
    }
}




/*------------------------------------
{
    "nome": "antonio",
    "cognome": "rossi",
    "eta": 20,
    "indirizzo": {

        "via": "via roma",
        "numero": "10"
    },

    "citta":{
        
        "nome":"roma",
        "CAP": "19199"
    }
    
}-------------------------------------
*/

//  stampa livello 1 di informazione

using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path=@"test.json";
        string json=File.ReadAllText(path);
        dynamic obj=JsonConvert.DeserializeObject(json)!;
        Console.WriteLine($"nome: {obj.nome},  cognome: {obj.cognome},  eta: {obj.eta}");      //livello 0
        Console.WriteLine($"via: {obj.indirizzo.via},  numero: {obj.indirizzo.numero}");       //livello 1
        Console.WriteLine($"citta: {obj.citta.nome},  CAP: {obj.citta.CAP}");                  //livello 1
    }
}


//  prog che legge file json e lo stampa come righe su file csv che crea

using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path=@"test.json";
        string json=File.ReadAllText(path);
        dynamic obj=JsonConvert.DeserializeObject(json)!;

        string path2=@"test.csv";
        File.Create(path2).Close();
        File.AppendAllText(path2, "nome,  cognome,  eta,  via,  citta\n");
        for(int i=0;i<obj.Count;i++)
        {
            File.AppendAllText(path2, $"{obj[i].nome}, {obj[i].cognome}, {obj[i].eta}, {obj[i].indirizzo.via}, {obj[i].indirizzo.citta}\n");
        }

    }
}
```

</details>

<details>
<summary>49 - CREAZIONE FILE .JSON </summary>

```C#



 //  prog che legge file csv e per ogni oggetto crea un file json

using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path=@"test.csv";
        string []lines=File.ReadAllLines(path);
        string [][]prodotti=new string[lines.Length][];

        for(int i=0;i<lines.Length;i++)
        {
            prodotti[i]=lines[i].Split(',');

        }


        for(int i=0;i<prodotti.Length;i++)
        {
            string path2=prodotti[i][0]+".json";
            File.Create(path2).Close();
            File.AppendAllText(path2, JsonConvert.SerializeObject(new{nome=prodotti[i][0], prezzo=prodotti[i][1]}));

        }
    }
}

//  versione se il nome del prodotto esiste gia, non crea un nuovo file


            if(!File.Exists(path2))
            {
            File.Create(path2).Close();
            File.AppendAllText(path2, JsonConvert.SerializeObject(new{nome=prodotti[i][0], prezzo=prodotti[i][1]}));
            }



//  inserisci piu oggetti e crea un file json contenente tutti loro

using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {

        string path=@"test.json";
        File.Create(path).Close();
        File.AppendAllText(path, "[\n");
        while(true)
        {
            Console.WriteLine("Inserisci nome e prezzo:");
            string nome=Console.ReadLine()!;
            string prezzo=Console.ReadLine()!;
            File.AppendAllText(path, JsonConvert.SerializeObject(new{nome, prezzo}) + ",\n");
            Console.Write("Vuoi inserire un altro prodotto? ");
            string risposta=Console.ReadLine()!;
            if(risposta=="n")
            {
                break;
            }
        }

        //togli l'ultima virgola        

        string file=File.ReadAllText(path);
        file=file.Remove(file.Length -2,1);
        //  cioè vado indietro di due caratteri e ne tolgo uno
        File.WriteAllText(path, file);
        File.AppendAllText(path, "]");
    }
}
```
</details>


<details>
<summary>50 - CLASSI </summary>

```C#

//  1 - DICHIARAZIONE CLASSE SENZA COSTRUTTORE


class Persona                           //definizione della classe
{
    public string? nome;                 //definizione di un campo pubblico cioe accessibile dall'esterno
    public string? cognome;
    public int eta;
}

class Program 
{
        static void Main(string[]args)
        {
            Persona p=new Persona();        //creazione dell'oggetto di tipo Persona tramite il costruttore di default (senza parametri)
            p.nome="Mario";
            p.cognome="Rossi";
            p.eta=30;

            Console.WriteLine("Nome: "+p.nome);
            Console.WriteLine("Cognome: "+p.cognome);
            Console.WriteLine("Età: "+p.eta);
            
        }
    
}





//  2 - DICHIARAZIONE CLASSE CON COSTRUTTORE


class Persona                           //definizione della classe
{
    public string? nome;                 //definizione di un campo pubblico cioe accessibile dall'esterno
    public string? cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta)

    {
        this.nome = nome;                 //definizione di un campo pubblico cioe accessibile dall'esterno
        this.cognome=cognome;
        this.eta=eta;
    }
}

class Program
{
        static void Main(string[] args)
        {
            Persona p = new Persona("Mario", "Rossi", (30));        //creazione dell'oggetto di tipo Persona tramite il costruttore di default (senza parametri)
            Console.WriteLine("Nome: " + p.nome);
            Console.WriteLine("Cognome: " + p.cognome);
            Console.WriteLine("Età: " + p.eta);

        }

}





//  3 - CLASSE CON METODO STAMPA() AL SUO INTERNO


class Persona                           //definizione della classe
{
    public string? nome;                 //definizione di un campo pubblico cioe accessibile dall'esterno
    public string? cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta)

    {
        this.nome = nome;                 //definizione di un campo pubblico cioe accessibile dall'esterno
        this.cognome = cognome;
        this.eta = eta;
    }

    public void Stampa()
    {
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Cognome: " + cognome);
        Console.WriteLine("Età: " + eta);

    }
}

class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona("Mario", "Rossi", (30));        //creazione dell'oggetto di tipo Persona tramite il costruttore di default (senza parametri)
        p.Stampa();
    }

}





//  4 - PROPRIETA GET e SET 


class Persona
{
    private string nome; // definizione di un campo privato cioè accessibile solo all'interno della classe
    private string cognome;
    private int eta;

    public string Nome // definizione di una proprietà pubblica cioè accessibile dall'esterno
                        // la differenza fra proprietà e campo è che la proprietà può contenere codice aggiuntivo per la lettura e la scrittura
    {
        get { return nome; } // definizione del metodo get
        set { nome = value; } // definizione del metodo set (value è il valore passato alla proprietà)
    }

    public string Cognome
    {
        get { return cognome; }
        set { cognome = value; }
    }

    public int Eta
    {
        get { return eta; }
        set { eta = value; }
    }

    public Persona(string nome, string cognome, int eta) // costruttore con parametri. tra parentesi tonde ci sono i parametri
    {
        this.nome = nome; // this si riferisce all'oggetto corrente (necessario per distinguere tra il campo e il parametro)

        this.cognome = cognome;
        this.eta = eta;
    }

    public void Stampa() // definizione di un metodo pubblico cioè accessibile dall'esterno
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cognome: {cognome}");
        Console.WriteLine($"Età: {eta}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona("Mario", "Rossi", 30); // creazione di un oggetto di tipo Persona tramite il costruttore con parametri (nome, cognome, eta) sono valori di default cioè se non vengono passati valori, questi sono i valori di default che vengono assegnati
        p.Stampa(); // chiamata al metodo Stampa dell'oggetto p
        p.Nome = "Luigi"; // scrittura del campo nome tramite la proprietà Nome
        p.Stampa(); // chiamata al metodo Stampa dell'oggetto p
        // in questo caso il metodo stampa stamperà i seguenti dati:
        // Nome: Luigi
        // Cognome: Rossi
        // Età: 30
    }
}





//  5 - EREDITARIETA'


class Persona
{
    public string nome;
    public string cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
    }

    public void Stampa()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cognome: {cognome}");
        Console.WriteLine($"Età: {eta}");
    }
}

class Studente : Persona // definizione di una classe Studente che eredita dalla classe Persona
{
    public string corso;

    public Studente(string nome, string cognome, int eta, string corso) : base(nome, cognome, eta) // costruttore con parametri che chiama il costruttore della classe base
    {
        this.corso = corso; // inizializzazione del campo corso della classe Studente
    }

    public void StampaCorso()
    {
        Console.WriteLine("Corso: " + corso);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Studente s = new Studente("Mario", "Rossi", 30, "Informatica"); // creazione di un oggetto di tipo Studente tramite il costruttore con parametri
        s.Stampa(); // chiamata al metodo Stampa dell'oggetto s
        s.StampaCorso(); // chiamata al metodo StampaCorso dell'oggetto s
        // in questo caso il metodo stampa stamperà i seguenti dati:
        // Nome: Mario
        // Cognome: Rossi
        // Età: 30
        // Corso: Informatica
    }
}





//  6 - POLIMORFISMO (VIRTUAL-OVERRIDE)


class Persona
{
    public string nome;
    public string cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
    }

    public virtual void Stampa() // definizione di un metodo virtuale cioè può essere sovrascritto nelle classi derivate
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cognome: {cognome}");
        Console.WriteLine($"Età: {eta}");
    }
}

class Studente : Persona
{
    public string corso;

    public Studente(string nome, string cognome, int eta, string corso) : base(nome, cognome, eta)
    {
        this.corso = corso;
    }

    public override void Stampa() // sovrascrittura del metodo Stampa della classe base
    {
        base.Stampa(); // chiamata al metodo Stampa della classe base
        Console.WriteLine($"Corso: {corso}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Persona p = new Studente("Mario", "Rossi", 30, "Informatica"); // creazione di un oggetto di tipo Studente tramite il costruttore con parametri
        p.Stampa(); // chiamata al metodo Stampa dell'oggetto p
        // in questo caso il metodo stampa stamperà i seguenti dati:
        // Nome: Mario
        // Cognome: Rossi
        // Età: 30
        // Corso: Informatica
    }
}

```

</details>