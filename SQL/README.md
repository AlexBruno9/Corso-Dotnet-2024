<details>
<summary>01 - CREAZIONE DATABASE SQL </summary>

```
sqlite3
.open database.db 
CREATE TABLE prodotti (nome TEXT);
INSERT INTO prodotti VALUES ('prodotto1');
SELECT * FROM prodotti;


//esempio
CREATE TABLE prodotti (nome TEXT, prezzo REAL, quantita INTEGER);
INSERT INTO prodotti VALUES ('p1', 1, 10);
INSERT INTO prodotti VALUES ('p2', 2, 20);
INSERT INTO prodotti VALUES ('p3', 3, 30);



// altri comandi


JOIN
//SELECT * FROM album JOIN artisti ON album.id_artista = artisti.id JOIN generi ON album.id_genere = generi.id ORDER BY anno;
//seleziona tutti i dati dalla tabella prodotti concatenando con tabelle Artisti e Generi


UPDATE
//UPDATE users SET name=('{newname}') WHERE name=('{name}')

DELETE
//DELETE FROM album WHERE (id_artista=1);

ORDER BY
//ORDER anno ASC; (oppure DESC)


.mode table     per visualizzare la tabella
.header on/off  per vedere anche nome tabella 
.exit
//

```

</details>