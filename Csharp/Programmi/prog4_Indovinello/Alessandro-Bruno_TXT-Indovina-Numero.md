# ASSIGNMENT

## INDOVINA NUMERO SEGRETO

**REGOLE** = Hai 6 tentativi per indovinare il numero segreto contenuto tra 1 e 200 (compresi). Al 4° e 5° tentativo riceverai dei suggerimenti.

### DEFINIZIONE DI FUNZIONALITA' E OBIETTIVI

- [x] il programma deve creare, appena lanciato, un file di testo contenente il nome e i punti del giocatore nella partita attuale
- [x] il programma dovrà dare dei suggerimenti ad ogni tentativo che l'utente effettua
  - [x] ai primi 3 tentativi verrà suggerito se il numero segreto è maggiore o minore del numero inserito dal giocatore
  - [x] al quarto tentativo il suggerimento sarà il valore della somma delle cifre che compongono il numero segreto
  - [x] al quinto tentativo fallito verrà comunicata la decina giusta in cui si trova il numero segreto
- [x] il programma si stoppa
  - se il giocatore indovina il numero
  - se il giocatore esaurisce i tentativi
- [x] il file Punteggio.txt dovrà aggiornarsi dopo ogni partita conclusa
- [x] il programma offre la possibilità di continuare la partita indovinando nuovi numeri fino a che si vuole

- **possibili utilità future**
  - il gioco va a fortuna per i primi tentativi, ma con l'ultimo suggerimento c'è la possibilità di risalire al numero attraverso la matematica, e si avrà un unico tentativo. Il gioco può quindi stimolare i bambini ad imparare ed applicare questa materia.

### INTERFACCIA UTENTE

- [x] necessità di un'interfaccia utente chiara e minimale (il gioco è indirizzato a tutti ma può essere particolarmente indicato per stimolare l'apprendimento della matematica nei bambini)
- [x] richiesta all'utente di inserire il proprio nome
- [x] stampa del nome del giocatore e del punteggio attuale in colore giallo
- [x] richiesta di inserire tentativi fino a che non si indovina o si esauriscono i tentativi
- [x] richiesta di inserire un valore accettabile quando ne viene inserito uno sbagliato
  - [x] es. lettera anziche numero / stringa vuota
  - [x] es. numero troppo grande per i limiti di un intero / numero negativo
- [x] stampa che ti dice se hai indovinato, altrimenti stampa di un suggerimento; + stampa numero di tentativi rimanenti
- [x] richiesta di cominciare una nuova partita
- [x] messaggio di chiusura colorato con riepilogo punteggio

### DEFINIZIONE DI STRUTTURE E CONVENZIONI

- [x] stringa path che crea legge e modifica il file Punteggio.txt
- [x] ciclo while per ricominciare la partita una volta conclusa
- [x] metodo random per generare un numeri segreto
- [x] definizione array che legge e stampa i dati nel file Punteggio.txt
- [x] ciclo for che continua fino a che il giocatore ha tentativi oppure vince
- [x] implementare degli if per generare i suggerimenti in base al numero di tentativi effettuati
- [x] aggiungere un controllo try/catch sui campi da inserire in input

- ## CODICE

