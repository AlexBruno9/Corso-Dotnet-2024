# Entity Framework

## Introduzione

Entity Framework Supporta lo sviluppo di applicazioni basate su dati con un modello di programmazione orientato agli oggetti. EF consente di mappare i dati tra il database e il codice .NET, fornendo un'esperienza di sviluppo di database più semplice e più produttiva.

## Installazione

Per installare Entity Framework, è possibile utilizzare il comando dotnet:

```bash
dotnet add package Microsoft.EntityFrameworkCore
```

Per installare il provider in memory, è possibile utilizzare il comando dotnet:

```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
## ESEMPO CLASSICO CRUD CON DATABASE IN MEMORY

Per utilizzare un database in memoria, è possibile utilizzare il provider `Microsoft.EntityFrameworkCore.InMemory`:
Successivamente si può scegliere il database da utilizzare con il metodo `UseInMemoryDatabase` ed eseguire la migrazione del database con il metodo `EnsureCreated`.
Il database in memoria verrà distrutto quando l'applicazione verrà chiusa.
```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

```csharp
using Microsoft.EntityFrameworkCore;
class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; } // DbSet rappresenta una tabella del database in memoria tramite il modello Cliente recupera i dati

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // OnCofiguring imposta le opzioni del database in memoria
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase"); // UseInMemoryDatabase imposta il database in memoria
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database()) // using si utilizza per garantire che il database venga chiuso
        {
            var cliente = new Cliente { Nome = "Mario", Cognome = "Rossi" }; // Creazione di un nuovo cliente
            db.Clienti.Add(cliente); // Aggiunta del cliente al database
            db.SaveChanges(); // Salvataggio delle modifiche

            var clienti = db.Clienti.ToList(); // Recupero di tutti i clienti dal database
            foreach (var c in clienti)
            {
                Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome}"); // Stampa di tutti i clienti
            }
        }
    }
}
```

## AGGIUNTA DI FUNZIONALITÀ AL MODELLO CRUD IN MEMORY:

Inserimento di una lista di clienti e stampa di tutti i clienti utilizzando due metodi personalizzati `InserisciClienti` e `StampaClienti`.

```csharp
using Microsoft.EntityFrameworkCore;

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti); // AddRange aggiunge una lista di clienti al database
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.ToList(); // ToList recupera tutti i clienti dal database
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome}"); // Stampa di tutti i clienti
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi" }
            };
            db.InserisciClienti(clienti); // Inserimento di una lista di clienti
            db.StampaClienti(); // Stampa di tutti i clienti
        }
    }
}
```

## AGGIUNTA DI FUNZIONALITÀ AL MODELLO CRUD IN MEMORY:

Aggiunta di campi alla tabella clienti e stampa di tutti i clienti con i nuovi campi.

```csharp
using Microsoft.EntityFrameworkCore;

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; } // Aggiunta del campo telefono
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            db.InserisciClienti(clienti);
            db.StampaClienti();
        }
    }
}
```

## AGGIUNTA DI FUNZIONALITÀ AL MODELLO CRUD IN MEMORY:

Aggiunta di un metodo per la modifica del campo telefono

```csharp
using Microsoft.EntityFrameworkCore;

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; }
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
        }
    }

    public void UpdateTelefono(int id, string telefono)
    {
        var cliente = Clienti.Find(id); // Find recupera un cliente dal database in base all'id
        cliente.Telefono = telefono; // Modifica del campo telefono
        SaveChanges();
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            db.InserisciClienti(clienti);
            db.StampaClienti();

            db.UpdateTelefono(1, "0987654321"); // Modifica del campo telefono del cliente con id 1
            db.StampaClienti();
        }
    }
}
```

## AGGIUNTA DI FUNZIONALITÀ AL MODELLO CRUD IN MEMORY:

Aggiunta di una tabella prodotti e relazione uno a molti con la tabella clienti e stampa di clienti e prodotti attraverso i metodi`InserisciClienti`, `InserisciProdotti` e `StampaClienti`, `StampaProdotti`.

```csharp
using Microsoft.EntityFrameworkCore;

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; }
    public List<Prodotto> Prodotti { get; set; } // Relazione uno a molti con la tabella prodotti
}

class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } // Relazione con la tabella clienti
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Prodotto> Prodotti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList(); // Include recupera i prodotti per ogni cliente
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
            foreach (var p in c.Prodotti)
            {
                Console.WriteLine($"  {p.Id} - {p.Nome} - {p.Prezzo}");
            }
        }
    }

    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);
        SaveChanges();
    }

    public void StampaProdotti()
    {
        var prodotti = Prodotti.ToList();
        foreach (var p in prodotti)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente.Nome} {p.Cliente.Cognome}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            Console.WriteLine("clienti");
            db.InserisciClienti(clienti);
            db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 10, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 20, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 30, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 4", Prezzo = 40, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 5", Prezzo = 50, ClienteId = 3 },
                new Prodotto { Nome = "Prodotto 6", Prezzo = 60, ClienteId = 3 }
            };
            Console.WriteLine("prodotti per clienti");
            db.InserisciProdotti(prodotti);
            db.StampaProdotti();
        }
    }
}
```

## AGGIUNTA DI FUNZIONALITÀ AL MODELLO CRUD IN MEMORY:

Aggiunta di una tabella ordini e relazione molti a molti con la tabella prodotti e uno a molti con la tabella clienti e stampa di tutti gli ordini

