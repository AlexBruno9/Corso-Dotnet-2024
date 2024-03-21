# PROGETTO CATALOGO DISCHI

Applicazione utilizzata per il catalogo di brani musicali, inseriti in un database memorizzandone titolo, artista e anno di pubblicazione.  
L'app disponde di due funzioni: 
 - una per 'moderatori' da cui vengono inseriti e modificati i brani in catalogo
 - una per 'utenti' da cui i brani presenti in catalogo possono essere inseriti nella playlist personale del cliente 

## PUBBLICO TARGET

- L'applicazione può essere usata dagli utenti che vogliono tenere memorizzati in una playlist personale i propri brani preferiti.

## DEFINIZIONE DEI REQUISITI E ANALISI

- [ ] L'applicazione necessita di un login da parte dell'utente.
- [ ] L'applicazione consente al moderatore di inserire, modificare ed eliminare dischi dal catalogo, all'utente di inserire o rimuovere i brani dalla propria playlist.
- [ ] L'applicazione deve consentire all'utente di visualizzare l'elenco dei brani in catalogo e la propria playlist.
- [ ] L'applicazione deve poter gestire il corretto inserimento dei campi da memorizzare.
- [ ] L'applicazione deve evitare l'inserimento di dati rindondanti (brano con stesso titolo e artista).



# FUNZIONAMENTO APPLICAZIONE

- l'applicazione memorizza i brani e la propria playlist
- il moderatore deve può inserire brani in catalogo e l'utente può aggiungere quei brani alla propria playlist
- prima di inserire una canzone in playlist, dovrà ovviamente essere già memorizzata nel catalogo



### - MIGLIORAMENTI:

- [x] fare pagina playlist 

- [ ] aggiungere pagina DettaglioBrano, conterra immagine grande + titolo artista anno e magari durata  
  -     + bottoni modifica / elimina

- [ ] aggiungere filtri di ricerca nella pagina Brani

## PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- L'applicazione verrà creata utilizzando Razor
- Saranno utilizzate le cartelle:
  - Models - contenente le classi utilizzate (Brano.cs)
  - Pages  - contenente i file html e cs relative alle pagine visualizzate nella webApp
  - wwwroot - contenente i file json utilizzati dal programma per leggere e salvare i brani




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

## TEST E DEBUGGING

- [ ] Controllo inserimento (lettere, numeri, spazio vuoto, numeri negativi, numeri enormi)
- [ ] Controllo inserimento dati rindondanti all'interno di una tabella
