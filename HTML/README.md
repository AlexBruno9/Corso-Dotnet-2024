# HTML

HTML è un linguaggio di markup per la strutturazione delle pagine web.

## Struttura di un documento HTML

Un documento HTML è composto da due parti principali: il doctype e il body.
Il doctype è la dichiarazione che indica al browser che il documento è scritto in HTML. Il doctype di HTML è `<!DOCTYPE html>`.
Il body è la parte del documento che contiene il contenuto della pagina web.

## Tag HTML

I tag HTML sono i seguenti:

- `<html>`: indica l'inizio e la fine del documento HTML
- `<head>`: contiene le informazioni sul documento HTML
- `<title>`: contiene il titolo del documento HTML
- `<body>`: contiene il contenuto del documento HTML
- `<h1>`, `<h2>`, `<h3>`, `<h4>`, `<h5>`, `<h6>`: contengono i titoli di primo, secondo, terzo, quarto, quinto e sesto livello
- `<p>`: contiene un paragrafo
- `<br>`: va a capo
- `<hr>`: inserisce una linea orizzontale
- `<a>`: contiene un link
- `<img>`: contiene un'immagine
- `<ul>`: contiene una lista non ordinata
- `<ol>`: contiene una lista ordinata
- `<li>`: contiene un elemento di una lista
- `<div>`: contiene un blocco di contenuto

Alcuni tag necessitano di chiusura esplicita, altri no. Spesso la chiusura è implicita, cioè il tag di chiusura è inserito automaticamente dal browser.

## Attributi HTML

Gli attributi HTML sono i seguenti:

- `id`: identifica un elemento
- `class`: identifica un gruppo di elementi
- `style`: contiene le regole CSS per formattare un elemento
- `href`: contiene l'indirizzo di un link
- `src`: contiene l'indirizzo di un'immagine
- `alt`: contiene il testo alternativo di un'immagine
- `title`: contiene il testo che appare quando si passa il mouse sopra un elemento
- `width`: contiene la larghezza di un elemento
- `height`: contiene l'altezza di un elemento
- `target`: contiene il nome della finestra in cui aprire il link

## Formattazione del testo

Per formattare il testo si possono usare i seguenti tag:

- `<b>`: testo in grassetto
- `<strong>`: testo in grassetto
- `<i>`: testo in corsivo
- `<em>`: testo in corsivo
- `<mark>`: testo evidenziato
- `<small>`: testo piccolo
- `<del>`: testo barrato
- `<ins>`: testo sottolineato
- `<sub>`: testo in pedice
- `<sup>`: testo in apice

## Formattazione del testo con CSS

Per formattare il testo con CSS si possono usare le seguenti proprietà:

- `color`: colore del testo es: `color: red;`
- `font-family`: tipo di carattere es: `font-family: Arial;`
- `font-size`: dimensione del testo es: `font-size: 12px;`
- `font-weight`: spessore del testo es: `font-weight: bold;`
- `font-style`: stile del testo es: `font-style: italic;`
- `text-decoration`: decorazione del testo es: `text-decoration: underline;`
- `text-align`: allineamento del testo es: `text-align: center;`
- `text-indent`: rientro del testo es: `text-indent: 20px;`
- `text-transform`: trasformazione del testo cioè se deve essere tutto maiuscolo, tutto minuscolo o solo la prima lettera maiuscola es: `text-transform: uppercase;`
- `line-height`: altezza della linea di testo es: `line-height: 1.5;`
- `letter-spacing`: spaziatura delle lettere es: `letter-spacing: 2px;`
- `word-spacing`: spaziatura delle parole es: `word-spacing: 5px;`

## Liste

Per creare una lista non ordinata si usa il tag `<ul>` e per creare una lista ordinata si usa il tag `<ol>`. Per creare un elemento di una lista si usa il tag `<li>`.

## Link

Per creare un link si usa il tag `<a>`. L'attributo `href` contiene l'indirizzo del link e l'attributo `target` contiene il nome della finestra in cui aprire il link.

