

## Definizione di funzionalità e obiettivi

-  [x]  il programma deve prendere in inserimento dei dischi e li va a catalogare
-  [x]  al lancio del programma verrà creata una cartella Catalogo
-  [x]  per ogni artista di cui viene inserito un disco, verrà creata una cartella all'interno della cartella Catalogo:  
    -  ogni cartella di un artista conterrà un file json per ogni suo album registrato nel catalogo  
    -  ogni file json conterrà il nome dell'album, l'anno di pubblicazione e le copie disponibili in negozio
-  [x]  se viene inserito un album di un artista di cui non è ancora presente una cartella all'interno del Catalogo, verrà creata;  
-  [x]  se viene inserito un album già presente in catalogo, verrà aggiornata la quantità di copie disponibili  
-  [x]  possibilità di rimuovere album dal catalogo (in caso vengano venduti)
-  [x]  possibilità di stampare elenco album di un determinato artista presenti in catalogo  
    


## Interfaccia utente

-  [x]  l'utente opererà sul catalogo dischi attraverso un menu che permette di aggiungere, eliminare o cercare dischi
-  [x]  richiesta all'utente di inserire il nome dell'artista di cui si vuole inserire un disco in catalogo
-  [x]  richiesta di inserire il titolo dell'album e l'anno di pubblicazione
-  [x]  possibilità di continuare ad inserire album dello stesso artista 
-  [x]  richiesta di passare al catalogo di un altro artista di cui inserire album, o chiudere il programma

-  [x] in caso di ricerca verranno mostrato l'elenco degli album con anno di pubblicazione, e a destra la disponibilità

-  [x]  verranno creati visualizzati più documenti:  
    -  una cartella Catalogo  
    -  una cartella per ogni artista, dentro Catalogo
    -  un file json per ogni album, dentro cartella artista


## Definizione di Strutture e Convenzioni:

- [x] definizione di un menu con 4 scelte (aggiungi, cerca, elimina, chiudi) 

- [x] implementare 2 cicli while: uno per continuare l'inserimento di album, uno per l'inserimento di nuovi artisti
- [x] controllo esistenza di una cartella o di un file:    
    - controllo sulle cartelle artisti per sapere se crarla o aggiornarla quando si inserisce un artista
    - controllo sui file json per sapere se crearlo o aggiornarlo quando si inserisce un album
- [x] implementare una funzione per la stampa ordinata nella ricerca dischi per artista
- [x] controllo legalità sui campi da inserire in input

