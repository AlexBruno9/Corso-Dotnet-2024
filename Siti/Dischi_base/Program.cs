using System.ComponentModel.Design;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using Spectre.Console;


class Program
{

    static void Main(string[] args)
    {



        string path = @"database.db"; // il file deve essere nella stessa cartella del programma
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path); // crea il file del database se non esiste
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;"); // crea la connessione al database se non esiste utilizzando il file appena creato versiion identificata dal numero 3
            connection.Open(); // apre la connessione al database se non è già aperta
            string sql = @"
                        CREATE TABLE artisti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                        CREATE TABLE generi (id INTEGER PRIMARY KEY AUTOINCREMENT, genere TEXT UNIQUE);
                        CREATE TABLE album (id INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT UNIQUE, anno INTEGER, quantita INTEGER CHECK (quantita >= 0), prezzo REAL, id_artista INTEGER, id_genere INTEGER, FOREIGN KEY (id_artista) REFERENCES artisti(id), FOREIGN KEY (id_genere) REFERENCES generi(id));


                        INSERT INTO artisti (nome) VALUES ('Neffa');
                        INSERT INTO artisti (nome) VALUES ('Pink Floyd');
                        INSERT INTO artisti (nome) VALUES ('Bob Dylan');

                        INSERT INTO generi (genere) VALUES ('Rap');
                        INSERT INTO generi (genere) VALUES ('Rock');

                        INSERT INTO album (titolo, anno, quantita, prezzo, id_artista, id_genere) VALUES ('Neffa & i Messaggeri della Dopa', 1995, 2, 35, 1, 1); 
                        INSERT INTO album (titolo, anno, quantita, prezzo, id_artista, id_genere) VALUES ('Highway 61', 1965, 12, 15, 3, 2);                         
                        INSERT INTO album (titolo, anno, quantita, prezzo, id_artista, id_genere) VALUES ('The Dark Side of the Moon', 1973, 9, 20, 2, 2);
                        INSERT INTO album (titolo, anno, quantita, prezzo, id_artista, id_genere) VALUES ('107 elementi', 1997, 1, 40, 1, 1); 

                        
                        ";

            SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database se non esiste
            command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database se non esiste
            connection.Close(); // chiude la connessione al database se non è già chiusa
        }
        while (true)
        {
            Console.WriteLine("1 - visualizzare gli album ordinati per anno");
            Console.WriteLine("2 - visualizzare gli album ordinati per prezzo");
            Console.WriteLine("3 - visualizzare gli album ordinati per quantità");
            Console.WriteLine("4 - modificare il prezzo di un album");
            Console.WriteLine("5 - eliminare un album");
            Console.WriteLine("6 - visualizzare l'album più costoso");
            Console.WriteLine("7 - visualizzare l'album meno costoso");
            Console.WriteLine("8 - inserire un album");
            Console.WriteLine("9 - visualizzare un album");
            Console.WriteLine("10 - visualizzare gli album di un genere");
            Console.WriteLine("11 - inserire un genere");
            Console.WriteLine("12 - eliminare un artista");
            Console.WriteLine("13 - inserire un artista");
            Console.WriteLine("14 - uscire");
            Console.WriteLine("scegli un'opzione");
            string scelta = Console.ReadLine()!;
            if (scelta == "1")
            {
                VisualizzaProdotti();
                if (!continuare()) { break; }

            }
            else if (scelta == "2")
            {
                VisualizzaProdottiOrdinatiPerPrezzo();
                if (!continuare()) { break; }
            }
            else if (scelta == "3")
            {
                VisualizzaProdottiOrdinatiPerQuantita();
                if (!continuare()) { break; }
            }
            else if (scelta == "4")
            {
                ModificaPrezzoProdotto();
            }
            else if (scelta == "5")
            {
                EliminaProdotto();
            }
            else if (scelta == "6")
            {
                VisualizzaProdottoPiuCostoso();
                if (!continuare()) { break; }
            }
            else if (scelta == "7")
            {
                VisualizzaProdottoMenoCostoso();
                if (!continuare()) { break; }
            }
            else if (scelta == "8")
            {
                InserisciProdotto();
            }
            else if (scelta == "9")
            {
                VisualizzaProdotto();
                if (!continuare()) { break; }
            }
            else if (scelta == "10")
            {
                VisualizzaProdottiCategoria();
                if (!continuare()) { break; }
            }
            else if (scelta == "11")
            {
                InserisciCategoria();
            }
            else if (scelta == "12")
            {
                EliminaCategoria();
            }
            else if (scelta == "13")
            {
                InserisciArtista();
            }
            else if (scelta == "14")
            {
                break;
            }
            /* oppure invece di usare if else if si può usare uno switch
            switch (scelta)
            {
                case "1":
                    VisualizzaProdotti();
                    break;
                case "2":
                    VisualizzaProdottiOrdinatiPerPrezzo();
                    break;
                case "3":
                    VisualizzaProdottiOrdinatiPerQuantita();
                    break;
                case "4":
                    ModificaPrezzoProdotto();
                    break;
                case "5":
                    EliminaProdotto();
                    break;
                case "6":
                    VisualizzaProdottoPiuCostoso();
                    break;
                case "7":
                    VisualizzaProdottoMenoCostoso();
                    break;
                case "8":
                    InserisciProdotto();
                    break;
                case "9":
                    VisualizzaProdotto();
                    break;
                case "10":
                    VisualizzaProdottiCategoria();
                    break;
                case "11":
                    InserisciCategoria();
                    break;
                case "12":
                    EliminaCategoria();
                    break;
                case "13":
                    break;
            }

            */


        }
    }


    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;"); // crea la connessione di nuovo perché è stata chiusa alla fine del while in modo da poter visualizzare i dati aggiornati
        connection.Open();


        string sql = "SELECT * FROM album JOIN artisti ON album.id_artista = artisti.id JOIN generi ON album.id_genere = generi.id ORDER BY anno;"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti

        //SQLiteCommand command = new SQLiteCommand(sql, connection); // crea il comando sql da eseguire sulla connessione al database
        //SQLiteDataReader reader = command.ExecuteReader(); // esegue il comando sql sulla connessione al database e salva i dati in reader che è un oggetto di tipo SQLiteDataReader incaricato di leggere i dati

        stampaTabella(sql, connection);


        connection.Close(); // chiude la connessione al database se non è già chiusa
    }

    static void VisualizzaProdottiOrdinatiPerPrezzo()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM album JOIN artisti ON album.id_artista = artisti.id JOIN generi ON album.id_genere = generi.id ORDER BY prezzo;"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti

        stampaTabella(sql, connection);

        connection.Close();
    }

    static void VisualizzaProdottiOrdinatiPerQuantita()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM album JOIN artisti ON album.id_artista = artisti.id JOIN generi ON album.id_genere = generi.id ORDER BY quantita DESC;"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti

        stampaTabella(sql, connection);

        connection.Close();
    }

    static void ModificaPrezzoProdotto()
    {
        Console.WriteLine("inserisci il titolo dell'album"); // chiede il nome del prodotto da modificare
        string titolo = Console.ReadLine()!; // legge il nome del prodotto da modificare
        Console.WriteLine("inserisci il nuovo prezzo"); // chiede il nuovo prezzo del prodotto da modificare
        string prezzo = Console.ReadLine()!; // legge il nuovo prezzo del prodotto da modificare
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"UPDATE album SET prezzo = {prezzo} WHERE titolo = '{titolo}'"; // crea il comando sql che modifica il prezzo del prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery(); // esegue il comando sql sulla connessione al database ExecuteNonQuery() viene utilizzato per eseguire comandi che non restituiscono dati, ad esempio i comandi INSERT, UPDATE, DELETE
        connection.Close();
    }

    static void EliminaProdotto()
    {
        Console.WriteLine("inserisci il titolo dell'album");
        string titolo = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM album WHERE titolo = '{titolo}'"; // crea il comando sql che elimina il prodotto con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaProdottoPiuCostoso()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM album ORDER BY prezzo DESC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo decrescente e ne prende solo il primo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_artista: {reader["id_artista"]}, id_genere: {reader["id_genere"]}");
        }
        connection.Close();
    }

    static void VisualizzaProdottoMenoCostoso()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = "SELECT * FROM album ORDER BY prezzo ASC LIMIT 1"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti ordinati per prezzo in modo crescente e ne prende solo il primo
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_artista: {reader["id_artista"]}, id_genere: {reader["id_genere"]}");
        }
        connection.Close();
    }

    static void InserisciProdotto()
    {
        Console.WriteLine("inserisci il titolo dell'album");
        string titolo = Console.ReadLine()!;
        Console.WriteLine("inserisci l'anno di pubblicazione");
        string anno = Console.ReadLine()!;
        Console.WriteLine("inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("inserisci la quantità del prodotto");
        string quantita = Console.ReadLine()!;
        Console.WriteLine("inserisci l'id dell'artista");
        string id_artista = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        Console.WriteLine("inserisci l'id del genere");
        string id_genere = Console.ReadLine()!;
        connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO album (titolo, anno, prezzo, quantita, id_artista, id_genere) VALUES ('{titolo}', {anno}, {prezzo}, {quantita}, {id_artista}, {id_genere})"; // crea il comando sql che inserisce un prodotto
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaProdotto()
    {
        Console.WriteLine("inserisci il titolo dell'album");
        string titolo = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM album WHERE titolo = '{titolo}'"; // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())

        {
            Console.WriteLine($"id: {reader["id"]}, titolo: {reader["titolo"]}, anno: {reader["anno"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}, id_artista: {reader["id_artista"]}, id_genere: {reader["id_genere"]}");
        }
        connection.Close();
    }

    static void VisualizzaProdottiCategoria()
    {
        Console.WriteLine("inserisci l'id del genere");
        string id_genere = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();

        string sql = $"SELECT * FROM album JOIN artisti ON album.id_artista = artisti.id JOIN generi ON album.id_genere = generi.id WHERE id_genere = {id_genere};"; //WHERE id_genere=ciao; //crea il comando sql che seleziona tutti i dati dalla tabella prodotti


        // crea il comando sql che seleziona tutti i dati dalla tabella prodotti con id_categoria uguale a quello inserito

        stampaTabella(sql, connection);

        connection.Close();

    }

    static void InserisciCategoria()
    {
        Console.WriteLine("inserisci il nome del genere");
        string genere = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO generi (genere) VALUES ('{genere}')"; // crea il comando sql che inserisce una categoria
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void InserisciArtista()
    {
        Console.WriteLine("inserisci il nome dell'artista");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"INSERT INTO artisti (nome) VALUES ('{nome}')"; // crea il comando sql che inserisce una categoria
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }


    static void EliminaCategoria()
    {
        Console.WriteLine("inserisci il nome dell'artista'");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();
        string sql = $"DELETE FROM artisti WHERE nome = '{nome}'"; // crea il comando sql che elimina la categoria con nome uguale a quello inserito
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static bool continuare()
    {
        Console.Write("vuoi continuare?(s/n): ");
        string risp = Console.ReadLine()!;
        if (risp == "n" || risp == "N")
        {
            return false;
        }
        return true;
    }

    static void stampaTabella(string sql, SQLiteConnection connection)
    {
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();

        var table = new Table();
        table.Border(TableBorder.HeavyHead);
        table.AddColumns("ID", "titolo", "anno", "prezzo", "quantita", "artista", "genere");


        while (reader.Read())
        {
            table.AddRow($"{reader["id"]}", $"{reader["titolo"]}", $"{reader["anno"]}", $"{reader["prezzo"]}", $"{reader["quantita"]}", $"{reader["nome"]}", $"{reader["genere"]}");

        }
        Console.WriteLine("\n");
        AnsiConsole.Write(table);
        Console.WriteLine("\n\n");
    }
}
