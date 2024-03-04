class Carta
{
    public string seme;
    public string valore;

    public Carta(string seme, string valore)
    {
        this.seme = seme;
        this.valore = valore;
    }
}

class Mazzo
{
    private List<Carta> carte = new List<Carta>();

    public Mazzo()
    {
        string[] semi = { "Cuori", "Quadri", "Fiori", "Picche" };
        string[] valori = { "Asso", "Due", "Tre", "Quattro", "Cinque", "Sei", "Sette", "Otto", "Nove", "Dieci", "Jack", "Regina", "Re" };

        foreach (string seme in semi)
        {
            foreach (string valore in valori)
            {
                Carta carta = new Carta(seme, valore);
                carte.Add(carta);
            }
        }
    }

    public void Mescola()
    {
        Random random = new Random();
        carte = Shuffle(carte, random);
    }

    public void Stampa()
    {
        foreach (Carta carta in carte)
        {
            Console.WriteLine($"{carta.valore} di {carta.seme}");
        }
    }

    private List<Carta> Shuffle(List<Carta> list, Random random)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Carta temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Mazzo mazzo = new Mazzo();
        mazzo.Mescola();
        mazzo.Stampa();
    }
}
