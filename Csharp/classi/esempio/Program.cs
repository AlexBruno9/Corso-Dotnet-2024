class Palazzo
{
    private string nome;
    private string via;


    public Palazzo(string nome, string via)
    {
        this.nome = nome;
        this.via = via;
    }

    public string Nome { get => nome; set => nome = value; }
    public string Via { get => via; set => via = value; }


}

class Appartamento : Palazzo
{
    private int interno;

    public Appartamento(string nome, string via, int interno) : base(nome, via)
    {
        this.interno = interno;
    }

    public int Interno
    {
        get => interno; set =>interno = value; 
    }

}

class Program
{
    static void Main (string[] args)
    {
        Appartamento app=new Appartamento("Loto", "Tassara", 3 );
        Console.WriteLine("Condominio: "+app.Nome);
        Console.WriteLine("Via: "+app.Via);
        Console.WriteLine("Interno: "+app.Interno);
    }

}

