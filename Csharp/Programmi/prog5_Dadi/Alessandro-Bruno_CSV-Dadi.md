# ASSIGNMENT

- ## README


### RISIKO
*PROGRAMMA CHE, CONOSCENDO IL NUMERO ARMATE DI 2 TERRITORI, CALCOLA L'ESITO DELL'ATTACCO*
- _( potrebbe diventare una funzione all'interno di un gioco completo di Risiko )_

### Regole

**1**. Quanti dadi utilizzare viene stabilito dal numero di armate che si intendono schierare meno uno, fino ad un massimo di tre per volta

**2**. L' avversario difende con 3 dadi, se ha meno di 3 armate difende con lo stesso numero di dadi delle armate

**3**. Ognuno dei giocatori lancia il numero di dadi corrispondente e poi si confrontano i valori, contrapponendo il più alto con il più alto e andando a scendere: per ogni confronto perso, lo sconfitto perde un'armata;

**4**. In caso di parità il punto va a chi si difende.

- es.  
giocatore 1 (6, 4, 3)  
giocatore 2 (5, 3, 3)

     risultato = il giocatore attaccante perde 1 armata e ne abbatte 2 al difensore, perche:
    - tra 6 e 5 vince 6, l'attaccante
    - tra 4 e 3 vince 4, l'attaccante
    - tra 3 e 3 vince chi difende;

**5**. dopo un attacco, il giocatore attaccante può continure ad attaccare, finche ha armate per farlo  
**6**. 1 armata deve sempre rimanere sul territorio attaccante, quindi se hai 4 armate puoi attaccare al max con 3, altrimenti in caso di sconfitta rimarresti senza  
**7**. quando abbatti tutte le armate nemiche, conquisti il territorio


### Definizione dei funzionalità, obiettivi e requisiti del gioco:

-  [x]  creazione e lettura file di tipo .csv Punteggio
-  [x]  simulare il tiro dei dadi
-  [x]  tenere conto delle armate in attacco e di quelle in difesa
-  [x]  conservare i totali delle armate presenti nei due territori       
-  [x]  aggiornare ad ogni tiro i numeri delle armate rimanenti
-  [x]  colorare il numero delle armate rimanenti: verdi chi è in vantaggio, rosso chi perde, giallo in caso di pareggio
-  [x]  aggiornamento del file Punteggio.csv contenente i numeri attuali delle armate
-  [x]  possibilità di continuare gli attacchi dopo il primo, finchè possibile



- **possibili utilità future**
  -  questo programma può servire da test per il calcolo della probabilità di vittoria nei vari casi, come un app a se;  
  -  oppure può diventare una funzione all'interno di un gioco di risiko


### Interfaccia utente

-  [x]  l'interfaccia deve essere comprensibile e chiara, anche abbastanza basica (console clear per pulire lo schermo)
-  [x]  richiesta all'utente di inserire i numeri di armate presenti nei due territori (verranno inseriti in Punteggio.txt)
-  [x]  visualizzazione dei dati presi dal file di testo Punteggio.csv
-  [x]  richiesta di quanti dadi vuole usare l'attaccante
-  [x]  stampa l'esito dell'attacco
-  [x]  stampa quanti carri rimangono nei due territori colorando il numero in base al file csv Punteggio.csv
-  [x]  richiesta se dopo un attacco si vuole continuare o fermarsi
-  [x]  blocco dell'attacco e stampa dell'esito quando vinci o quando non hai abbastanza armate per continuare l'attacco
-  [x]  richiesta di cominciare un nuovo attacco
    

### Definizione di Strutture e Convenzioni:
-  [x]  ciclo while per ricominciare la partita una volta conclusa
-  [x]  file Punteggio.csv contenente i numeri di armate inizializzati in input
-  [x]  inizializzazione dati armate nei due territori prendendoli da un file Punteggio.csv
-  [x]  secondo while che cicla ogni volta che si prosegue un attacco
-  [x]  bisogno di tenere i dati su quantità dei dadi da tirare(carri_attacco, carri_difesa)
-  [x]  due variabili booleane  
    - [x] una per decidere se proseguire o terminare uno stesso attacco  
    - [x] una per decidere se dichiarare un nuovo attacco ad un altro territorio o chiudere il programma  
-  [x]  generazione dei tiri di dado casuale (random)
-  [x]  dichiarazione di due array per memorizzare i due lanci 
-  [x]  chiamata funzione *Sort* per ordinare i due lanci per poterli confrontare
-  [x]  ciclo di if per il confronto dei due tiri (array)
-  [x]  gestione eccezioni e validità valori inseriti  
    -  [x]  nell'inserimento delle armate iniziali
    -  [x]  alla richiesta "con quanti dadi tiri?"
    -  [x]  alle richieste "continui?"
-  [x]  aggiungere metodi dove possibile o dove è conveniente, al fine di migliorare chiarezza e praticità del codice  






- ## CODICE

```csharp

class Program
{
    static void Main(string[] args)
    {
        bool giocaAncora = true;
        int dadiAttacco, dadiDifesa;
        int vittorie = 0, sconfitte = 0;

        while (giocaAncora)
        {

            Console.Clear();


            bool continua = true;
            Random random = new Random();


            //  CREAZIONE FILE CSV

            string path = @"Punteggio.csv";
            File.Create(path).Close();


            //  INSERIMENTO ARMATE INIZIALI NEL TERRITORIO DEL GIOCATORE ATTACCANTE + CONTROLLO VALORE INSERITO AL FINE DI NON GENERARE ERRORI

            Console.Write("\nQuante armate ci sono nel territorio da cui attacchi?: ");
            string player = "attaccante";
            string tuoi = InserisciEControllaArmate(player);



            //  INSERIMENTO ARMATE INIZIALI NEL TERRITORIO AVVERSARIO + CONTROLLO VALORE INSERITO AL FINE DI NON GENERARE ERRORI

            Console.Write("Con quante armate difende l'avversario?: ");
            player = "difensore";
            string suoi = InserisciEControllaArmate(player);



            //  SCRITTURA DEI DATI INSERITI ALL'INTERNO DEL FILE PUNTEGGIO.CSV


            File.AppendAllText(path, tuoi + "," + suoi + "\n");
            File.AppendAllText(path, "x" + "," + "x" + "\n");



            string[] lines = File.ReadAllLines(path);
            string[][] line = new string[lines.Length][];

            for (int i = 0; i < 2; i++)
            {
                line[i] = lines[i].Split(",");
            }

            int totCarriAttacco = Int32.Parse(line[0][0]);
            int totCarriDifesa = Int32.Parse(line[0][1]);

            Console.Write($"\nAttacchi con {totCarriAttacco} carriarmati, l'avversario difende con {totCarriDifesa} carriarmati.\n");



            //  INSERIMENTO NUMERO DEI DADI CON CUI TIRI (CON QUANTE ARMATE ATTACCHI) + CONTROLLO CORRETTEZZA DEL VALORE INSERITO

            while (continua)
            {

                Console.Write("Con quanti dadi tiri? (max 3): ");

            richiesta_input3:
                try
                {
                    dadiAttacco = Int32.Parse(Console.ReadLine()!);


                    while (dadiAttacco > 3 || dadiAttacco > totCarriAttacco - 1 || dadiAttacco < 1)
                    {

                        if (dadiAttacco > 3)
                        {
                            Console.Write($"\nPuoi tirare con un massimo di 3 dadi! Con quanti dadi tiri?: ");
                        }
                        else if (dadiAttacco > totCarriAttacco - 1)
                        {
                            Console.Write($"\nNon hai abbastanza carriarmati: uno deve sempre rimanere nel tuo territorio! (ne hai {totCarriAttacco}) Con quanti dadi tiri?: ");
                        }
                        if (dadiAttacco < 1)
                        {
                            Console.Write($"\nDevi attaccare con almeno un'armata (cioè un dado).\nCon quanti dadi tiri?: ");
                        }

                        dadiAttacco = Int32.Parse(Console.ReadLine()!);
                    }


                }
                catch (Exception e)
                {

                    if (e.HResult == -2146233033)
                    {
                        Console.Write("\nHai inserito un carattere, devi digitare un numero: ");
                    }
                    else if (e.HResult == -2146233066)
                    {
                        Console.Write("\nSei uscito dal range degli interi, digita un numero minore: ");
                    }
                    else
                    {
                        Console.Write($"\nERRORE: {e.Message}.\nRiprova:");
                    }
                    goto richiesta_input3;
                }


                //  CON QUANTI DADI/ARMATE DIFENDE L'AVVERSARIO

                if (totCarriDifesa > 3) { dadiDifesa = 3; }
                else { dadiDifesa = totCarriDifesa; }



                //  CREAZIONE ARRAY CHE CONTERRANNO I VALORI DEI TIRI DI DADI


                int[] attacco = new int[dadiAttacco];
                int[] difesa = new int[dadiDifesa];


                // GENERAMENTO TIRI RANDOM

                for (int i = 0; i < dadiAttacco; i++)
                {
                    int numero = random.Next(1, 7);
                    attacco[i] = numero;
                }
                for (int i = 0; i < dadiDifesa; i++)
                {
                    int numero = random.Next(1, 7);
                    difesa[i] = numero;
                }


                // ORDINAMENTO DEI DADI IN MODO DA CONFRONTARE I TIRI

                Array.Sort(attacco);
                Array.Sort(difesa);
                Array.Reverse(attacco);
                Array.Reverse(difesa);
                Console.Clear();

                //  STAMPA DEI TIRI USCITI

                StampaTiri(dadiAttacco, dadiDifesa, attacco, difesa);


                //  CONFRONTO DEI TIRI 

                ConfrontoTiri(ref vittorie, ref sconfitte, dadiAttacco, dadiDifesa, ref totCarriAttacco, ref totCarriDifesa, attacco, difesa);



                //  RICREO FILE CSV CON VALORI ARMATE AGGIORNATI DOPO L'ULTIMO ATTACCO

                File.Delete(path);
                File.Create(path).Close();

                line[1][0] = totCarriAttacco.ToString();
                line[1][1] = totCarriDifesa.ToString();

                File.AppendAllText(path, line[0][0] + "," + line[0][1] + "\n" + line[1][0] + "," + line[1][1] + "\n");



                //  STAMPA OUTPUT FINALE
                OutputFinale(vittorie, sconfitte, totCarriAttacco, totCarriDifesa);


                //  se hai VINTO o PERSO IL GIOCO SI INTERROMPE
                if (VintoOPerso(totCarriDifesa, totCarriAttacco))
                {
                    break;
                }



                // RICHIESTA DI CONTINUARE AD ATTACCARE NELLO STESSO TERRITORIO

                Console.Write("\n\n\ncontinui? (s/n): ");
                string risposta = Console.ReadLine()!;
                risposta = risposta.ToLower();

                while (risposta != "s" && risposta != "n")
                {
                    Console.Write("\nRisposta non valida. Continui? (s/n): ");
                    risposta = Console.ReadLine()!;
                    risposta = risposta.ToLower();
                }

                if (risposta == "n")
                {
                    continua = false;
                }

            }


            // RICHIESTA DI DICHIARARE UN NUOVO ATTACCO

            Console.Write("\n\nDichiari un nuovo attacco? (s/n): ");
            string risposta2 = Console.ReadLine()!;
            risposta2 = risposta2.ToLower();

            while (risposta2 != "s" && risposta2 != "n")
            {
                Console.Write("\nRisposta non valida. Dichiari un nuovo attacco? (s/n): ");
                risposta2 = Console.ReadLine()!;
                risposta2 = risposta2.ToLower();
            }


            // SE NON VUOI IL PROGRAMMA SI FERMA E TI SALUTA

            if (risposta2 == "n")
            {
                giocaAncora = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n\n\n\nAlla prossima!\n\n\n\n\n\n");
                Console.ResetColor();
            }
        }


    }


    //  funzione che stampa l'esito del singolo attacco
    static void OutputFinale(int vittorie, int sconfitte, int totCarriAttacco, int totCarriDifesa)
    {

        Console.Write($"\nAbbattuti: {vittorie}   -   Persi: {sconfitte}\n");
        Console.Write("\nGiocatore: ");

        if (totCarriAttacco > totCarriDifesa)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (totCarriDifesa > totCarriAttacco)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write($"{totCarriAttacco}");
        Console.ResetColor();
        Console.Write("  -  Avversario: ");

        if (totCarriAttacco < totCarriDifesa)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (totCarriDifesa < totCarriAttacco)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write($"{totCarriDifesa}");
        Console.ResetColor();

    }

    //  funzione che confronta i due array contenenti i tiri dei dadi
    static void ConfrontoTiri(ref int vittorie, ref int sconfitte, int dadiAttacco, int dadiDifesa, ref int totCarriAttacco, ref int totCarriDifesa, int[] attacco, int[] difesa)

    {
        int confronto;
        vittorie = 0;
        sconfitte = 0;
        if (dadiAttacco > dadiDifesa) { confronto = dadiDifesa; }
        else { confronto = dadiAttacco; }


        for (int i = 0; i < confronto; i++)
        {
            if (attacco[i] > difesa[i])
            {
                vittorie++;
                totCarriDifesa--;
            }
            else
            {
                sconfitte++;
                totCarriAttacco--;
            }
        }
    }

    //  funzione che blocca l'attacco quando il giocatore ha vinto o non ha armate per continuare
    static bool VintoOPerso(int totCarriDifesa, int totCarriAttacco)
    {
        if (totCarriDifesa == 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\n\nHai conquistato il territorio!!\n\n");
            Console.ResetColor();
            return true;
        }

        if (totCarriAttacco <= 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n\n\nNon hai abbastanza carriarmati per continuare.\n\n");
            Console.ResetColor();
            return true;
        }
        return false;
    }

    //  funzine che stampa i tiri dei dadi in modo che l'utente li legga e comprenda chiaramente
    static void StampaTiri(int dadiAttacco, int dadiDifesa, int[] attacco, int[] difesa)
    {
        Console.Write("\nTiro Giocatore  = (");
        for (int i = 0; i < dadiAttacco; i++)
        {
            Console.Write($" {attacco[i]} ");
        }
        Console.WriteLine(")");

        Console.Write("\nTiro Avversario = (");
        for (int i = 0; i < dadiDifesa; i++)
        {
            Console.Write($" {difesa[i]} ");
        }
        Console.WriteLine(")\n");
    }


    //  funzione che fa inserire all'utente il numero totale di armate in un territorio, controllando la validità del dato inserito
    static string InserisciEControllaArmate(string player)
    {
        int input;

    richiesta_input:
        try
        {

            input = Int32.Parse(Console.ReadLine()!);

            if (player == "attaccante")
            {
                while (input < 2)
                {
                    Console.Write("\nHai bisogno di almeno 2 armate per dichiarare un attacco.\nQuante armate ci sono nel territorio da cui attacchi?: ");
                    input = Int32.Parse(Console.ReadLine()!);
                }
            }

            if (player == "difensore")
            {
                while (input < 1)
                {
                    Console.Write("\nL'avversario deve disporre di almeno un'armata.\nCon quante armate difende?: ");
                    input = Int32.Parse(Console.ReadLine()!);
                }
            }


        }
        catch (Exception e)
        {
            if (e.HResult == -2146233033)
            {
                Console.Write("\nHai inserito un carattere, devi digitare un numero: ");
            }
            else if (e.HResult == -2146233066)
            {
                Console.Write("\nSei uscito dal range degli interi, digita un numero minore: ");
            }
            else
            {
                Console.Write($"\nERRORE: {e.Message}.\nRiprova:");
            }
            goto richiesta_input;
        }
        string tuoi = input.ToString();
        return tuoi;
    }

}


```

```txt
// il file csv viene creato dal programma
// la prima riga contiene le tue armate iniziali, e quelle dell'avversario
// la seconda riga contiene le armate attualmente rimanenti (vengono aggiornate ad ogni tiro)
// in questo esempio la partita è cominciata 12 vs 5 e ho vinto con 5 armate rimanenti
```

```csv
// file punteggio.csv

12,5
5,0
```