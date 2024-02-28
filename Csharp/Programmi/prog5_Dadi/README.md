# RISIKO
*PROGRAMMA CHE CONOSCENDO IL NUMERO ARMATE DI 2 TERRITORI, CALCOLA L'ATTACCO E I RISULTATI*

## Regole

1. si attacca con un massimo di 3 dadi
2. l avversario difende con un massimo di 3 dadi, se ha meno di 3 carri difende con quel numero di dadi
3. puoi tirare un massimo di dadi pari al tuo numero di carri


4. si confrontano i dadi a 2 a 2, dal maggiore al minore
5. in caso di pareggio vince la difesa

- es. giocatore 1 (6, 4, 3)
      giocatore 2 (5, 3, 3)

     risultato = il giocatore attaccante perde 1 carro e ne abbatte 2 al difensore, perche:
    - tra 6 e 5 vince 6, l'attaccante
    - tra 4 e 3 vince 4, l'attaccante
    - tra 3 e 3 vince chi difende;

6. dopo un attacco, il giocatore attaccante può continure ad attaccare, finche ha carriarmati
7. 1 carroarmato deve sempre rimanere sul territorio attaccante, quindi se hai 4 carri puoi attaccare al max con 3, altrimenti in caso di sconfitta rimarresti senza
8. quando abbatti tutti i carri nemici, conquisti il territorio


## Definizione dei funzionalità, obiettivi e requisiti del gioco:

-  [x]  creazione e lettura file di tipo .txt Punteggio
-  [x]  simulare il tiro dei dadi
-  [x]  tenere conto delle armate in attacco e di quelle in difesa
-  [x]  conservare i totali delle armate presenti nei due territori       
-  [x]  aggiornare ad ogni tiro i numeri delle armate rimanenti
-  [x]  colorare il numero delle armate rimanenti: verdi chi è in vantaggio, rosso chi perde, giallo in caso di pareggio
-  [x]  creazione e conseguente aggiornamento di un file di tipo .csv contenente i numeri attuali delle armate
-  [x]  possibilità di continuare gli attacchi dopo il primo, finchè possibile
-  [ ]  aggiungere controllo sulle eccezioni !!!

-  [x]  NB questo programma può servire da test per il calcolo della probabilità di vittoria nei vari casi


## Interfaccia utente

-  [x]  l'interfaccia deve essere comprensibile e chiara, anche abbastanza basica (console clear per pulire lo schermo)
-  [x]  richiesta all'utente di inserire i numeri di armate presenti nei due territori (verranno inseriti in Punteggio.txt)
-  [x]  visualizzazione dei dati presi dal file di testo Punteggio.txt
-  [x]  richiesta di quanti dadi vuole usare l'attaccante
-  [x]  stampa l'esito dell'attacco
-  [x]  stampa quanti carri rimangono nei due territori colorando il numero in base al file csv Punteggio.csv
-  [x]  richiesta se dopo un attacco si vuole continuare o fermarsi
-  [x]  stampa quando vinci o quando non hai abbastanza carri per continare l'attacco
-  [x]  richiesta di cominciare un nuovo attacco
    

## Definizione di Strutture e Convenzioni:
-  [x]  ciclo while per ricominciare la partita una volta conclusa
-  [x]  file .txt contenente i numeri di armate inizializzati in input
-  [x]  inizializzazione dati sui carri presenti nei due territori prendendoli da un file .txt
-  [x]  secondo while che cicla ogni volta che si prosegue un attacco
-  [x]  bisogno di tenere i dati su quantità dei dadi da tirare(carri_attacco, carri_difesa)
-  [x]  bool continua per decidere se proseguire o chiudere il ciclo while
-  [x]  generazione dei tiri di dado casuale (random)
-  [x]  dichiarazione di due array per memorizzare i due lanci 
-  [x]  chiamata funzione *Sort* per ordinare i due lanci per poterli confrontare
-  [x]  ciclo di if per il confronto dei due tiri (array)
-  [x]  file .csv contenente il numero attuale dei carri sui due fronti
-  [ ]  try / catch per la gestione delle eccezioni
