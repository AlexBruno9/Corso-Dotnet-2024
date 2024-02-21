CREATE TABLE artisti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);

INSERT INTO artisti (nome) VALUES ('Neffa');
INSERT INTO artisti (nome) VALUES ('Bob Dylan');

CREATE TABLE album (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_artista INTEGER, FOREIGN KEY (id_artista) REFERENCES artisti(id));

INSERT INTO album (nome, prezzo, quantita, id_artista) VALUES ('primo_Neffa', 10, 4, 1);
INSERT INTO album (nome, prezzo, quantita, id_artista) VALUES ('secondo_Neffa', 12, 2, 1);
INSERT INTO album (nome, prezzo, quantita, id_artista) VALUES ('primo_Bob_Dylan', 20, 8, 2);

SELECT * FROM artisti
SELECT * FROM album
SELECT * FROM album JOIN artisti ON album.id_artista = artisti.id; 