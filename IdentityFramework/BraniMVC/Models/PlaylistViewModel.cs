namespace BraniMVC.Models;

public class PlaylistViewModel
{
    public IEnumerable<Brano>? Playlists { get; set; }
    public string[]? arrayAudio { get; set; }
    public int lunghezzaArray { get; set; }



    public List<string> Tracks = new List<string>
    {

    };

    public int CurrentTrackIndex = 0;

    public string CurrentTrack => Tracks[CurrentTrackIndex];

}