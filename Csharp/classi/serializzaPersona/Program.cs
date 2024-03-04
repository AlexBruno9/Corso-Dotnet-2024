using Newtonsoft.Json;
//comando dotnet add package Newtonsoft.json


//definizione diuna classe per mappare i dati json
public class Persona
{

    public string? Nome{get;set;}
    public int Eta{get;set;}
    public bool Impiegato{get;set;}
}

public class GestioneJson
{

    public static void Main(string[]args)
    {
        //creazione di un oggetto Persona
        Persona persona=new Persona()
        {
            Nome="Mario Rossi",
            Eta=30,
            Impiegato=true
        };

        //serializzazione dell'oggetto in una stringa Json
        string json=JsonConvert.SerializeObject(persona, Formatting.Indented);
        File.WriteAllText(@"persona.json", json);

        //deserializzazione della stringa JSON in un oggetto Persona
        string jsonDaLeggere = File.ReadAllText(@"persona.json");
        Persona personaDeserializzata = JsonConvert.DeserializeObject<Persona>(jsonDaLeggere)!;

        Console.WriteLine(personaDeserializzata.Nome);

    }

}