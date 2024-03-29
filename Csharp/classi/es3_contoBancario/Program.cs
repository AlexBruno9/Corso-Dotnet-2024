﻿class ContoBancario

{
    private string nome;
    private double saldo;

    public ContoBancario(string nome, double saldo)
    {
        this.nome=nome;
        this.saldo=saldo;
    }

    public string Nome { get => nome; set => nome = value; }
    public double Saldo { get => saldo; set => saldo = value; }

    public void Deposita(double importo)
    {
        Saldo+=importo;
    }

    public void Preleva(double importo)
    {
        Saldo-=importo;
    }

    public void Stampa()
    {
        Console.WriteLine("Nome: "+Nome);
        Console.WriteLine("Saldo: "+Saldo);
    }

}



class ContoCorrente:ContoBancario
{
    private double tasso;

    public ContoCorrente(string nome, double saldo, double tasso):base(nome, saldo)
    {
        this.tasso=tasso;
    }

    public void CalcolaInteressi()
    {
        double interessi=Saldo*tasso/100;
        Saldo+=interessi;
    }

}

class Program 
{
    static void Main (string[] args)
    {
        ContoCorrente cc=new ContoCorrente("Mario Rossi", 1000, 2);
        cc.Deposita(500);
        cc.Stampa();
        cc.Preleva(500);
        cc.Stampa();
        cc.CalcolaInteressi();
        cc.Stampa();
        
    }
}