//per utilizzare file json bisogna installare il pacchetto Newtonsoft.Json
// il comando va inserito nella root del progetto
// dotnet add package Newtonsoft.json
using Newtonsoft.Json;

/*
per leggere solo il file .json

        string path = @"utenti.json";
        string json = File.ReadAllText(path);
        Console.WriteLine(json);
*/


//  versione deserializzazione di file
/*
class Program
{
    static void Main(string[] args)
    {

        string path = @"utenti.json";
        string json = File.ReadAllText(path);
        dynamic obj = JsonConvert.DeserializeObject(json)!;


        foreach (var utente in obj)
        {
            Console.WriteLine($"nome: {utente.nome} cognome: {utente.cognome} eta: {utente.eta}");
        }

    }
}
*/



//  versione serializzazione di file

class Program
{
    static void Main(string[] args)
    {

        string path = @"test.json";
        File.Create(path).Close();
        File.AppendAllText(path, "[\n");
        while (true)
        {
            Console.WriteLine("Inserisci nome ed eta:");
            string nome = Console.ReadLine()!;
            string eta = Console.ReadLine()!;
            File.AppendAllText(path, JsonConvert.SerializeObject(new { nome, eta }) + ",\n");
            Console.Write("Vuoi inserire un altro utente? (s/n) :  ");
            string risposta = Console.ReadLine()!;
            if (risposta == "n")
            {
                break;
            }
        }

        //togli l'ultima virgola        

        string file = File.ReadAllText(path);
        file = file.Remove(file.Length - 2, 1);
        //  cioè vado indietro di due caratteri e ne tolgo uno
        File.WriteAllText(path, file);
        File.AppendAllText(path, "]");
    }
}
