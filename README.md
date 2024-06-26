<details>
<summary>01 - COMANDI TERMINALE</summary>

```C#

// versionamento
 git add .\Program.cs
 git commit -m ""
 git push

//in bash add senza .\ a seguito
//git push -u origin main (serve solo la prima volta)
//tutto: git add all   / in bash: git add .

// delete last commit(*)
//HARD elimina il file
 git reset --soft HEAD^
 git push origin -f

// ConsoleModifiers
 ctrl
 alt
 shift

//  Formattazione
shift+alt+f

```

</details>

<details>
<summary>02 - MARKUP LANGUAGE</summary>

# Titolo principale

## Sottotitolo 1

### Titolo paragrafo

TABELLA

| Syntax    | Description |
| --------- | ----------- |
| Header    | Title       |
| Paragraph | ![esempio]  |

esempio di **grassetto** o **bold** / _italic_
[esempio di link](02_link.md)

ELENCO

- primo
  - sottoelenco
- secondo
  - sottoelenco
- terzo
- quarto

- CHECKBOX
- [x] ciao
- [ ] primo

- GRAFICO MERMAID

```mermaid
graph TD;
A-->B;
A-->C;
B-->D;
C-->D;
```

- GRAFICO GANTT

```mermaid

gantt
title A Gantt Diagram
dateFormat  YYYY-MM-DD
section Section
First Task       :a1, 2018-07-01, 30d
Another Task     :after a1, 20d
section Another
Second Task      :2018-07-12, 12d
Third Task       : 24d
```

</details>

<details>
<summary>03 - BETA TESTING</summary>

_BETA TESTING_

> Best practice e suggerimenti per condurre sessioni di beta testing efficaci:

1. Definire Obiettivi Chiari

- Determinare cosa si vuole raggiungere con il beta testing (es. individuare bug, valutare l usabilità, capire le esigenze degli utenti).
- Definire quali risultati considereresti un successo per la fase di beta testing.

2. Selezione dei Beta Tester

- Diversità: Scegliere un gruppo di beta tester vario che rappresenti il tuo pubblico di riferimento.
- Coinvolgimento: Selezionare utenti realmente interessati al prodotto e che possano fornire feedback costruttivi.

3. Preparazione e Documentazione

- Guida per i tester: Fornire istruzioni chiare su come usare il prodotto e su come segnalare problemi o suggerimenti.
- Assicurarsi che i beta tester abbiano accesso a tutte le informazioni necessarie per utilizzare il prodotto correttamente.

4. Strumenti per il Beta Testing

- Piattaforme di feedback: Utilizzare strumenti come Jira, Trello o apposite piattaforme di beta testing per raccogliere e gestire i feedback.
- Software di monitoraggio: Implementare soluzioni di tracking per monitorare l uso del prodotto e raccogliere dati.

5. Comunicazione Efficace

- Essere disponibili per rispondere a domande e fornire supporto ai beta tester.
- Incoraggiare il feedback: Stimolare i beta tester a condividere le loro opinioni e esperienze in modo onesto e dettagliato.

6. Gestione del Feedback

- Valutare tutti i feedback ricevuti e determinare quali azioni intraprendere.
- Aggiornamenti regolari: Informare i beta tester sugli aggiornamenti o sui cambiamenti apportati in base al loro feedback.

7. Testing Iterativo

- Cicli di feedback: Condurre più cicli di beta testing, apportando modifiche e miglioramenti dopo ogni ciclo.
- Valutazione continua: Monitorare costantemente le prestazioni e l'usabilità del prodotto.

8. Riconoscimento e Ringraziamento

- Mostrare riconoscimento per il tempo e lo sforzo dedicato dai beta tester offrendo incentivi, come accesso anticipato a funzionalità o sconti sul prodotto.

9. Rispetto della Privacy e della Sicurezza

- Protezione dei dati: Assicurarsi che tutte le informazioni raccolte durante il beta testing siano trattate nel rispetto della privacy.

_Post-Beta Testing_

> Il successo del beta testing dipende sia dalla raccolta di feedback che dalla tua capacità di interpretare e agire in base a questo feedback in modo tempestivo.

1. Raccolta e Organizzazione del Feedback:

- Sistema tutti i feedback raccolti in categorie (bug, suggerimenti di miglioramento, problemi di usabilità, richieste di nuove funzionalità...) .

2. Prioritizzazione:

- Determina quali feedback sono più critici e vanno affrontati per primi. Considera l'impatto sulla user experience e sulla stabilità del prodotto.

3. Revisione Completa:

- il completamento del beta testing, esegui una revisione per assicurarti che tutti i problemi critici siano stati risolti.

4. Pianifica il Lancio

- Prepara il piano di lancio basato sui risultati del beta testing.

5. Valutare l'Esperienza di Beta Testing:

- Rivedi il processo di beta testing stesso per identificare aree di miglioramento per i futuri cicli di test

</details>

<details>
<summary>04 - PACKAGES</summary>

### ENTITY FRAMEWORK

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI (serve per Mac)
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Microsoft.EntityFrameworkCore.InMemory

### MIGRATIONS

- dotnet tool install --global dotnet-ef

- dotnet ef migrations add InitialCreate
- dotnet ef database update

### SCAFFOLDING

dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc MvcAuthApp.Data.ApplicationDbContext

// scaffolfing di identity ed assegnazione ruolo fornitore automatico
dotnet aspnet-codegenerator identity -dc BraniMVC.Data.ApplicationDbContext --files "Account.Register"

</details>

<details>
<summary>05 - ESAME</summary>

serial/deserial json  
bootstrap namepage con varie sezioni (navbar, ecc..) responsività!!  
mermaid, (sia logica che uno a molti ecc) + diagramma di gant

</details>
