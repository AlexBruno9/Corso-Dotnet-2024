using Newtonsoft.Json;

class Dado
{
    private Random random = new Random();

    public int Lancia()
    {
        return random.Next(1, 7);
    }
}

class Giocatore
{
    public string nome;
    public int punti = 100;

    public Giocatore(string nome)
    {
        this.nome = nome;
    }

    public int LanciaDadi(Dado d1, Dado d2)
    {
        int n1 = d1.Lancia();
        int n2 = d2.Lancia();
        return n1 + n2;
    }
}

class Partita
{
    public void Gioca()
    {
        Dado d1 = new Dado();
        Dado d2 = new Dado();
        Giocatore giocatore = new Giocatore("Giocatore");
        Giocatore computer = new Giocatore("Computer");

        while (giocatore.punti > 0 && computer.punti > 0)
        {
            int punteggioGiocatore = giocatore.LanciaDadi(d1, d2);
            int punteggioComputer = computer.LanciaDadi(d1, d2);

            if (punteggioGiocatore > punteggioComputer)
            {
                computer.punti -= punteggioGiocatore - punteggioComputer;
            }
            else if (punteggioComputer > punteggioGiocatore)
            {
                giocatore.punti -= punteggioComputer - punteggioGiocatore;
            }

            Console.WriteLine($"Giocatore: {punteggioGiocatore}");
            Console.WriteLine($"Computer: {punteggioComputer}");
        }

        if (giocatore.punti > 0)
        {
            Program.SalvaPunteggio(giocatore);
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Partita partita = new Partita();
        partita.Gioca();
        List<Giocatore> giocatori = LeggiPunteggi();
        StampaPunteggi(giocatori);
    }

    public static void SalvaPunteggio(Giocatore giocatore)
    {
        List<Giocatore> giocatori = LeggiPunteggi();
        giocatori.Add(giocatore);
        giocatori = giocatori.OrderByDescending(g => g.punti).Take(3).ToList();
        string json = JsonConvert.SerializeObject(giocatori, Formatting.Indented);
        File.WriteAllText(@"punteggi.json", json);
    }

    public static List<Giocatore> LeggiPunteggi()
    {
        if (File.Exists(@"punteggi.json"))
        {
            string json = File.ReadAllText(@"punteggi.json");
            return JsonConvert.DeserializeObject<List<Giocatore>>(json);
        }
        else
        {
            return new List<Giocatore>();
        }
    }

    public static void StampaPunteggi(List<Giocatore> giocatori)
    {
        foreach (Giocatore giocatore in giocatori)
        {
            Console.WriteLine(giocatore.nome + ": " + giocatore.punti);
        }
    }
}