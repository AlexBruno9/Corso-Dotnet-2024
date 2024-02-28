class Libro
{
    public string titolo;
    public string autore;


    public Libro(string titolo, string autore)
    {
        this.titolo=titolo;
        this.autore=autore;
    }
/*
    public string Titolo { get => titolo; set => titolo = value; }
    public double Autore { get => autore; set => autore = value; }
*/


    class Biblioteca
    {
        private List<Libro> libri = new List<Libro>();

        public void Aggiungi(Libro libro)
        {
            libri.Add(libro);
        }

        public void Stampa()
        {
            foreach(Libro libro in libri)
            {
                Console.WriteLine("Titolo: "+libro.titolo);
                Console.WriteLine("Autore: "+libro.autore);
            }
        
        }

    }

    class Program
    {
        static void Main (string[]args)
        {
            Biblioteca biblioteca=new Biblioteca();
            Libro L1=new Libro("Il signore degli anelli", "J.R.R. Tolkien");
            Libro L2=new Libro("Il nome della rosa", "Umberto Eco");
            biblioteca.Aggiungi(L1);
            biblioteca.Aggiungi(L2);
            biblioteca.Stampa();
        }
    }


}