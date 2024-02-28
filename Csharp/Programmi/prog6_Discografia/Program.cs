using Newtonsoft.Json;



class Program
{
    static void Main(string[] args)
    {

        string catalogo = $"./Catalogo";
        if (!Directory.Exists(catalogo))
        {
            Directory.CreateDirectory("./Catalogo");
        }

        Console.CursorVisible = false;
        bool continua = true;
        do
        {

            Console.Clear();

            Console.WriteLine("** MENU **\n");
            Console.WriteLine("1. Aggiungi dischi al catalogo\n");
            Console.WriteLine("2. Cerca dischi per artista\n");
            Console.WriteLine("3. Rimuovi dischi dal catalogo\n");
            Console.WriteLine("e. Chiudi applicazione\n");

            string? scelta = Console.ReadLine();

            switch (scelta)
            {

                case "1":
                    {
                        Console.Clear();

                        bool risp2 = true;
                        while (risp2)
                        {


                            Console.WriteLine("Inserisci nome artista:");
                            string artist = Console.ReadLine()!;
                            string nomeCartella = artist.Trim();
                            nomeCartella = nomeCartella.Replace(" ", "-");

                            string file = $"./Catalogo/{nomeCartella}";
                            if (!File.Exists(file))
                            {
                                Directory.CreateDirectory("./Catalogo/" + nomeCartella);
                            }

                            bool risp = true;
                            while (risp)
                            {

                                Console.Clear();
                                Console.Write("Inserisci titolo album: ");
                                string titolo = Console.ReadLine()!;


                                string nomeFile = titolo.Trim();
                                nomeFile = nomeFile.Replace(" ", "-");

                                string path = $"./Catalogo./{nomeCartella}/" + nomeFile + ".json";
                                int quantita;

                                if (File.Exists(path))
                                {

                                    // Leggere il file JSON esistente
                                    var jsonData = File.ReadAllText(path);

                                    // Deserializzare il contenuto JSON in un oggetto dynamic
                                    dynamic data = JsonConvert.DeserializeObject<dynamic>(jsonData)!;

                                    // Modificare il valore desiderato
                                    int qnt = data.quantita;
                                    qnt++;
                                    data.quantita = qnt;

                                    // Serializzare l'oggetto dynamic modificato in una stringa JSON
                                    var updatedJsonData = JsonConvert.SerializeObject(data);

                                    // Sovrascrivere il file JSON con la nuova stringa JSON
                                    File.WriteAllText(path, "\n\t" + updatedJsonData);

                                    Console.WriteLine("Disco già presente in catalogo. Quantità aggiornata.\n");

                                }
                                else
                                {
                                    Console.Write("Inserisci anno di pubblicazione: ");
                                    string anno = Console.ReadLine()!;
                                    quantita = 1;

                                    File.AppendAllText(path, "\n\t" + JsonConvert.SerializeObject(new { titolo, anno, quantita }));
                                }



                                Console.Write("\nVuoi inserire un altro album? (s/n):  ");
                                string risposta = Console.ReadLine()!;

                                while (risposta != "n" && risposta != "s")
                                {
                                    Console.Write("\nInserimento non valido.\nVuoi inserire un altro album? (s/n):  ");
                                    risposta = Console.ReadLine()!;
                                }

                                if (risposta == "n")
                                {

                                    risp = false;
                                }

                            }




                            Console.Write("\nVuoi inserire un altro artista? (s/n):  ");
                            string risposta2 = Console.ReadLine()!;
                            while (risposta2 != "n" && risposta2 != "s")
                            {
                                Console.Write("\nInserimento non valido.\nVuoi inserire un altro artista? (s/n):  ");
                                risposta2 = Console.ReadLine()!;
                            }

                            if (risposta2 == "n")
                            {

                                risp2 = false;
                            }


                        }
                        break;
                    }

                case "2":
                    {
                        Console.Clear();
                        Console.Write("Inserisci artista di cui cercare i dischi: ");
                        string artist = Console.ReadLine()!;
                        string nomeCartella = artist.Trim();
                        nomeCartella = artist.Replace(" ", "-");

                        string file = $"./Catalogo/{nomeCartella}";


                        if (Directory.Exists(file))
                        {
                            Console.Clear();
                            Console.WriteLine($"CATALOGO {artist}\n");


                            string via = ($"./Catalogo./{nomeCartella}");
                            string[] files = Directory.GetFiles(via);


                            foreach (string album in files)
                            {
                                string jsonFile = File.ReadAllText(album);
                                dynamic obj = JsonConvert.DeserializeObject(jsonFile)!;

                                string datiAlbum = $"{obj.titolo} ({obj.anno})";
                                string disponibili = $"disponibilità:{obj.quantita}";

                                StampaTabellaAlbum(datiAlbum, disponibili);


                            }

                        }
                        else
                        {
                            Console.WriteLine("CATALOGO INESISTENTE");
                        }


                        Console.WriteLine("\n\npremi un tasto per proseguire...");
                        Console.ReadKey();
                        break;

                    }

                case "3":
                    {
                        Console.Clear();

                        Console.Write("Artista di cui rimuovere il disco: ");

                        string artist = Console.ReadLine()!;
                        string nomeCartella = artist.Trim();
                        nomeCartella = nomeCartella.Replace(" ", "-");

                        string file = $"./Catalogo/{nomeCartella}";
                        if (Directory.Exists(file))
                        {

                            Console.Write("Inserisci titolo album da rimuovere: ");
                            string titolo = Console.ReadLine()!;

                            string nomeFile = titolo.Trim();
                            nomeFile = nomeFile.Replace(" ", "-");

                            string path = $"./Catalogo./{nomeCartella}/" + nomeFile + ".json";

                            if (File.Exists(path))
                            {

                                // Leggere il file JSON esistente
                                var jsonData = File.ReadAllText(path);

                                // Deserializzare il contenuto JSON in un oggetto dynamic
                                dynamic data = JsonConvert.DeserializeObject<dynamic>(jsonData)!;

                                // Modificare il valore desiderato
                                int qnt = data.quantita;

                                if (qnt == 1)
                                {
                                    File.Delete(path);
                                }
                                else
                                {

                                    qnt--;
                                    data.quantita = qnt;

                                    // Serializzare l'oggetto dynamic modificato in una stringa JSON
                                    var updatedJsonData = JsonConvert.SerializeObject(data);

                                    // Sovrascrivere il file JSON con la nuova stringa JSON
                                    File.WriteAllText(path, "\n\t" + updatedJsonData);

                                    Console.WriteLine("1 copia del disco eliminata. Quantità aggiornata.\n");
                                    Thread.Sleep(2000);

                                }


                            }
                            else
                            {
                                Console.WriteLine("Questo album non è presente in catalogo\n");
                            }




                        }
                        else
                        {
                            Console.WriteLine("Nessun album di questo artista in catalogo\n");
                        }




                        Console.WriteLine("\n\npremi un tasto per proseguire...");
                        Console.ReadKey();
                        break;
                    }

                case "e":
                    {
                        Console.Clear();
                        Console.WriteLine("Uscita in corso...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continua = false;
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Selezione non valida.");
                        break;
                    }
            }
        }
        while (continua);
        Console.CursorVisible = true;
    }


    /// <summary>
    ///  serve a stampare in modo ordinato i nomi degli album e la loro disponibilità
    /// </summary>
    /// <param name="datiAlbum">Titolo e anno di pubblicazione dell'album</param>
    /// <param name="disponibili">Copie disponibili in negozio</param>
    static void StampaTabellaAlbum(string datiAlbum, string disponibili)
    {

        int maxCaratteri = 75;
        string spazi = "";
        for (int i = 0; i < maxCaratteri - datiAlbum.Length; i++)
        {
            spazi += " ";
        }

        Console.WriteLine(datiAlbum + spazi + disponibili);
    }

}
