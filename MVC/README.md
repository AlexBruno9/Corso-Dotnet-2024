# MVC

MVC è un pattern architetturale che separa i dati, la logica di business e l'interfaccia utente in tre componenti distinti.

- Model: rappresenta i dati e la logica di business
- View: rappresenta l'interfaccia utente
- Controller: gestisce le interazioni tra l'utente e il modello
In uno scenario lavorativo si potrebbe avere un team di sviluppatori che si occupa del modello, un team che si occupa della vista e un team che si occupa del controller.

## ESEMPIO CLASSICO: App che permette di creare un database SQLite e di visualizzarne il contenuto

- Model: classe che rappresenta il database
- View: interfaccia grafica
- Controller: classe che gestisce le interazioni tra l'utente e il modello

comando dotnet per creare l'app

```bash
dotnet new console -n MvcConsole
```

comando dotnet per installare il pacchetto System.Data.SQLite

```bash
dotnet add package System.Data.SQLite
```

```csharp
using System.Data.SQLite;
class Program
{
    static void Main(string[] args)
    {
        var db = new Database(); // Model
        var view = new View(db); // View
        var controller = new Controller(db, view); // Controller
        controller.MainMenu(); // Menu principale dell'app
    }
}
```

```csharp
class Database
{
    private SQLiteConnection _connection; // SQLiteConnection è una classe che rappresenta una connessione a un database SQLite
                                          // Si utilizza l'underscore davanti al nome della variabile per indicare che è privata e non accessibile dall'esterno

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db"); // Creazione di una connessione al database
        _connection.Open(); // Apertura della connessione
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection); // Creazione della tabella users
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection); // Creazione di un comando per inserire un nuovo utente
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection); // Creazione di un comando per leggere gli utenti
        var reader = command.ExecuteReader(); // Esecuzione del comando e creazione di un oggetto per leggere i risultati
        var users = new List<string>(); // Creazione di una lista per memorizzare i nomi degli utenti
        while (reader.Read())
        {
            users.Add(reader.GetString(0)); // Aggiunta del nome dell'utente alla lista
        }
        return users; // Restituzione della lista
    }
}
```

```csharp
class View
{
    private Database _db; // Riferimento al modello

    public View(Database db)
    {
        _db = db; // Inizializzazione del riferimento al modello
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Esci");
    }

    public void ShowUsers(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user); // Visualizzazione dei nomi degli utenti
        }
    }

    public string GetInput()
    {
        return Console.ReadLine(); // Lettura dell'input dell'utente
    }
}
```

```csharp
class Controller
{
    private Database _db; // Riferimento al modello
    private View _view; // Riferimento alla vista

    public Controller(Database db, View view)
    {
        _db = db; // Inizializzazione del riferimento al modello
        _view = view; // Inizializzazione del riferimento alla vista
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu(); // Visualizzazione del menu principale
            var input = _view.GetInput(); // Lettura dell'input dell'utente
            if (input == "1")
            {
                AddUser(); // Aggiunta di un utente
            }
            else if (input == "2")
            {
                ShowUsers(); // Visualizzazione degli utenti
            }
            else if (input == "3")
            {
                break; // Uscita dal programma
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:"); // Richiesta del nome dell'utente
        var name = _view.GetInput(); // Lettura del nome dell'utente
        _db.AddUser(name); // Aggiunta dell'utente al database
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers(); // Lettura degli utenti dal database
        _view.ShowUsers(users); // Visualizzazione degli utenti
    }
}
```

## AGGIUNTA NUOVA FUNZIONALITA' 3 MODIFICA 4 ELIMINA ED ESCI diventa 5

CODICE COMPLETO

```csharp
using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View(db);
        var controller = new Controller(db, view);
        controller.MainMenu();
    }
}

class Database
{
    private SQLiteConnection _connection;

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");
        _connection.Open();
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection);
        command.ExecuteNonQuery();
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection);
        command.ExecuteNonQuery();
    }

    public List<string> GetUsers()
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection);
        var reader = command.ExecuteReader();
        var users = new List<string>();
        while (reader.Read())
        {
            users.Add(reader.GetString(0));
        }
        return users;
    }

    public void UpdateUser(string oldName, string newName)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = '{newName}' WHERE name = '{oldName}'", _connection); // Aggiunta di una nuova funzionalità
        command.ExecuteNonQuery(); // Esecuzione del comando
    }

    public void DeleteUser(string name)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{name}'", _connection); // Aggiunta di una nuova funzionalità
        command.ExecuteNonQuery(); // Esecuzione del comando
    }
}

class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica user"); // Aggiunta di una nuova funzionalità
        Console.WriteLine("4. Elimina user"); // Aggiunta di una nuova funzionalità
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<string> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }
}

class Controller
{
    private Database _db;
    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                UpdateUser(); // Aggiunta di una nuova funzionalità
            }
            else if (input == "4")
            {
                DeleteUser(); // Aggiunta di una nuova funzionalità
            }
            else if (input == "5")
            {
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _db.AddUser(name);
    }

    private void ShowUsers()
    {
        var users = _db.GetUsers();
        _view.ShowUsers(users);
    }

    private void UpdateUser()
    {
        Console.WriteLine("Enter user name:");
        var oldName = _view.GetInput(); // Aggiunta di una nuova funzionalità
        Console.WriteLine("Enter new user name:");
        var newName = _view.GetInput(); // Aggiunta di una nuova funzionalità
        _db.UpdateUser(oldName, newName); 
    }

    private void DeleteUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput(); // Aggiunta di una nuova funzionalità
        _db.DeleteUser(name);
    }
}
```


