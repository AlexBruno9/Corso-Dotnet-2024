namespace BraniMVC.Models;
public class PlaylistModel
{

    // [Authorize(Roles = "User")]

    public IEnumerable<Brano>? Playlists { get; set; }
    public string[]? arrayAudio { get; set; }
    public int lunghezzaArray { get; set; }


    public int Id { get; set; }
    public string? Titolo { get; set; }
    public string? Artista { get; set; }
    public int Anno { get; set; }
    public string? Immagine { get; set; }
    public string? Genere { get; set; }
    public string? Durata { get; set; }
    public string? Audio { get; set; }
    public IEnumerable<Brano>? Brani { get; set; }

    public int numeroPagine { get; set; }
  
    public int? PageIndex { get; set; }



    public List<string> Tracks = new List<string>
    {

    };

    public int CurrentTrackIndex = 0;

    public string CurrentTrack => Tracks[CurrentTrackIndex];

}