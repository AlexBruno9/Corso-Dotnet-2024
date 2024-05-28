# PROVA DOCUMENTAZIONE PER ESAME

### fare una documentazione per un sito di prodotti come vestiti/scarpe

## Definizione dei Requisiti e Analisi:

Obiettivi dell'applicazione:

- [ ] Consentire ai clienti di acquistare prodotti online.
- [ ] Mostrare agli utenti il proprio catalogo.
- [ ] Proporre offerte per incentivare la vendita.

Determinazione delle funzionalità chiave:

- [ ] Permettere all'utente di aggiungere prodotti al carrello per poi completare l'aquisto.
- [ ] Guidare l'utente su prodotti che rispecchino le proprie preferenze e misure.

Analizza il pubblico target e le esigenze degli utenti:

- [ ] il pubblico target sono tutte le persone maggiorenni con un dispositivo in grado di accedere ad internet, bisognose di vestiti.
- [ ] l'utente deve avere facilità nel trovare la sezione di vestiti adatta al suo sesso e alle sue misure;
- [ ] inoltre l'app deve essere in grado di suggerire all'utente prodotti che potrebbero essere di suo gradimento in base ai precedenti acquisti o agli articoli visualizzati.

## Pianificazione e Design dell'Architettura:

Scegli un'architettura adatta (ad es., MVC, MVP, MVVM):

- [ ] l'app sarà strutturata secondo l'architettura del modello di progettazione Razor
  - [ ] il file conterrà quindi una cartella Pages contenente una coppia di file per ogni pagina visualizzata nell'app, una .cshtml e una .cshtml.cs
  - [ ] una cartella Models che conterra la struttura degli oggetti (i prodotti) che verranno utilizzati nelle Pages
  - [ ] una cartella wwwroot contenente json, css ed altri tipi di file

Definisci i modelli di dati e le relazioni tra di essi.

- [ ] il modello di dati che verrà usato è una classe Brano contenente i dati (id, nomeProdotto, dimensioni, peso, prezzo, quantità)

Progetta l'interfaccia utente e l'esperienza utente (UI/UX):

- l'interfaccia utente vedrà una navbar presente in ogni pagina della webApp che consentirà all'utente di spostarsi facilmente da una sezione a un altra

- per quanto riguarda la User Interface Design (UI) gli elementi principali saranno:

  - [ ] Layout: ci sarà una navbar presente in ogni pagina della webApp che consentirà all'utente di spostarsi facilmente da una sezione ad un'altra; i prodotti verranno visualizzati in un container secondo un grid che mostrerà 3 prodotti per riga.
  - [ ] Tipografia: il carattere usato per tutte le pagine sarà Monserrat, dimensione 10 per i testi normali, 14 per i nomi dei prodotti.
  - [ ] Colori: il sito sarà in prevalenza blu e bianco, con delle piccole parentesi di nero e/o grigio
  - [ ] Icone: in alto a sinistra, in ogni pagina, sarà sempre visibile il logo dell'azienda. Inoltre ogni azione che puo fare il cliente con un prodotto (aggiungi al carrello / aquista / scarta dal carrello / leggi info) sarà accompagnata da un'icona descrittiva dell'azione.
  - [ ] Pulsanti: ogni azione che puo fare il cliente con un prodotto (aggiungi al carrello / aquista / scarta dal carrello / leggi info) sarà eseguita effettuando un click sul pulsante relativo all'azione da svolgere.

- per quanto riguarda la User Experience Design (UX) gli elementi principali saranno:

  - [ ] Ricerca Utenti: gli utenti più giovani cercheranno prodotti che seguono la moda, mentre quelli più anziani vestiranno in modo diverso, indipendentemente dal sesso; il sito dovràpoter accontentare entrambe le categorie, magari dando più scelta di prodotto ai giovani che probabilmente faranno ricerche piu mirate e approfondite.
  - [ ] Architettura dell'Informazione: Ogni sezione conterrà sottosezioni di prodotti simili. Esempio la pagina "scarpe per donna" conterrà la pagina "calzature estive" che conterrà la pagina "sandali" che conterrà le pagine dei vari modelli di sandali.
  - [ ] Test di Usabilità: a webApp completats, verrà effettuata una valutazione dell'efficacia e della facilità d'uso del prodotto.

## Definizione di Strutture e Convenzioni:

Stabilisci convenzioni di codifica e nomi standard:

- [ ] codifica: UTF-8
      Organizza la soluzione in progetti e namespace:
- [ ] il proggetto si chiamerà WebAppProdotti
      Definisci le classi, le interfacce e i metodi chiave:
- [ ] verrà utilizzata una classe principale chiamata Prodotto; metodi chiave saranno VisualizzaProdotto(), AcquistaProdotto(), AggiungiAlCarrello(), RimuoviDaCarrello(), PagaCarrello().

## Sviluppo dei Componenti:

Crea le viste e i view model/controller per la presentazione.

- [ ] ogni pagina avrà una view (.cshtml) e un controller (.cshtml.cs) e si rifaranno ad un unico model razor che sarà Prodotto.cs
- [ ] aggiungere qui logica di controllo e l'integrazione tra i componenti.

## Test e Debugging:

- [ ] Scrivi test unitari e test di integrazione.
- [x] Esegui il debugging per individuare e risolvere i bug.

## Documentazione:

- [x] Documenta il codice e l'architettura.
- [ ] Prepara manuali per gli sviluppatori e gli utenti.
