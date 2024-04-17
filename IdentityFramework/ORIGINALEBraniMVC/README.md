# PROGETTO CATALOGO DISCHI

Applicazione utilizzata per il catalogo di brani musicali, inseriti in un database memorizzandone titolo, artista, anno di pubblicazione e durata. Sono necessari inoltre un collegamento all'immagine di copertina e uno al file audio del brano.

L'app disponde di due funzioni;

- 'moderatore': possibilità di aggiungere / rimuovere / modificare brani dal catalogo
- 'utente': possibilità di inserire i brani presenti in catalogo nella propria playlist personale, ma non è possibile apportare modifiche al catalogo

## PUBBLICO TARGET

- L'applicazione può essere usata dagli utenti che vogliono tenere memorizzati in una playlist personale i propri brani preferiti.

## DEFINIZIONE DEI REQUISITI E ANALISI

- [x] L'applicazione necessita di un login:
  - un utente non autenticato può accedere unicamente alla pagina Home
  - un moderatore potrà accedere alle pagine Home e Brani
  - un user potrà accedere alle pagine Home, Brani e Playlist
- [x] L'applicazione deve richiedere necessariamente determinati campi nell'inserimento di un brano.
- [x] L'applicazione deve essere responsive in modo da poter essere utilizzata su più piattaforme.
- [x] Se non è presente un utente Admin, viene creato dall'applicazione al momento dell'avvio.
  - Admin: alex@admin.com Password: Admin123!
- [x] Controllo in modo da gestire eccezioni nei casi che il catalogo o una playlist richiamata siano vuoti.

# FUNZIONAMENTO APPLICAZIONE

- [x] L'applicazione consente al moderatore di inserire, modificare ed eliminare dischi dal catalogo, all'utente di inserire o rimuovere i brani dalla propria playlist.
- [x] L'applicazione deve consentire all'utente di ricercare tramite dei filtri (per Titolo del brani o per Artista).
- [x] Per ogni utente registrato verrà creato un file json contenente la propria playlist.
- [x] I file json contenenti i dati del Catalogo o delle playlist dei vari utenti dovranno modificarsi in modo autonomo oni volta che dal sito vengono attuate modifiche.

### - MIGLIORAMENTI con Fabio:

- [x] finire pagina DettaglioBrano, conterra immagine grande + titolo artista anno e magari durata
- [x] inserire font ovunque
- [x] bottoni modifica / elimina
- [x] checkbox per possibilità scelta multipla per aggiungere brani !!!!
- [x] scelta genere tramite tendina (accordion)
- [x] colore navbar
- [x] ingrandire checkbox in playlist
- [x] controllo lista brani vuota
- [x] bottoni next - previous
- [x] verificare responsività per ogni pagina

## PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- L'applicazione verrà creata utilizzando un pattern MVC

- I file del progetto saranno quindi suddivisi in:

  - Models, file contenenti i modelli utilizzati nelle viste
  - Views, contenente i file html
  - Controllers, file .cs che gestiscono le azioni di Admin, User ed Home

  - wwwroot - contenente i file json utilizzati dal programma per leggere e salvare i brani (Brani / Playlist / Generi)

- Registrazione, Login e gestione degli utenti sono gestiti da Identity Framework che salva i dati in un Db di tipo sqlite

- Pages:
  - Home: pagina di home che mostra un susseguirsi di immagini di dischi (basate sulle copertine delle canzoni memorizzate) grazie a dei caroselli
  - Brani: mostra l'elenco dei brani disponibili in catalogo; l'Admin da questa pagina ha la possibilita di aggiungere, eliminare o modificare dischi dal catalogo, lo user potrà invece selezionare tali brani per aggiungerli alla propria playlist.
  - Playlist: pagina visualizzabile solo da user, da cui quest'ultimo potrà riprodurre la propria playlist; potrà scegliere se riprodurre un singolo brano o avviare la riproduzione totale della playlist.

> Struttura dei file json

```json

[
    {
    "Id": 1
    "Titolo": "Titolo 1",
    "Artista": "Artista 1",
    "Anno": 2000,
    "Immagine": "https://source.unsplash.com/random/300x200?sig=1&web"
  },
  {
    "Id": 2,
    "Titolo": "Titolo 2",
    "Artista": "Artista 2",
    "Anno": 2020,
    "Immagine": "https://source.unsplash.com/random/300x200?sig=1&web"
  }
]

```

## DEFINIZIONE DI STRUTTURE E CONVENZIONI

- [x] I nomi dei **namespace** devono essere PascalCase.
- [x] I nomi delle **classi** devono essere PascalCase.
- [x] I nomi dei **metodi** devono essere PascalCase.
- [x] I nomi delle **variabili** devono essere camelCase.
- [x] I nomi delle **costanti** devono essere SNAKE_UPPERCASE.