## Immagini

Per inserire un'immagine si usa il tag `<img>`. L'attributo `src` contiene l'indirizzo dell'immagine, l'attributo `alt` contiene il testo alternativo dell'immagine, l'attributo `width` contiene la larghezza dell'immagine e l'attributo `height` contiene l'altezza dell'immagine.

## Div

Per creare un blocco di contenuto si usa il tag `<div>`.

## Tabelle

Per creare una tabella si usa il tag `<table>`. Per creare una riga si usa il tag `<tr>`. Per creare una cella di intestazione si usa il tag `<th>` e per creare una cella si usa il tag `<td>`.

## Form

Per creare un form si usa il tag `<form>`. L'attributo `action` contiene l'indirizzo a cui inviare i dati del form e l'attributo `method` contiene il metodo HTTP da usare per inviare i dati del form.

## Input

Per creare un input si usa il tag `<input>`. L'attributo `type` contiene il tipo di input e l'attributo `name` contiene il nome dell'input.

## Tipi di input

I tipi di input sono i seguenti:

- `text`: input di testo es: `<input type="text" name="nome">`
- `password`: input di testo con i caratteri nascosti es: `<input type="password" name="password">`
- `email`: input di testo per l'email es: `<input type="email" name="email">`
- `number`: input di testo per i numeri es: `<input type="number" name="numero">`
- `date`: input di testo per la data es: `<input type="date" name="data">`
- `time`: input di testo per ora es: `<input type="time" name="ora">`
- `checkbox`: checkbox es: `<input type="checkbox" name="checkbox">`
- `radio`: radio button es: `<input type="radio" name="radio">`
- `file`: file es: `<input type="file" name="file">`
- `submit`: bottone di invio es: `<input type="submit" name="invia">`
- `reset`: bottone di reset es: `<input type="reset" name="reset">`
- `button`: bottone es: `<input type="button" name="bottone">

## Textarea

Per creare un textarea si usa il tag `<textarea>`. L'attributo `name` contiene il nome del textarea. es: `<textarea name="testo"></textarea>`

## Select

Per creare una select si usa il tag `<select>`. Per creare un'opzione si usa il tag `<option>`. L'attributo `name` contiene il nome della select. es: `<select name="opzione"><option value="1">Opzione 1</option><option value="2">Opzione 2</option></select>`

# Esercizi

## Creazione di una landing page con sezioni ed ancoraggi.

```Html
<!DOCTYPE html>
<html>
<head>
    <title>Landing Page</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <header>
        <h1>Header</h1>
    </header>

    <nav>
        <a href="#section1">Sezione 1</a>
        <a href="#section2">Sezione 2</a>
        <a href="#section3">Sezione 3</a>
    </nav>

    <section id="section1">
        <h2>Sezione 1</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunccursus
            eros, a tincidunt mauris neque eget urna. Nullam euismod, nisl eget aliquam ultricies, nunc
            cursus eros, a tincidunt mauris neque eget urna.</p>
    </section>

    <section id="section2">
        <h2>Sezione 2</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunccursus
            eros, a tincidunt mauris neque eget urna. Nullam euismod, nisl eget aliquam ultricies, nunc
            cursus eros, a tincidunt mauris neque eget urna.</p>
    </section>

    <section id="section3">
        <h2>Sezione 3</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunccursus
            eros, a tincidunt mauris neque eget urna. Nullam euismod, nisl eget aliquam ultricies, nunc
            cursus eros, a tincidunt mauris neque eget urna.</p>
    </section>

    <footer>
        <h3>Footer</h3>
    </footer>
</body>
</html>
```

style.css

```Css
body {
    margin: 0;
    padding: 0;
    font-family: Arial;
}

header {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}

nav {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}

nav a {
    color: #fff;
    text-decoration: none;
    padding: 20px;
}

nav a:hover {
    background-color: #555;
}

