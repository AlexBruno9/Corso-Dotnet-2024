CREATE TABLE artisti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE generi (id INTEGER PRIMARY KEY AUTOINCREMENT, genere TEXT UNIQUE);
CREATE TABLE album (id INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT UNIQUE, anno INTEGER, quantita INTEGER CHECK (quantita >= 0), id_artista INTEGER, id_genere INTEGER, FOREIGN KEY (id_artista) REFERENCES artisti(id), FOREIGN KEY (id_genere) REFERENCES generi(id));


INSERT INTO artisti (nome) VALUES ('Neffa');
INSERT INTO artisti (nome) VALUES ('Bob Dylan');

INSERT INTO generi (genere) VALUES ('Rap');
INSERT INTO generi (genere) VALUES ('Rock');


INSERT INTO album (titolo, anno, quantita, id_artista, id_genere) VALUES ('primo_Neffa', 1994, 4, 1, 1);
INSERT INTO album (titolo, anno, quantita, id_artista, id_genere) VALUES ('secondo_Neffa', 1996, 2, 1, 1);
INSERT INTO album (titolo, anno, quantita, id_artista, id_genere) VALUES ('primo_Bob_Dylan', 1962, 8, 2, 2);

SELECT * FROM artisti;
SELECT * FROM generi;
SELECT * FROM album;


SELECT album.id, album.titolo, album.anno, album.quantita, artisti.nome AS artista, generi.genere AS genere FROM album JOIN artisti ON album.id_artista = artisti.id JOIN generi ON album.id_genere = generi.id; 