## VANTAGGI

- Separazione delle responsabilità
- Facilità di manutenzione
- Facilità di test
- Riusabilità del codice
- Scalabilità
- Facilità di sviluppo parallelo
- Facilità di sostituzione di una parte del sistema

# ESEMPIO CON MVC ED ENTITY FRAMEWORK

```bash
dotnet new console -n MvcConsoleDatabase
```

```bash
dotnet add package Microsoft.EntityFrameworkCore
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

```csharp
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new View(db);
        var controller = new Controller(db, view);
        controller.MainMenu();
    }
}

class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Database : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=database.db");
    }
}

class View
{
    private Database _db;

    public View(Database db)
    {
        _db = db;
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }
}

class Controller
{
    private Database _db;
    private View _view;

    public Controller(Database db, View view)
    {
        _db = db;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                UpdateUser();
            }
            else if (input == "4")
            {
                DeleteUser();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _db.Users.Add(new User { Name = name });
        _db.SaveChanges();
    }

    private void ShowUsers()
    {
        var users = _db.Users.ToList();
        _view.ShowUsers(users);
    }

    /* private void UpdateUser()
     {
         Console.WriteLine("Enter user name:");
         var oldName = _view.GetInput();
         Console.WriteLine("Enter new user name:");
         var newName = _view.GetInput();
         var user = _db.Users.FirstOrDefault(u => u.Name == oldName); // first or default restituisce il primo elemento che soddisfa la condizione, altrimenti restituisce null
         if (user != null)
         {
             user.Name = newName;
             _db.SaveChanges();
         }
     }
     */

    private void UpdateUser()
    {
        Console.WriteLine("Enter user name:");
        var oldName = _view.GetInput();
        Console.WriteLine("Enter new user name:");
        var newName = _view.GetInput();

        User user = null;
        foreach (var u in _db.Users)
        {
            if (u.Name == oldName)
            {
                user = u;
                break; // Esce dal ciclo una volta trovato l'utente
            }
        }

        if (user != null)
        {
            user.Name = newName;
            _db.SaveChanges();
        }
    }

    /* private void DeleteUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        var user = _db.Users.FirstOrDefault(u => u.Name == name); // first or default restituisce il primo elemento che soddisfa la condizione, altrimenti restituisce null
        if (user != null)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
*/

    private void DeleteUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();

        User userToDelete = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToDelete = user;
                break; // Esce dal ciclo una volta trovato l'utente
            }
        }

        if (userToDelete != null)
        {
            _db.Users.Remove(userToDelete);
            _db.SaveChanges();
        }
    }
}
```

# ESEMPIO DI CONTROLLER E VISTE SEPARATI

User.cs

```csharp
class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

Database.cs

```csharp
class Database
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=database.db");
    }
}
```

Program.cs

```csharp
class Program
{
    static void Main(string[] args)
    {
        var db = new Database();
        var view = new UserView();
        var dbController = new DatabaseController(db);
        var controller = new UserController(dbController, view);
        controller.MainMenu();
    }
}
```

UserController.cs

```csharp
class UserController
{
    private DatabaseController _dbController;
    private UserView _view;

    public UserController(DatabaseController dbController, UserView view)
    {
        _dbController = dbController;
        _view = view;
    }

    public void MainMenu()
    {
        while (true)
        {
            _view.ShowMainMenu();
            var input = _view.GetInput();
            if (input == "1")
            {
                AddUser();
            }
            else if (input == "2")
            {
                ShowUsers();
            }
            else if (input == "3")
            {
                UpdateUser();
            }
            else if (input == "4")
            {
                DeleteUser();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }

    private void AddUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _dbController.AddUser(name);
    }

    private void ShowUsers()
    {
        var users = _dbController.GetUsers();
        _view.ShowUsers(users);
    }

    private void UpdateUser()
    {
        Console.WriteLine("Enter user name:");
        var oldName = _view.GetInput();
        Console.WriteLine("Enter new user name:");
        var newName = _view.GetInput();
        _dbController.UpdateUser(oldName, newName);
    }

    private void DeleteUser()
    {
        Console.WriteLine("Enter user name:");
        var name = _view.GetInput();
        _dbController.DeleteUser(name);
    }
}
```

UserView.cs

```csharp
class UserView
{
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Aggiungi user");
        Console.WriteLine("2. Leggi users");
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }
}
```

DatabaseController.cs

```csharp
class DatabaseController
{
    private Database _db;

    public DatabaseController(Database db)
    {
        _db = db;
    }

    public void AddUser(string name)
    {
        _db.Users.Add(new User { Name = name });
        _db.SaveChanges();
    }

    public List<User> GetUsers()
    {
        return _db.Users.ToList();
    }

    public void UpdateUser(string oldName, string newName)
    {
        User user = null;
        foreach (var u in _db.Users)
        {
            if (u.Name == oldName)
            {
                user = u;
                break;
            }
        }

        if (user != null)
        {
            user.Name = newName;
            _db.SaveChanges();
        }
    }

    public void DeleteUser(string name)
    {
        User userToDelete = null;
        foreach (var user in _db.Users)
        {
            if (user.Name == name)
            {
                userToDelete = user;
                break;
            }
        }

        if (userToDelete != null)
        {
            _db.Users.Remove(userToDelete);
            _db.SaveChanges();
        }
    }
}
```