section {
    padding: 20px;
}

footer {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}
```

## Aggiunta placeholders per immagini

```Html
<img src="https://via.placeholder.com/300x200" alt="Immagine 1">
oppure immagini random:
<img src="https://source.unsplash.com/random/300x200" alt="Immagine 1">
dimensioni:
<img src="https://source.unsplash.com/random/300x200?sig=1&nature" alt="Immagine 1">
```

Aggiunta css per centrare le immagini

```Css
img {
    display: block;
    margin: 0 auto;
}
```

## Aggiunta attributi per la gestione dei paragrafi e dei titoli

```Css
p {
    text-align: justify;
    text-indent: 20px;
    line-height: 1.5;
}

h1 {
    text-align: center;
}
```

## Aggiunta attributi per la gestione delle liste

```Css
ul {
    list-style-type: none;
    padding: 0;
}

ul li {
    padding: 10px;
}

ol {
    list-style-type: decimal;
    padding: 0;
}

ol li {
    padding: 10px;
}
```

```Html
<ul>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
    <li>Elemento 3</li>
</ul>

<ol>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
    <li>Elemento 3</li>
</ol>
```

## Aggiunta attributi per la gestione dei link

```Css
a {
    text-decoration: none;
    color: blue;
}

a:hover {
    text-decoration: underline;
}
```

```Html
<a href="#">Link</a>
```

## Aggiunta attributi per la gestione delle tabelle

```Css
table {
    border-collapse: collapse;
    width: 100%;
}

th, td {
    border: 1px solid #000;
    padding: 10px;
    text-align: center;
}
```

```Html
<table>
    <tr>
        <th>Intestazione 1</th>
        <th>Intestazione 2</th>
    </tr>
    <tr>
        <td>Cella 1</td>
        <td>Cella 2</td>
    </tr>
</table>
```

th = table header
td = table data

## Aggiunta attributi per la gestione dei form

```Css
form {
    text-align: center;
}

input, textarea, select {
    padding: 10px;
    margin: 10px;
    width: 300px;
    display: block;
}
```

```Html
<form action="#" method="post">
    <input type="text" name="nome" placeholder="Nome">
    <input type="email" name="email" placeholder="Email">
    <textarea name="testo" placeholder="Testo"></textarea>
    <select name="opzione">
        <option value="1">Opzione 1</option>
        <option value="2">Opzione 2</option>
    </select>
    <input type="submit" name="invia" value="Invia">
</form>
```

## Aggiunta attributi per la gestione dei pulsanti

```Css
button {
    padding: 10px;
    margin: 10px;
    display: block;
}
```

```Html
<button type="menu">Bottone</button>
```

## Aggiunta elementi divisori

```Css
hr {
    border-color: #333;
}
```

```Html
<hr>
```

## Aggiunta attributi per la gestione dei div

```Css
div {
    padding: 20px;
    margin: 20px;
    border: 1px solid #000;
}
```

```Html
<div>
    <p>Testo</p>
</div>
```

## Aggiunta CSS personalizzati

```css
.colorea {
  background-color: chartreuse;
}

.coloreb {
  background-color: hotpink;
}
```

```html
<div>
  <div class="colorea">
    <p>Testo</p>
  </div>
</div>
<div>
  <div class="coloreb">
    <p>Testo</p>
  </div>
