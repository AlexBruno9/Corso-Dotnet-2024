using Microsoft.EntityFrameworkCore;

public class PlaylistController
{

    private Database _db = new();
    private View _view = new();



    public void AddCanzonePlaylist()
    {


        Console.Write("Enter song name:");
        var name = _view.GetInput();


        Console.Write("Enter nome artista:");
        string input = _view.GetInput();
        while (_db.GetIdFromArtist(input) == 0)
        {
            Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
            input = _view.GetInput();
        }
        int idArtist = _db.GetIdFromArtist(input);


        bool trovato = false;
        foreach (Canzone c in _db.Canzoni)
        {
            if (c.Titolo == name && c.ArtistaId == idArtist)
            {
                trovato = true;
                Console.Write("Nome playlist in cui inserire la canzone: ");
                string NomePlay=Console.ReadLine();

                CanzonePlaylist canzonePlaylist = new CanzonePlaylist();
                canzonePlaylist.CanzoneId = c.Id;
                canzonePlaylist.NomePlaylist=NomePlay;

                _db.Playlist.Add(canzonePlaylist);
                _db.SaveChanges();
                break;
            }
        }

        if (trovato == false)
        {
            Console.WriteLine("Canzone non trovata, assicurati di aver inserito correttamente nome e artista.\nOperazione annullata.\n");
            Thread.Sleep(3500);

        }

    }



    public void RemoveCanzonePlaylist()
    {


        Console.Write("Enter song name:");
        var name = _view.GetInput();


        Console.Write("Enter nome artista:");
        string input = _view.GetInput();
        while (_db.GetIdFromArtist(input) == 0)
        {
            Console.Write("Artista non presente in catalogo, inseriscine uno presente: ");
            input = _view.GetInput();
        }
        int idArtist = _db.GetIdFromArtist(input);


        bool trovato = false;
        foreach (Canzone c in _db.Canzoni)
        {
            if (c.Titolo == name && c.ArtistaId == idArtist)
            {
                trovato = true;
                int elimina = c.Id;

                foreach (CanzonePlaylist cp in _db.Playlist)
                {
                    if (c.Id == cp.CanzoneId)
                    {
                        trovato = true;
                        _db.Playlist.Remove(cp);
                        _db.SaveChanges();
                        break;
                    }
                }

            }
        }

        if (trovato == false)
        {
            Console.WriteLine("Canzone non trovata, assicurati di aver inserito correttamente nome e artista.\nOperazione annullata.\n");
            Thread.Sleep(3500);

        }

    }




    public void ShowPlaylist()
    {

        var playlist = _db.Playlist.Include(d => d.Canzone).Include(c => c.Canzone.Artista).Include(c => c.Canzone.Disco).ToList();
        List<string> users = new List<string>();

        int counter=0;
        foreach (var p in playlist)
        {
            counter++;
            users.Add($"{counter} - {p.Canzone.Titolo} {_db.Spazio(25 - p.Canzone.Titolo.Length)} {p.Canzone.Artista.Nome} {_db.Spazio(15 - p.Canzone.Artista.Nome.Length)} {p.Canzone.Disco.Titolo} ");
        }

        if(counter==0)
        {
            Console.Clear();
            Console.WriteLine("\n\nLe tue playlist sono vuote!");
            Thread.Sleep(3000);
        }
        else{
        _view.ShowCanzoni(users);
        }
    }

//------------------------------------------------------------------
/*
    public void ShowPlaylistSelezionata()
    {
        
        _view.SelezionaPlaylist(_);
    }
*/


}