```csharp


class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        //  SELEZIONA QUI INTERVALLO E TENTATIVI
        int punteggio = 0, tentativi = 6, intervallo = 200;
        bool continua = true;


        //  CREAZIONE E INIZIALIZZAZIONE FILE .TXT

        string path = @"Punteggio.txt";
        File.Create(path).Close();

        Console.WriteLine("Nome giocatore:");
        string giocatore = Console.ReadLine()!;
        string punti = punteggio.ToString();

        File.AppendAllText(path, giocatore + "\n" + punti + "\n");


        //  CICLO WHILE DA CUI VERRA' RICOMINCIATA LA PARTITA IN CASO SI VOGLIA CONTINUARE A GIOCARE

        while (continua)
        {



            //  CREAZIONE NUMERO SEGRETO
            Random random = new Random();
            int numero = random.Next(1, intervallo + 1);
            int num;


            //  CREAZIONE ARRAY CHE LEGGE E STAMPA CONTENUTO FILE .TXT (NOME GIOCATORE E PUNTEGGIO ATTUALE)

            string[] lines = File.ReadAllLines(path);
            Console.Clear();


            Console.WriteLine($"Giocatore: {lines[0]}");
            Console.Write($"Punteggio: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{lines[1]}");
            Console.ResetColor();


            //  RICHIESTA NUMERO SEGRETO FINO ALLA VITTORIA O AD ESAURIMENTO TENTATIVI
            //  + CONTROLLO CORRETTEZZA DEI VALORI INSERITI

            Console.Write($"\nChe numero pensi sia uscito tra 1 e {intervallo}? Hai {tentativi} tentativi:");
            for (int i = 0; i < tentativi; i++)
            {



            richiesta_input:
                Console.Write($"\nTentativo {i + 1}: ");
                string input = Console.ReadLine()!;
                try
                {

                    num = Int32.Parse(input);


                    while (num < 1 || num > intervallo)
                    {
                        Console.WriteLine($"Attenzione! Digita un numero tra 1 e {intervallo}: ");
                        num = Int32.Parse(Console.ReadLine()!);
                    }

                }

                catch (Exception e)
                {
                    if (input == "")
                    {
                        Console.WriteLine("Non hai inserito nulla, digita un numero!");
                    }
                    else if (e.HResult == -2146233033)
                    {
                        Console.WriteLine("Hai inserito un carattere, devi digitare un numero!");
                    }
                    else if (e.HResult == -2146233066)
                    {
                        Console.WriteLine("Sei uscito dal range degli interi, digita un numero minore");
                    }
                    else
                    {
                        Console.WriteLine($"ERRORE: {e.Message}");
                    }
                    goto richiesta_input;
                }



                //  STAMPE OUTPUT E SUGGERIMENTI IN BASE AL TENTATIVO EFFETTUATO

                if (num == numero)
                {
                    Console.WriteLine($"Bravo! Era il numero {numero}! Hai indovinato in {i + 1} tentativi, te ne rimanevano {tentativi - 1 - i}");
                    punteggio += tentativi - i;
                    Console.WriteLine($"Hai ottenuto {tentativi - i} punti, arrivi cosi a {punteggio}.");
                    break;
                }
                else if (i < tentativi - 1)
                {
                    Console.WriteLine($"Sbagliato, riprova...");
                    if (num < numero) { Console.WriteLine($"(il numero da indovinare è maggiore)"); }
                    else { Console.WriteLine($"(il numero da indovinare è minore)"); }



                    if (i == (tentativi - 2) && numero > 9)
                    {

                        if (num / 10 != numero / 10)
                        {
                            if (numero >= 10) { Console.WriteLine($"Ti resta 1 tentativo. Il numero comincia con '{numero / 10}..' ."); }
                            else { Console.WriteLine("Ti resta 1 tentativo. Il numero è minore di 10"); }
                        }
                        else { Console.WriteLine($"Ti resta 1 tentativo, ma sei nella decina corretta"); }
                    }


                    if (i == 3)
                    {

                        int f = numero, somma = 0;
                        while (f >= 1)
                        {

                            somma += f % 10;
                            f /= 10;
                        }
                        Console.WriteLine($"Ti restano {tentativi - 1 - i} tentativi. La somma delle cifre è {somma}");
                    }


                }
                else { Console.WriteLine($"Sbagliato.\nTentativi esauriti. Era uscito il numero {numero}. Non hai totalizzato punti.\n"); }
            }

            //  AGGIORNAMENTO FILE .TXT A FINE PARTITA CON IL PUNTEGGIO OTTENUTO

            punti = punteggio.ToString();

            File.Delete(path);
            File.Create(path).Close();

            File.AppendAllText(path, giocatore + "\n" + punti + "\n");


            //  RICHIESTA DI CONTINUARE A GIOCARE (VERRA' GENERATO UN NUOVO NUMERO SEGRETO)

            Console.Write("Vuoi continuare a giocare? (s/n): ");
            string risp = Console.ReadLine()!;
            risp = risp.ToLower();

            while (risp != "no" && risp != "n" && risp != "si" && risp != "s")
            {
                Console.Write("\nRisposta non valida.\nVuoi continuare a giocare? (s/n): ");
                risp = Console.ReadLine()!;
                risp = risp.ToLower();
            }

            if (risp == "no" || risp == "n")
            {
                continua = false;
            }


        }


        //  STAMPA E MESSAGGIO FINALE DI CHIUSURA GIOCO

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\n\nHai totalizzato {punteggio} punti. Chiusura del gioco in corso...\n\n\n\n");
        Console.ResetColor();

        Thread.Sleep(3200);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\n\n\n\nAlla prossima!\n\n\n\n\n\n");
        Console.ResetColor();

    }
}

```

```txt
// il file txt viene creato dal programma
// la prima riga contiene il nome del giocatore
// la seconda riga contiene il punteggio attuale del giocatore
```

```txt
// file Punteggio.txt
Alex
0
```