</div>
```

# IMPLEMENTAZIONI GRAFICHE E FUNZIONALI

## Layout responsivo

Il Layout responsivo è un layout che si adatta automaticamente alle dimensioni del dispositivo su cui viene visualizzato.
Quando la finestra del browser è più piccola di 768px, il layout cambia e si adatta alle dimensioni del dispositivo.
Si chiama media query.

```Css
@media (max-width: 768px) {
    header {
        background-color: #555;
    }

    nav {
        background-color: #555;
    }

    section {
        padding: 10px;
    }

    footer {
        background-color: #555;
    }
}
```

## Grid layout

Il Grid layout è un layout basato su una griglia.
In questo caso il layout è diviso in due colonne di larghezza uguale utilizzando la proprietà grid-template-columns ed è separato da uno spazio di 20px utilizzando la proprietà grid-gap.
1 fr = 1 parte della griglia cioè 1/2

```Css
section {
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-gap: 20px;
}
```

Se vogliamo dividere la griglia in tre colonne di larghezza uguale possiamo usare la seguente proprietà:

```Css
section {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-gap: 20px;
}
```

Se vogliamo che le parti della griglia siano di larghezza diversa possiamo usare la seguente proprietà:

```Css
section {
    display: grid;
    grid-template-columns: 1fr 2fr 1fr;
    grid-gap: 20px;
}
```

## Flexbox layout

Il Flexbox layout è un layout basato su un contenitore e su elementi flessibili.
In questo caso il layout è diviso in due colonne di larghezza uguale utilizzando la proprietà flex e è separato da uno spazio di 20px utilizzando la proprietà margin.

```Css
section {
    display: flex;
}

section div {
    flex: 1;
    margin: 20px;
}
```

Flex è una proprietà che indica la flessibilità di un elemento cioè quanto può espandersi o restringersi. ed 1 indica che l'elemento può espandersi o restringersi in base allo spazio disponibile.
Se invece vogliamo che un elemento sia più flessibile di un altro possiamo usare la seguente proprietà:

```Css
section div {
    flex: 2;
    margin: 20px;
}
```

Flex 2 indica che l'elemento può espandersi o restringersi il doppio rispetto agli altri elementi.

> è possibile provare i tipi di flexbox tramite un gioco qui:

> http://www.flexboxfroggy.com

## Font Google

Il Font Google è un font che viene scaricato da Google e utilizzato nel sito web.

```Html
<link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" >
```

```Css
body {
    font-family: 'Roboto', sans-serif;
}
```

## Icone Font Awesome

L'Icona Font Awesome è un'icona che viene scaricata da Font Awesome e utilizzata nel sito web.

```Html
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" >
```

```Html
<i class="fas fa-home"></i>
```

Si possono formattare le icone di Font Awesome in vari modi:

```Css
i {
    color: red;
    font-size: 24px;
}
```

Oppure si possono usare attributi in linea:

```Html
<i class="fas fa-home" style="color: red; font-size: 24px;"></i>
```

> in questo modo possiamo avere le icone di un colore specifico tramite css esterno ed una icona di un colore diverso attraverso i css in linea
> Gli attributi specifici di Font Awesome sono i seguenti:

- `fas`: icona solida
- `far`: icona regolare
- `fal`: icona leggera
- `fab`: icona brand
- `fa-2x`: doppia grandezza
- `fa-3x`: tripla grandezza
- `fa-4x`: quadrupla grandezza
- `fa-5x`: quintupla grandezza
- `fa-fw`: larghezza fissa
- `fa-ul`: lista non ordinata
- `fa-li`: elemento di una lista non ordinata
- `fa-border`: bordo
- `fa-pull-left`: allineamento a sinistra
- `fa-pull-right`: allineamento a destra
- `fa-spin`: rotazione
- `fa-pulse`: pulsazione
- `fa-rotate-90`: rotazione di 90 gradi
- `fa-rotate-180`: rotazione di 180 gradi
- `fa-rotate-270`: rotazione di 270 gradi
- `fa-flip-horizontal`: ribaltamento orizzontale
- `fa-flip-vertical`: ribaltamento verticale
- `fa-stack`: pila
- `fa-stack-1x`: grandezza della pila
- `fa-stack-2x`: grandezza della pila
- `fa-inverse`: colore invertito
- `fa-layers`: livelli
- `fa-layers-text`: testo del livello
- `fa-layers-counter`: contatore del livello
- `fa-layers-bottom`: fondo del livello

## AGGIUNTA DI ANIMAZIONI CSS

È possibile aggiungere animazioni CSS a un sito web utilizzando la proprietà transform.

```Css
div {
    transition: transform 0.5s;
}

