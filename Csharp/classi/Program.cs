class Giocatore
{

    public int leggiPuntGioc1()
    {
        string path = @"Punteggio.csv";

        string[] lines = File.ReadAllLines(path);
        string[][] line = new string[lines.Length][];

        for (int i = 0; i < 2; i++)
        {
            line[i] = lines[i].Split(",");
        }

        int totCarriAttacco = Int32.Parse(line[0][0]);

        return totCarriAttacco;

    }
}



class Program
{
    static void Main(string[] args)
    {


        Giocatore g1 = new Giocatore();
        int PuntGioc1=g1.leggiPuntGioc1();
        Console.WriteLine("Tot armate g1: "+PuntGioc1);


    }
}