```csharp
using Microsoft.EntityFrameworkCore;

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Telefono { get; set; }
    public List<Prodotto> Prodotti { get; set; }
}

class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public List<Ordine> Ordini { get; set; }
}

class Ordine
{
    public int Id { get; set; }
    public int ProdottoId { get; set; }
    public Prodotto Prodotto { get; set; }
}

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }
    public DbSet<Prodotto> Prodotti { get; set; }
    public DbSet<Ordine> Ordini { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} - {c.Telefono}");
            foreach (var p in c.Prodotti)
            {
                Console.WriteLine($"  {p.Id} - {p.Nome} - {p.Prezzo}");
            }
        }
    }

    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);
        SaveChanges();
    }

    public void StampaProdotti()
    {
        var prodotti = Prodotti.Include(p => p.Cliente).ToList();
        foreach (var p in prodotti)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente.Nome} {p.Cliente.Cognome}");
        }
    }

    public void InserisciOrdini(List<Ordine> ordini)
    {
        Ordini.AddRange(ordini);
        SaveChanges();
    }

    public void StampaOrdini()
    {
        var ordini = Ordini.Include(o => o.Prodotto).ThenInclude(p => p.Cliente).ToList(); // ThenInclude recupera i clienti per ogni prodotto dato che non si può utilizzare Include per più di un livello
        foreach (var o in ordini)
        {
            Console.WriteLine($"{o.Id} - {o.Prodotto.Nome} - {o.Prodotto.Cliente.Nome} {o.Prodotto.Cliente.Cognome}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono = "1234567890" },
                new Cliente { Nome = "Luigi", Cognome = "Verdi", Telefono = "1234567890" },
                new Cliente { Nome = "Giovanni", Cognome = "Bianchi", Telefono = "1234567890" }
            };
            Console.WriteLine("clienti");
            db.InserisciClienti(clienti);
            db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "Prodotto 1", Prezzo = 10, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 2", Prezzo = 20, ClienteId = 1 },
                new Prodotto { Nome = "Prodotto 3", Prezzo = 30, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 4", Prezzo = 40, ClienteId = 2 },
                new Prodotto { Nome = "Prodotto 5", Prezzo = 50, ClienteId = 3 },
                new Prodotto { Nome = "Prodotto 6", Prezzo = 60, ClienteId = 3 }
            };
            Console.WriteLine("prodotti per clienti");
            db.InserisciProdotti(prodotti);
            db.StampaProdotti();

            var ordini = new List<Ordine>
            {
                new Ordine { ProdottoId = 1 },
                new Ordine { ProdottoId = 2 },
                new Ordine { ProdottoId = 3 },
                new Ordine { ProdottoId = 4 },
                new Ordine { ProdottoId = 5 },
                new Ordine { ProdottoId = 6 }
            };
            Console.WriteLine("ordini");
            db.InserisciOrdini(ordini);
            db.StampaOrdini();
        }
    }
}
```
# IMPOSTARE ALTRI TIPI DI DATABASE

dotnet ef migrations add InitialCreate
dotnet ef database update

comando per installare globalmente ef

dotnet tool install --global dotnet-ef

## IN MEMORY

Provider InMemory comando dotnet:

```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
La stringa di connessione è stata impostata con il metodo `UseInMemoryDatabase` nel metodo `OnConfiguring` della classe `Database`

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseInMemoryDatabase("MyDatabase");
}
```

## SQLITE

La stringa di connessione è stata impostata con il metodo `UseSqlite` nel metodo `OnConfiguring` della classe `Database`

Provider Sqlite comando dotnet:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
}
```

## SQLSERVER

Provider SqlServer comando dotnet:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
Bisogna installare SQL Server Express quindi scaricare il file .exe da questo link:

https://www.microsoft.com/it-it/sql-server/sql-server-downloads

La stringa di connessione è stata impostata con il metodo `UseSqlServer` nel metodo `OnConfiguring` della classe `Database`

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
}
```
## MYSQL

Provider MySql comando dotnet:

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
```
La stringa di connessione è stata impostata con il metodo `UseMySql` nel metodo `OnConfiguring` della classe `Database`

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseMySql("Server=localhost;Database=MyDatabase;User=root;Password=1234;", ServerVersion.AutoDetect("Server=localhost;Database=MyDatabase;User=root;Password=1234;"));
}
```
## NPGSQL

Provider Npgsql comando dotnet:

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```
La stringa di connessione è stata impostata con il metodo `UseNpgsql` nel metodo `OnConfiguring` della classe `Database`

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql("Host=localhost;Database=MyDatabase;Username=postgres;Password=1234");
}

## MIGRAZIONI


Bisogna installare Download .NET 8.0 Runtime (v8.0.0) - Windows x64

Installare NET runtime 8.0.2 (v8.0.2) - Windows x64
https://dotnet.microsoft.com/download/dotnet/8.0
oppure
https://dotnet.microsoft.com/download/dotnet/8.0/runtime
https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-8.0.1-windows-x64-installer

Ogni volta che si cambia la struttura del database, è necessario eseguire una migrazione del database.

Per eseguire la migrazione del database, è possibile utilizzare il comando `dotnet ef migrations add <nome_migrazione>` per creare una nuova migrazione e `dotnet ef database update` per applicare le migrazioni al database.

Bisogna installare il tool `dotnet-ef` con il comando:

```bash
dotnet tool install --global dotnet-ef
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Verrà creata una cartella `Migrations` contenente le migrazioni del database.
Verrà creato un file `MyDatabase.sqlite` contenente il database.
```