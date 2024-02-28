class Program
{
    static void Main(string[] args)
    {
        Console.Clear();        //pulisce schermo iniziale
        bool continua=true;
        do
        {
            Console.Clear();
            
            //stampa il menù
            Console.WriteLine("Menù di selezione:");
            Console.WriteLine("1 - confronta decimali");
            Console.WriteLine("2 - dichiara lista di stringhe");
            Console.WriteLine("3 - drag & drop");
            Console.WriteLine("4 - usa il beep");
            Console.WriteLine("5 - mostra/nascondi cursore");
            Console.WriteLine("6 - confronta stringhe");
            Console.WriteLine("7 - Timeout della console");
            Console.WriteLine("8 - Rileva combinazione di tasti");
            Console.WriteLine("9 - Genera e somma numeri random nell'intervallo scelto");
            Console.WriteLine("e - esci");
            Console.Write("Scegli un'opzione: ");
            string? scelta=Console.ReadLine();

            switch(scelta){
                case "1":               
                    Console.WriteLine("\nInserisci il primo valore");
                    decimal a=decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo valore");
                    decimal b=decimal.Parse(Console.ReadLine());
                    
                    if(a>b){
                        Console.WriteLine($"{a} è maggiore di {b}");
                    }
                    else if(a<b){
                        Console.WriteLine($"{a} è minore di {b}");
                    }
                    else {
                        Console.WriteLine($"{a} è pari a {b}");
                    }

                    break;
                    
                case "2":

                    Console.WriteLine("Hai selezionato crea una lista di nomi");
                    List<string> nomi = new List<string>();
                    String nome="A";
                    int v=0;
                    while(nome!="x")
                    {
                        Console.Write($"Digita un nome (x per terminare):");
                        if(nome!="x")
                        {
                            nome=Console.ReadLine();
                            if(nome!="x"){
                                nomi.Add(nome);
                                v++;
                            }
                        }
                    }

                    Console.WriteLine($"\nI nomi sono: ");
                    for(int i=0;i<v;i++){
                    Console.WriteLine($" {nomi[i]} ");
                    }
                    break;
                
                case "3":
                    Console.WriteLine("Hai selezionato l'opzione tre");
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
                    break;
                
                case "4":
                    Console.WriteLine("Inserisci la frequenza");
                    int freq = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci la durata in ms");
                    int ms = Int32.Parse(Console.ReadLine());
                    Console.Beep(freq, ms);
                    break;
                
                case "5":
                    bool s=true;
                    while(s)
                    {
                        Console.WriteLine("\nSeleziona opzione: ");
                        Console.WriteLine("1 - nascondi cursore");
                        Console.WriteLine("2 - mostra cursore");
                        Console.WriteLine("3 - esci");
                        string? input = Console.ReadLine();
                            Console.Clear();
                            switch (input.ToLower())
                            {
                                
                                case "1":
                                    Console.CursorVisible=false;
                                    break;
                                case "2":
                                    Console.CursorVisible=true;
                                    break;
                                case "3":
                                    Console.WriteLine("\nComando riconosciuto. Uscita in corso...");
                                    s=false;
                                    break;
                                default:
                                    Console.WriteLine("\nOpzione non riconosciuta;");
                                    break;
                            }
                    }
                    break;
                    
                case "6":
                    Console.WriteLine("Confronta due stringhe\n");                       //rendere decimali
                    Console.WriteLine("Inserisci la prima stringa:");
                    string nome1=Console.ReadLine();
                    Console.WriteLine("Inserisci la seconda stringa");
                    string nome2=Console.ReadLine();
                    bool uguali = nome1==nome2;
                    if(uguali){Console.WriteLine($"Le due stringhe sono uguali");}
                    else{Console.WriteLine($"Le due stringhe sono diverse");}
                    break;
                
                case "7":
                    int timeoutInSeconds=5;
                    Console.WriteLine($"Inserisci un input entro {timeoutInSeconds} secondi: ");

                    bool inputReceived = false;
                    string? inputx="";

                    DateTime endTime= DateTime.Now.AddSeconds(timeoutInSeconds);  

                    while(DateTime.Now < endTime) 
                    {

                        if(Console.KeyAvailable) 
                        {
                            inputx=Console.ReadLine();
                            inputReceived=true;   
                            break;
                        }

                        Thread.Sleep(100);                                                          //piccola pausa per ridurre il peso sulla CPU
                    }
                if(inputReceived)
                {
                    Console.WriteLine($"Hai inserito: {inputx}");
                }
                else{

                    Console.WriteLine("Tempo scaduto!");
                }
                break;

                case "8":

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
                    break;

                case "9":

                    Random random=new Random();
                    int somma=0;
                    int basso, alto;
                    Console.WriteLine("Seleziona l'intervallo.");
                    Console.Write("Genera numero tra: ");
                    basso=Int32.Parse(Console.ReadLine());
                    Console.Write("e: ");
                    alto=Int32.Parse(Console.ReadLine());


                     for(int i=0;i<10;i++){

                        int numero=random.Next(basso,alto);
                        Console.WriteLine($"Il numero generato è {numero}");
                        somma+=numero;
                        Thread.Sleep(500);
                    }
                    Console.WriteLine($"La somma è {somma}");
                    break;

                case "e":
                    Console.WriteLine("Uscita in corso...");
                    continua=false;
                    break;

                default:
                    Console.WriteLine("Selezione non valida.");
                    break;
            }
            if(continua)
            {
                Thread.Sleep(500);
                Console.WriteLine("\nPremi invio per continuare...");
                Console.ReadKey();      //aspetta che l'utente prema un tasto prima di mostrare di nuovo il menù
            }
        }
        while(continua);
    }
}