div:hover {
    transform: scale(1.1);
}
```

```Css
nav ul li a:before{
    content: "";
    position: absolute;
    bottom: -5px;
    height: 2px;
    width: 100%;
    background: white;
    border-radius: 50px;
    transition: transform 0.2s linear;
    transform: scaleX(0);
}

nav ul li a:hover:before{
    transform: scaleX(1);
}
```

È possibile aggiungere animazioni CSS a un sito web utilizzando la proprietà animation.

```Css
@keyframes esempio {
    0% {
        background-color: red;
    }
    50% {
        background-color: yellow;
    }
    100% {
        background-color: green;
    }
}

div {
    animation: esempio 2s infinite;
}
```

# IMPLEMENTAZIONI

## Carosello

Il Carosello è un insieme di immagini che scorrono automaticamente.

```Html
<script src="script.js"></script>
<div id="carosello">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 1">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 2">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 3">
</div>
```

```Css
#carosello {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-gap: 20px;
    overflow: hidden;
}

#carosello img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
```

```Javascript
let carosello = document.getElementById('carosello'); // prende l'elemento con id carosello
let immagini = carosello.getElementsByTagName('img'); // prende tutte le immagini all'interno di carosello
let indice = 0; // indice dell'immagine attuale

function avanti() {
    indice++; // incrementa l'indice

    if (indice >= immagini.length) {
        indice = 0; // se l'indice è maggiore o uguale al numero di immagini, l'indice diventa 0
    }

    carosello.style.transform = 'translateX(' + (-indice * 100) + '%)'; // trasla carosello
}

function indietro() {
    indice--; // decrementa l'indice

    if (indice < 0) {
        indice = immagini.length - 1; // se l'indice è minore di 0, l'indice diventa il numero di immagini - 1
    }

    carosello.style.transform = 'translateX(' + (-indice * 100) + '%)'; // trasla carosello
}

setInterval(avanti, 3000); // chiama la funzione avanti ogni 3000 millisecondi
```

## Menu a tendina

Il Menu a tendina è un menu che si apre e si chiude cliccando su un pulsante.

```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```

```Css
#menu {
    display: none;
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
    background-color: #fff;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```

```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}
```

## Lightbox

Il Lightbox è un'immagine che si apre in una finestra modale.

```Html
<div id="lightbox">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 1" onclick="apriLightbox(this)">
</div>
<div id="finestra">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 1">
    <button onclick="chiudiLightbox()">Chiudi</button>
</div>
```

```Css
#lightbox img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
#finestra {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    text-align: center;
}
#finestra img {
    width: 80%;
    height: 80%;
    object-fit: cover;
    margin: 10% auto;
}
#finestra button {
    padding: 10px;
    margin: 10px;
}
```

```Javascript
function apriLightbox(elemento) {
    let finestra = document.getElementById('finestra'); // prende l'elemento con id finestra
    let immagine = finestra.getElementsByTagName('img')[0]; // prende l'immagine all'interno di finestra
    immagine.src = elemento.src; // imposta la sorgente dell'immagine
    finestra.style.display = 'block'; // mostra finestra
}

function chiudiLightbox() {
    let finestra = document.getElementById('finestra'); // prende l'elemento con id finestra
    finestra.style.display = 'none'; // nasconde finestra
}
```

## Modale

La Modale è una finestra modale che si apre e si chiude cliccando su un pulsante.

```Html
<button onclick="apriModale()">Apri</button>
<div id="modale">
    <div id="contenuto">
        <h2>Titolo</h2>
        <p>Testo</p>
        <button onclick="chiudiModale()">Chiudi</button>
    </div>
</div>
```

```Css
#modale {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    text-align: center;
}

#contenuto {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: #fff;
    padding: 20px;
}
```

