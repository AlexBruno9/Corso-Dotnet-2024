//  ESEMPIO CLASSE DADO

using System.Diagnostics.Contracts;

class Dado
{
    private Random random=new Random();

    public int Lancia()
    {
        return random.Next(1, 7);
    }
}

class Program
{
    static void Main (string[]args)
    {
        Dado d1= new Dado();
        Dado d2=new Dado();

        int n1=d1.Lancia();
        int n2=d2.Lancia();

        Console.WriteLine("Dado 1:"+n1);
        Console.WriteLine("Dado 2:"+n2);
    }
}