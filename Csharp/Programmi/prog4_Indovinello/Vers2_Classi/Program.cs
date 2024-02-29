class Giocatore
{
    public string? nome;
    public int punteggio;

    public int numeroOttenuto;

    public Giocatore(string nome, int punteggio)
    {
        this.nome = nome;
        this.punteggio = punteggio;
    }


    public void Stampa()
    {
        Console.WriteLine($"{nome} Punteggio: {punteggio}");
    }


}


class Partita
{


    public void Gioca()
    {

        Giocatore g1 = new Giocatore("Alex", 0);
        Giocatore g2 = new Giocatore("Simo", 0);

        Round(g1, g2);

        g1.Stampa();
        g2.Stampa();
    }



    public void Round(Giocatore g1, Giocatore g2)
    {
        int copia1 = 0, copia2 = 0;

        while (true)
        {


            Random random = new Random();
            g1.numeroOttenuto = random.Next(1, 7);
            g2.numeroOttenuto = random.Next(1, 7);


            Console.Write($"\n{g1.nome}:{g1.numeroOttenuto} - {g2.nome}:{g2.numeroOttenuto}  ---  ");

            if (g1.numeroOttenuto == copia1)
            {
                Console.Write($"\n{g1.nome} ha ottenuto due volte di seguito lo stesso numero: -2 punti;");
                g1.punteggio -= 2;
            }
            else if (g2.numeroOttenuto == copia2)
            {
                Console.Write($"\n{g2.nome} ha ottenuto due volte di seguito lo stesso numero: -2 punti;");
                g2.punteggio -= 2;
            }

            else
            {

                if (g1.numeroOttenuto > g2.numeroOttenuto)
                {
                    Console.WriteLine($"Vince {g1.nome}");
                    g1.punteggio++;
                }
                else if (g2.numeroOttenuto > g1.numeroOttenuto)
                {
                    Console.WriteLine($"Vince {g2.nome}");
                    g2.punteggio++;
                }
                else
                {
                    Console.WriteLine("Pareggio");
                }


            }

            copia1 = g1.numeroOttenuto;
            copia2 = g2.numeroOttenuto;



            Console.Write("\ncontinuare? (s/n): ");
            string risp = Console.ReadLine()!;
            if (risp == "n" || risp == "N")
            {
                Console.WriteLine("\n");
                break;
            }


        }


    }
}


class Program
{

    public static void Main(string[] args)
    {
        Console.Clear();
        Partita partita = new Partita();
        partita.Gioca();
    }

}