```Javascript
function apriModale() {
    let modale = document.getElementById('modale'); // prende l'elemento con id modale
    modale.style.display = 'block'; // mostra modale
}

function chiudiModale() {
    let modale = document.getElementById('modale'); // prende l'elemento con id modale
    modale.style.display = 'none'; // nasconde modale
}
```

## Tooltip

Il Tooltip è un testo che appare quando si passa il mouse sopra un elemento.

```Html
<div id="tooltip" onmouseover="mostraTooltip()" onmouseout="nascondiTooltip()">Testo</div>
<div id="finestra-tooltip">Tooltip</div>
```

```Css
#finestra-tooltip {
    display: none;
    position: absolute;
    top: 0;
    left: 0;
    background-color: #000;
    color: #fff;
    padding: 10px;
}
```

```Javascript
function mostraTooltip() {
    let finestra = document.getElementById('finestra-tooltip'); // prende l'elemento con id finestra-tooltip
    finestra.style.display = 'block'; // mostra finestra
}

function nascondiTooltip() {
    let finestra = document.getElementById('finestra-tooltip'); // prende l'elemento con id finestra-tooltip
    finestra.style.display = 'none'; // nasconde finestra
}
```

## Scroll to top

Lo Scroll to top è un pulsante che appare quando si scorre la pagina verso il basso e scompare quando si scorre la pagina verso l'alto.

```Html
<button onclick="scrollToTop()">Top</button>
```

```Css
button {
    display: none;
    position: fixed;
    bottom: 20px;
    right: 20px;
    padding: 10px;
}
```

```Javascript
window.onscroll = function() {scrollFunction()};
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementsByTagName('button')[0].style.display = 'block';
    } else {
        document.getElementsByTagName('button')[0].style.display = 'none';
    }
}

function scrollToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
```

## Menu a scomparsa

Il Menu a scomparsa è un menu che si apre e si chiude cliccando su un pulsante.

```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```

```Css
#menu {
    display: none;
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
    background-color: #fff;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```

```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}
```

## Menu a scomparsa con animazione

Il Menu a scomparsa con animazione è un menu che si apre e si chiude cliccando su un pulsante con un'animazione.

```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```

```Css
#menu {
    display: none;
    position: absolute;
    top: 50px;
    right: 0;
    background-color: #fff;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    animation: apri 0.5s;
}

@keyframes apri {
    from {
        transform: translateX(100%);
    }
    to {
        transform: translateX(0);
    }
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```

```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}
```

## Menu a scomparsa con animazione e chiusura

Il Menu a scomparsa con animazione e chiusura è un menu che si apre e si chiude cliccando su un pulsante con un'animazione e si chiude cliccando su un pulsante.

```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <button onclick="chiudiMenu()">Chiudi</button>
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```

```Css
#menu {
    display: none;
    position: absolute;
    top: 50px;
    right: 0;
    background-color: #fff;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    animation: apri 0.5s;
}

@keyframes apri {
    from {
        transform: translateX(100%);
    }
    to {
        transform: translateX(0);
    }
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```

```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}

function chiudiMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu
    menu.style.display = 'none'; // nasconde il menu
}
```

# HTML5 ELEMENTS

## Esempio di utilizzo di HTML5 Canvas

Supponiamo di voler disegnare un cerchio sul canvas. Per disegnare un cerchio sul canvas si usa il metodo `arc()` che disegna un cerchio. es: `ctx.arc(250, 250, 100, 0, 2 * Math.PI);`

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 Canvas</title>
</head>
<body>
    <canvas id="canvas" width="500" height="500"></canvas>
    <script>
        var canvas = document.getElementById("canvas");
        var ctx = canvas.getContext("2d");
        ctx.beginPath();
        ctx.arc(250, 250, 100, 0, 2 * Math.PI);
        ctx.stroke();
    </script>
