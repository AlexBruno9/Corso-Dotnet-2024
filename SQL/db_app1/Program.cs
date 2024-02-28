using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        string path=@"database.db";

        if(!File.Exists(path))                         
        {
            SQLiteConnection.CreateFile(path);                                                      //crea il file nel database
            SQLiteConnection connection = new SQLiteConnection($"Data Source={path};Version=3;");   //crea la connessione al database, la versione 3 e' a caso
            connection.Open();                                                                      //apre la connessione al db
            
            string sql= @"
                        CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita>=0));
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
                        INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
            ";

            SQLiteCommand command = new SQLiteCommand (sql, connection);        //crea il comando sql da eseguire sulla connessione al database
            command.ExecuteNonQuery();                                          //esegue il comando sql sulla connesione al database
            connection.Close();                                                 //chiude la connessione al database
        }

        while(true)
        {
            Console.WriteLine("1 - inserisci prodotto");
            Console.WriteLine("2 - visualizza prodotti");
            Console.WriteLine("3 - elimina prodotto");
            Console.WriteLine("4 - esci");
            Console.WriteLine("scegli un'opzione");

            string scelta = Console.ReadLine()!;

            if(scelta=="1")
            {
                InserisciProdotto();
            }
            else if(scelta=="2")
            {
                VisualizzaProdotto();
            }
            else if(scelta=="3")
            {
                EliminaProdotto();
            }
            else if(scelta=="4")
            {
                break;
            }


        }

    }


    static void InserisciProdotto()
    {
        Console.Write("Inserisci il nome del prodotto: ");
        string nome=Console.ReadLine()!;
        Console.Write("Inserisci il prezzo del prodotto: ");
        string prezzo=Console.ReadLine()!;
        Console.Write("Inserisci la quantita del prodotto: ");
        string quantita=Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();

        string sql= $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";

        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();                                      
        connection.Close();       

    }



    static void VisualizzaProdotto()
    {

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();





        
        string sql= $"SELECT * FROM prodotti";

        SQLiteCommand command = new SQLiteCommand(sql, connection);     //crea il comando sql da eseguire sulla connessione al database
        SQLiteDataReader reader = command.ExecuteReader();              //esegue il comando sulla connessione al db e salva i dati in reader che è un oggetto di sql incaricato di leggere i dati

        while(reader.Read())
        {
           /* Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");*/
           Console.WriteLine($"id: {reader["id"]}");
           object identita=reader["id"];
            Console.WriteLine($"{identita}\n");
            string id=identita.ToString()!;
        Console.WriteLine($"{id}\n");

           
        }
        

        connection.Close();       

    }

    

    static void EliminaProdotto()
    {
        Console.Write("Inserisci il nome del prodotto che vuoi eliminare: ");
        string nome=Console.ReadLine()!;

        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db;Version=3;");
        connection.Open();

        string sql= $"DELETE FROM prodotti WHERE nome = '{nome}';";

        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();                                      
        connection.Close();       
    }



}
