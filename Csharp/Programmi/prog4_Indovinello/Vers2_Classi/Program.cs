class Giocatore
{
    public string? nome;
    public int punteggio;

    public Giocatore(string nome, int punteggio)
    {
        this.nome = nome;
        this.punteggio = punteggio;
    }

    public void Stampa()
    {
        Console.WriteLine($"\nG1: {nome} Punteggio: {punteggio}");
    }
}


class Partita
{
    public void Gioca()
    {

        Random random = new Random();
        Giocatore g1 = new Giocatore("Alex", 0);
        Giocatore g2 = new Giocatore("Simo", 0);

        while (true)
        {

            int risG1 = random.Next(1, 7);
            int risG2 = random.Next(1, 7);

            if (risG1 > risG2)
            {
                Console.WriteLine($"Vince {g1.nome}");
                g1.punteggio++;
            }
            else if (risG2 > risG1)
            {
                Console.WriteLine($"Vince {g2.nome}");
                g2.punteggio++;
            }
            else
            {
                Console.WriteLine("Pareggio");
            }

            Console.Write("continuare? (s/n): ");
            string risp = Console.ReadLine()!;
            if (risp == "n" || risp == "N")
            {
                break;
            }

        }

        g1.Stampa();
        g2.Stampa();
    }

}


class Program
{

    public static void Main(string[] args)
    {
        Partita partita = new Partita();
        partita.Gioca();
    }

}
