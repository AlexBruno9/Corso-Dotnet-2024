class Program
{
    static void Main(string[] args)                     
    {   
        Console.Clear();
        int punteggio=0, tentativi=6, intervallo=200; //SELEZIONA INTERVALLO E TENTATIVI
        bool continua=true;
        Console.Write("Come ti chiami? ");
        string giocatore=Console.ReadLine()!;

        string path = @"Punteggio.txt";
        File.Create(path).Close();
        File.AppendAllText(path, giocatore+"\n0");  

        while(continua)
        {
                Console.Clear();
                Random random=new Random();                                       
                int numero=random.Next(1, intervallo+1);
                int num;

               
                string[]lines= File.ReadAllLines(path);    



                Console.WriteLine($"Giocatore: {lines[0]}");  
                Console.Write($"Punteggio: "); 
                Console.ForegroundColor=ConsoleColor.Yellow;                    
                Console.WriteLine($"{lines[1]}"); 
                Console.ResetColor();  


                Console.Write($"\nChe numero pensi sia uscito tra 1 e {intervallo}? Hai {tentativi} tentativi:");
                for(int i=0;i<tentativi;i++){



                    richiesta_input:
                    Console.Write($"\nTentativo {i+1}: ");
                    string input=Console.ReadLine()!;
                    try{

                        num=Int32.Parse(input);
                    }

                    catch(Exception e)
                    {   
                        if(input=="")
                        {
                            Console.WriteLine("Non hai inserito nulla, digita un numero!");
                        }
                        else if(e.HResult==-2146233033)
                        {
                            Console.WriteLine("Hai inserito un carattere, devi digitare un numero!");
                        }
                        else if(e.HResult==-2146233066)
                        {
                            Console.WriteLine("Sei uscito dal range degli interi, digita un numero minore");
                        }
                        else
                        {
                             Console.WriteLine($"ERRORE: {e.Message}");
                        }
                        goto richiesta_input;
                    }



                    while(num<1||num>intervallo)
                    {
                        Console.WriteLine($"Attenzione! Digita un numero tra 1 e {intervallo}: ");
                        num=Int32.Parse(Console.ReadLine()!);
                    }


                    if(num==numero)
                    {
                        Console.WriteLine($"Bravo! Era il numero {numero}! Hai indovinato in {i+1} tentativi, te ne rimanevano {tentativi-1-i}");
                        punteggio+=tentativi-i;
                        Console.WriteLine($"Hai ottenuto {tentativi-i} punti, arrivi cosi a {punteggio}.");
                        break;
                    }
                    else if(i<tentativi-1)
                        {
                            Console.WriteLine($"Sbagliato, riprova...");
                            if(num<numero){Console.WriteLine($"(il numero da indovinare è maggiore)");}
                            else{Console.WriteLine($"(il numero da indovinare è minore)");}



                            if(i==(tentativi-2)&&numero>9){                

                                if(num/10!=numero/10)
                                {
                                    if(numero>=10){Console.WriteLine($"Ti resta 1 tentativo. Il numero comincia con '{numero/10}..' .");}
                                    else{Console.WriteLine("Ti resta 1 tentativo. Il numero è minore di 10");}
                                }     
                                else{Console.WriteLine($"Ti resta 1 tentativo, ma sei nella decina corretta");}
                            }


                            if(i==3){           

                                int f=numero, somma=0;
                                while(f>=1){

                                    somma+=f%10;
                                    f/=10;
                                }
                                Console.WriteLine($"Ti restano {tentativi-1-i} tentativi. La somma delle cifre è {somma}");
                            }


                        }
                        else {Console.WriteLine($"Sbagliato.\nTentativi esauriti. Era uscito il numero {numero}. Non hai totalizzato punti.\n");}
                }  

                File.Create(path).Close();  
                File.AppendAllText(path, giocatore+"\n");
                string punt=Convert.ToString(punteggio);
                File.AppendAllText(path, punt);

                {Console.Write("Vuoi continuare a giocare? (si/no): ");}
                string risp=Console.ReadLine()!;
                if(risp=="no"){continua=false;}

        }
        Console.Write($"\nHai totalizzato {punteggio} punti. Chiusura del gioco in corso...\n\n");
    }
}




















/*
        string path = @"Punteggio.txt";                          
        string[]lines= File.ReadAllLines(path);                                    
        Console.WriteLine($"Giocatore: {lines[0]}");                      
        Console.WriteLine($"Punteggio: {lines[1]}");                                              
        String punteggio="11";
        string path2=@"Punteggio.txt";
        File.Create(path2).Close();
        
        File.AppendAllText(path2, "Alex\n");
        File.AppendAllText(path2, punteggio);
*/

/*              string path2=@"Punteggio.txt";
                File.Create(path2).Close();  
                File.AppendAllText(path2, giocatore+"\n");
                string punt=Convert.ToString(punteggio);
                File.AppendAllText(path2, punt);
*/