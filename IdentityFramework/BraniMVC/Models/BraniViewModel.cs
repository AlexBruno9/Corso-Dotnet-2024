namespace BraniMVC.Models;

public class BraniViewModel
{
    public Brano? Brano { get; set; }
    public IEnumerable<Brano>? Brani { get; set; }
    public int numeroPagine { get; set; }
    public string? FiltroArtista { get; set; }
    public string? FiltroTitolo { get; set; }
    public int? PageIndex { get; set; }
}