</body>
</html>
```

## Esempio di utilizzo di HTML5 SVG

Supponiamo di voler disegnare un cerchio sul canvas. Per disegnare un cerchio sul canvas si usa il metodo `createElementNS()` che disegna un cerchio. es: `var circle = document.createElementNS("http://www.w3.org/2000/svg", "circle");`

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 SVG</title>
</head>
<body>
    <svg id="svg" width="500" height="500"></svg>
    <script>
        var svg = document.getElementById("svg");
        var circle = document.createElementNS("http://www.w3.org/2000/svg", "circle");
        circle.setAttribute("cx", 250);
        circle.setAttribute("cy", 250);
        circle.setAttribute("r", 100);
        circle.setAttribute("stroke", "black");
        circle.setAttribute("fill", "transparent");
        svg.appendChild(circle);
    </script>
</body>
</html>
```

## Esempio di utilizzo di HTML5 Geolocation

Supponiamo di voler ottenere la posizione geografica di un utente. Per ottenere la posizione geografica di un utente si usa il metodo `getCurrentPosition()` che restituisce la posizione geografica di un utente. es: `navigator.geolocation.getCurrentPosition(showPosition);`

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 Geolocation</title>
</head>
<body>
    <script>
        navigator.geolocation.getCurrentPosition(showPosition);

        function showPosition(position) {
            console.log(position.coords.latitude);
            console.log(position.coords.longitude);
        }
    </script>
</body>
</html>
```

## Esempio di utilizzo di HTML5 Web Storage

Supponiamo di voler salvare dati sul computer di un utente. Per salvare dati sul computer di un utente si usa il metodo `setItem()` che salva un dato, il metodo `getItem()` che restituisce un dato e il metodo `removeItem()` che rimuove un dato. es: `localStorage.setItem("nome", "Mario"); localStorage.getItem("nome"); localStorage.removeItem("nome");`

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 Web Storage</title>
</head>
<body>
    <script>
        localStorage.setItem("nome", "Mario");
        localStorage.getItem("nome");
        console.log(localStorage.getItem("nome"));
        <!-- localStorage.removeItem("nome"); -->
    </script>
</body>
</html>
```

Supponiamo di volere chiedere il nome ad un utente e di volerlo memorizzare nel web storage.

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 Web Storage</title>
</head>
<body>
    <input type="text" id="nome">
    <button onclick="salva()">Salva</button>
    <script>
        function salva() {
            var nome = document.getElementById("nome").value;
            localStorage.setItem("nome", nome);
            console.log(localStorage.getItem("nome"));
        }
    </script>
</body>
</html>
```

## Esempio di utilizzo di HTML5 Web Workers

Supponiamo di voler eseguire uno script in background. Per eseguire uno script in background si usa il metodo `postMessage()` che invia un messaggio. es: `worker.postMessage("Hello World");`

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 Web Workers</title>
</head>
<body>
    <script>
        var worker = new Worker("worker.js");
        worker.postMessage("Hello World");
    </script>
</body>
</html>
```

file worker.js

```Html5
worker.js
onmessage = function(event) {
    console.log(event.data);
}
```

## IndexedDB

Il database creato utilizzando IndexedDB non si trova in una directory fisica accessibile, come la root dell'applicazione o una cartella sul file system. Invece, è memorizzato internamente nel browser in una zona gestita dal browser stesso. Ciò significa che il database non è un file che puoi vedere o accedere direttamente attraverso il file system del tuo computer.

Per visualizzare e interagire con il database IndexedDB, devi utilizzare gli strumenti di sviluppo del browser. Ecco come puoi accedere e gestire il database IndexedDB in vari browser:

> Google Chrome (e browser basati su Chromium come Edge e Opera)

- Apri il tuo sito web con Chrome.
- Premi F12 o clicca con il tasto destro del mouse e seleziona “Ispeziona” per aprire gli Strumenti di Sviluppo.
- Vai alla scheda "Application" (Applicazione).
- Nella barra laterale sinistra, sotto "Storage", troverai "IndexedDB". Cliccando qui, potrai vedere i database IndexedDB creati dal tuo sito.

