using Microsoft.EntityFrameworkCore;

/*
PROGRAMMA CHE CREA E GESTISCE DATABASE TRAMITE ENTITY FRAMEWORK
AGGIUNGE, ELIMINA, MODIFICA, STAMPA GLI UTENTI NEL DATABASE
PROGRAMMA CHE SEGUE MODELLO MVC (model, view, controller)
*/



//  -----   MAIN    -----

public class Program
{
    static void Main(string[] args)
    {
        var db = new Database();                        //db
        var view = new View(db);                        //interfaccia utente
        var controller = new Controller(db, view);      //funzionalita gestisce dall'apliccazione
        controller.MainMenu();
    }
}


//  -----   CLASS USER  -----
public class User
{
    public int Id { get; set; }
    public string? Nome { get; set; }

}

//  -----   DATABASE    -----

public class Database : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //configura del database in memoria
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
    }

    public void AddUser(string name)
    {
        User utente = new User();
        utente.Nome = name;
        Users.Add(utente);
        SaveChanges();
    }


    public void ModificaUser(string nome)
    {
        Console.Write("Inserisci nome corretto: ");
        string nuovo = Console.ReadLine()!;
        foreach (User u in Users)
        {

            if (u.Nome == nome)
            {

                u.Nome = nuovo;
                SaveChanges();
            }
        }
    }

        public void EliminaUser(string nome)
    {
        foreach (User u in Users)
        {

            if (u.Nome == nome)
            {
                Remove(u);
                SaveChanges();
            }
        }
    }




    public List<string> GetUsers()
    {
        var variabile = Users.ToList();
        List<string> utenti = new();
        foreach (var v in variabile)
        {
            utenti.Add(v.Nome!);
        }
        return utenti;
    }




}

//  -----   VIEW    -----

public class View
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
        Console.WriteLine("3. Modifica user");
        Console.WriteLine("4. Elimina user");
        Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<string> users)
    {
        Console.WriteLine("Lista utenti:");
        foreach (var u in users)
        {
            Console.WriteLine(u);                 //visualizzazione del nome degli utenti
        }
    }


    public string GetInput()
    {
        return Console.ReadLine()!;                      //lettura dell'input dell'utente
    }

}


//  -----   CONTROLLER  -----

public class Controller
{
    private Database _db;               //riferimento al modello
    private View _view;                 //riferimento alla vista

    public Controller(Database db, View view)
    {
        _db = db;                         //inizializzazione del riferimento al modello
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
                ModificaUser();                        //visualizzazione degli utenti
            }
            else if (input == "4")
            {
                EliminaUser();                        //visualizzazione degli utenti
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

    private void ShowUsers()
    {
        var users = _db.GetUsers();                 //lettura degli utenti del database
        _view.ShowUsers(users);
    }

    private void ModificaUser()
    {
        Console.Write("Inserisci nome dell'utente da modificare: ");
        var nome = _view.GetInput();
        _db.ModificaUser(nome);
    }

    private void EliminaUser()
    {
        Console.Write("Inserisci nome dell'utente da eliminare: ");
        var nome = _view.GetInput();
        _db.EliminaUser(nome);

    }


}