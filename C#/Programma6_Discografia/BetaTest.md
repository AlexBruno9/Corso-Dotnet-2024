# BETA TEST - APP CATALOGO DISCHI

## OBIETTIVI

- testare l'app in modo da segnalare eventuali bug
- provare tutte le eccezioni possibili, inserendo stringhe invece che numeri, numeri troppo grossi ecc.
- assicurarsi sulla chiarezza del codice
- ricevere suggerimenti/feedback da parte di altri utenti



## POST BETA TEST


### 1. Raccolta feedback da parte di Fabio


>NOTE:  
- Il codice è molto chiaro, non ha bisogno di grossi miglioramenti nè contiene bug o errori. A parte qualche piccola cosa risolvibile in poco tempo direi che è perfetto


>BUG O ERRORI:  
- Se inserisco due volte lo stesso album genera errore
- Non chiaro che risposta dare quando viene chiesto se continuare (aggiungere 's o n')


>MIGLIORAMENTI:  
- Quando dice 'premi invio per continuare' va anche se si preme un qualunque altro tasto
- Possibilità di eliminare i dischi o gli album dal catalogo




## Priorità
1. Inserimento disco già presente
2. Stampare le risposte accettate alla domanda 'continuare?'  -->'(s/n)'
3. Elimina disco
4. modificare scritta "premi invio per continuare"



### 2. Raccolta feedback da parte di Cristian

- [x] delle 4 librerie implementate l'unica necessaria è Newsoft.Json - le altre posso commentarle
- [x] è consigliabile formattare il programma una volta finito, in modo da renderlo più ordinato e leggibile
- [x] separare in due diverse domande la richiesta di inserimento del titolo dell'album e dell'anno di publicazione  
  -  altrimenti non risulta chiaro il modo in cui le due voci vanno inserite
- [x] rimettere il cursore a fine programma, altrimenti il terminale dell'utilizzatore rimane senza
  -  provare ad implementarlo con un try-catch-finally