> Firefox

- Apri il sito con Firefox.
- Premi F12 o clicca con il tasto destro e scegli “Ispeziona Elemento” per aprire gli Strumenti di Sviluppo.
- Vai alla scheda "Storage".
- Nel pannello sinistro, sotto "IndexedDB", potrai vedere i database creati.
  > Safari
- Apri il sito con Safari.
- Usa il menu “Sviluppa” e seleziona “Mostra Web Inspector”.
- Vai alla scheda "Storage" e poi a "IndexedDB".

> Microsoft Edge

- Apri il sito con Edge.
- Premi F12 o clicca con il tasto destro e scegli “Ispeziona Elemento” per aprire gli Strumenti di Sviluppo.
- Vai alla scheda "Debugger" (Debug).
- Nella barra laterale sinistra, sotto "Storage", troverai "IndexedDB". Cliccando qui, potrai vedere i database IndexedDB creati dal tuo sito.

Utilizzando questi strumenti, puoi visualizzare la struttura del database, eseguire query e persino modificare i dati direttamente dal browser. Questo è particolarmente utile per il debugging e per comprendere meglio come la tua applicazione web interagisce con il database IndexedDB.

## App web completa che utilizza HTML5 per la gestione di un database SQLite utilizzando indexeddb

l'app deve essere in grado di:

creare un database my sql con una tabella clienti premendo il pulsante crea database ed inserire i dati di un cliente premendo il pulsante inserisci cliente edi leggere i dati inseriti.
il database viene creato solo se non esiste già nella rotta specificata.

```Html5
<!DOCTYPE html>
<html>
<head>
    <title>HTML5 IndexedDB</title>
</head>
<body>
    <button onclick="creaDatabase()">Crea Database</button>
    <button onclick="inserisciCliente()">Inserisci Cliente</button>
    <button onclick="leggiCliente()">Leggi Cliente</button>
    <script>
        var db;
        var request = indexedDB.open("mydb", 1);
        request.onerror = function(event) {
            console.log("Errore");
        }
        request.onsuccess = function(event) {
            db = event.target.result;
            console.log("Successo");
        }
        request.onupgradeneeded = function(event) {
            db = event.target.result;
            var objectStore = db.createObjectStore("clienti", { keyPath: "id", autoIncrement: true });
            objectStore.createIndex("nome", "nome", { unique: false });
            objectStore.createIndex("cognome", "cognome", { unique: false });
            objectStore.createIndex("email", "email", { unique: true });
            console.log("Upgrade");
        }
        function creaDatabase() {
            var request = indexedDB.open("mydb", 1);
            request.onerror = function(event) {
                console.log("Errore");
            }
            request.onsuccess = function(event) {
                db = event.target.result;
                console.log("Successo");
            }
            request.onupgradeneeded = function(event) {
                db = event.target.result;
                var objectStore = db.createObjectStore("clienti", { keyPath: "id", autoIncrement: true });
                objectStore.createIndex("nome", "nome", { unique: false });
                objectStore.createIndex("cognome", "cognome", { unique: false });
                objectStore.createIndex("email", "email", { unique: true });
                console.log("Upgrade");
            }
        }
        function inserisciCliente() {
            var transaction = db.transaction(["clienti"], "readwrite");
            var objectStore = transaction.objectStore("clienti");
            var request = objectStore.add({ nome: "Mario", cognome: "Rossi", email: "info@mariorossi.it" });
            request.onsuccess = function(event) {
                console.log("Successo");
            }
            request.onerror = function(event) {
                console.log("Errore");
            }
        }
        function leggiCliente() {
            var transaction = db.transaction(["clienti"], "readonly");
            var objectStore = transaction.objectStore("clienti");
            var request = objectStore.get(1);
            request.onsuccess = function(event) {
                console.log("Successo");
                console.log(request.result);
            }
            request.onerror = function(event) {
                console.log("Errore");
            }
        }
    </script>
</body>
</html>
```
