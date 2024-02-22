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