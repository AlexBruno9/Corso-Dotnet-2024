/// <summary>
/// Questa è la classe del Giocatore generico <br/>
/// contiene il nome del giocatore <br/>
/// il punteggio, i crediti, <br/>
/// le partite giocate e le partite vinte
/// </summary>
class Giocatore
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Punteggio { get; set; }
    public int Crediti { get; set; }
    public int PartiteGiocate { get; set; }
    public int PartiteVinte { get; set; }


/// <summary>
/// Questo metodo stampa i dati di un Giocatore
/// una riga alla volta
/// </summary>
  public virtual void Stampa()
  {
    Console.WriteLine($"id: " + Id);
    Console.WriteLine($"Nome: " + Nome);
    Console.WriteLine($"Punteggio: " + Punteggio);
    Console.WriteLine($"crediti: " + Crediti);
    Console.WriteLine($"Partite Giocate: " + PartiteGiocate);
    Console.WriteLine($"Partite Vinte: " + PartiteVinte);
  }

}