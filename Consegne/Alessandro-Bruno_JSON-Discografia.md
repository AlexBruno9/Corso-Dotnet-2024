# ASSIGNMENT

- ## README



## Definizione di funzionalità e obiettivi

-  [x]  il programma deve prendere in inserimento dei dischi e li va a catalogare
-  [x]  al lancio del programma verrà creata una cartella Catalogo
-  [x]  per ogni artista di cui viene inserito un disco, verrà creata una cartella all'interno della cartella Catalogo:  
    -  ogni cartella di un artista conterrà un file json per ogni suo album registrato nel catalogo  
    -  ogni file json conterrà il nome dell'album, l'anno di pubblicazione e le copie disponibili in negozio
-  [x]  se viene inserito un album di un artista di cui non è ancora presente una cartella all'interno del Catalogo, verrà creata;  
-  [x]  se viene inserito un album già presente in catalogo, verrà aggiornata la quantità di copie disponibili  
-  [x]  possibilità di rimuovere album dal catalogo (in caso vengano venduti)
-  [x]  possibilità di stampare elenco album di un determinato artista presenti in catalogo  
    


## Interfaccia utente

-  [x]  l'utente opererà sul catalogo dischi attraverso un menu che permette di aggiungere, eliminare o cercare dischi
-  [x]  richiesta all'utente di inserire il nome dell'artista di cui si vuole inserire un disco in catalogo
-  [x]  richiesta di inserire il titolo dell'album e l'anno di pubblicazione
-  [x]  possibilità di continuare ad inserire album dello stesso artista 
-  [x]  richiesta di passare al catalogo di un altro artista di cui inserire album, o chiudere il programma

-  [x] in caso di ricerca verra mostrato l'elenco degli album con anno di pubblicazione, e a destra la disponibilità

-  [x]  verranno creati più documenti:  
    -  una cartella Catalogo  
    -  una cartella per ogni artista, dentro Catalogo
    -  un file json per ogni album, dentro cartella artista


## Definizione di Strutture e Convenzioni:

- [x] definizione di un menu con 4 scelte (aggiungi, cerca, elimina, chiudi) 

- [x] implementare 2 cicli while: uno per continuare l'inserimento di album, uno per l'inserimento di nuovi artisti
- [x] controllo esistenza di una cartella o di un file:    
    - controllo sulle cartelle artisti per sapere se crearla o aggiornarla quando si inserisce un artista
    - controllo sui file json per sapere se crearlo o aggiornarlo quando si inserisce un album
- [x] implementare una funzione per la stampa ordinata nella ricerca dischi per artista
- [x] controllo legalità sui campi da inserire in input





- ## CODICE

```csharp

//using System.ComponentModel;
//using System.Reflection;
using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;


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


```

```txt
// i file json vengono creati dal programma

CARTELLA CATALOGO CONTERRA' ALTRE CARTELLE CON I NOMI DEGLI ARTISTI DI CUI SONO STATI MEMORIZZATI ALBUM
esempio ./Catalogo./Led Zeppelin

LA CARTELLA DELL'ARTISTA CONTERRA' UN FILE JSON PER OGNI ALBUM MEMORIZZATO
esempio ./Catalogo./Led Zeppelin./Led Zeppelin I.json
                                  Led Zeppelin II.json
                                  Led Zeppelin III.json
```

```json
//cartella Catalogo
//cartella Led-Zeppelin
//contenuto del file Led-Zeppelin-I.json   

{"titolo":"Led Zeppelin I","anno":"1969","quantita":3}


```