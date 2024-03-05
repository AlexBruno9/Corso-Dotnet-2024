using System.Data.SQLite;
public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();                          //db
        var view = new View(db);                        //interfaccia utente
        var controller = new Controller(db, view);      //funzionalita gestisce dall'apliccazione
        controller.MainMenu();
    }
}

public class Database
{

    private SQLiteConnection _connection;
    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");          //creazione di un aconnessione al db
        _connection.Open();                                                     //apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection);   //creaz. tabella users
        command.ExecuteNonQuery();
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();
    }

    public void EliminaUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name=('{name}')", _connection);
        command.ExecuteNonQuery();
    }
    public void ModificaUser(string name)
    {
        Console.Write("Inserire nuovo nome: ");
        string newname = Console.ReadLine()!;
        var command = new SQLiteCommand($"UPDATE users SET name=('{newname}') WHERE name=('{name}')", _connection);
        command.ExecuteNonQuery();
    }


    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection);         //creazione comando per leggere gli utenti
        var reader = command.ExecuteReader();                                           //esecuzione del comando e creazione di un oggetto per leggere i risultati

        var users = new List<string>();                                                 //creazione lista x memorizzare nomi degli utenti

        while (reader.Read())
        {
            users.Add(reader.GetString(0));                                             //aggiunta del nome dell'utente alla lista
        }
        return users;
    }

}


class View
{

    private Database _db;                               //riferimento al modello

    public View(Database db)
    {
        _db = db;                                       //inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica");
        Console.WriteLine("4. Elimina");
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<string> users)
    {
        foreach (var user in users)
        {

            Console.WriteLine(user);                 //visualizzazione del nome degli utenti
        }
    }

    public string GetInput()
    {
        return Console.ReadLine()!;                      //lettura dell'input dell'utente
    }
}



class Controller
{
    private Database _db;               //riferimento al modello
    private View _view;                 //riferimento alla vista

    public Controller(Database db, View view)
    {
        _db = db;                         //inizializzazine del riferimento al modello
        _view = view;                     //iniz. del riferimento alla vista
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();               //visualizzazione del menu principale
            var input = _view.GetInput();       //lettura dell input dell utente

            if (input == "1")
            {
                AddUser();                          //aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowUsers();                        //visualizzazione degli utenti
            }
            else if (input == "3")
            {
                ModificaUser();                     //visualizzazione degli utenti
            }
            else if (input == "4")
            {
                EliminaUser();                      //visualizzazione degli utenti
            }
            else if (input == "5")
            {
                break;
            }
        }
    }


    private void AddUser()
    {
        Console.WriteLine("Enter user name:");      //richiesta del nome delll utente
        var name = _view.GetInput();                //lettura del nome dell'utente
        _db.AddUser(name);                          //aggiunta dell'utente al database
    }

    private void EliminaUser()
    {
        Console.WriteLine("Enter user name:");      //richiesta del nome delll utente
        var name = _view.GetInput();                //lettura del nome dell'utente
        _db.EliminaUser(name);                          //aggiunta dell'utente al database
    }


    private void ModificaUser()
    {
        Console.WriteLine("Nome da modificare:");      //richiesta del nome delll utente
        var name = _view.GetInput();                //lettura del nome dell'utente
        _db.ModificaUser(name);                          //aggiunta dell'utente al database
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers();                 //lettura degli utenti del database
        _view.ShowUsers(users);                     //visualizzazione degli utenti
    }



}