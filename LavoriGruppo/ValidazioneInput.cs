/// <summary>
/// Classe che gestisce la validazione dell'input utente
/// </summary>
/// <remarks>
/// La classe contiene i metodi per la validazione di:<br/>
/// - non vuoto <br/>
/// - un valore numerico <br/>
/// - una stringa <br/>
/// - un <b>valore</b> compreso in un intervallo <br/>
/// - una stringa di lunghezza minima e massima <br/>
/// - una stringa che rispetti maiuscole e minuscole <br/>
/// </remarks>
/// <example>
/// <code>
/// var validazione = new ValidazioneInput();
/// var result = validazione.StringaVuota("ciao");
/// </code>
/// </example>
/// <example>
/// <code>
/// var validazione = new ValidazioneInput();
/// var result = validazione.ValoreCompreso(5, 1, 10);
/// </code>
/// </example>
/// <example>
/// <code>
/// var validazione = new ValidazioneInput();
/// var result = validazione.StringaLunghezza("ciao", 3, 5);
/// </code>
/// </example>
/// <example>
/// <code>
/// var validazione = new ValidazioneInput();
/// var result = validazione.StringaMaiuscole("ciao");
/// </code>
/// </example>
/// <example>
/// <code>
/// var validazione = new ValidazioneInput();
/// var result = validazione.StringaMinuscole("ciao");
/// </code>
/// </example>
/// <example>
/// <code>
/// var validazione = new ValidazioneInput();
/// var result = validazione.StringaNumerica("5");
/// </code>
/// </example>
/// <exception cref="System.ArgumentNullException">Se la stringa è nulla</exception>
/// <exception cref="System.ArgumentException">Se la stringa è vuota</exception>
/// <exception cref="System.ArgumentException">Se la stringa non è numerica</exception>
/// <exception cref="System.ArgumentOutOfRangeException">Se il valore non è compreso nell'intervallo specificato</exception>
/// <exception cref="System.ArgumentException">Se la stringa non rispetta la lunghezza minima e massima</exception>
/// <exception cref="System.ArgumentException">Se la stringa non rispetta il formato specificato</exception>

public class ValidazioneInput
{
    /// <summary>
    /// Metodo che verifica se la stringa è vuota
    /// </summary>
    /// <param name="input">La stringa da validare</param>
    /// <returns>True se la stringa è vuota, false altrimenti</returns>
    public bool StringaVuota(string input)
    {
        if (input == null)
            throw new ArgumentNullException("La stringa non può essere nulla");
        return input == "";
    }

    /// <summary>
    /// Metodo che verifica se la stringa è numerica
    /// </summary>
    /// <param name="input">La stringa da validare</param>
    /// <returns>True se la stringa è numerica, false altrimenti</returns>
    public bool StringaNumerica(string input)
    {
        if (input == null)
            throw new ArgumentNullException("La stringa non può essere nulla");
        return int.TryParse(input, out _);
    }

    /// <summary>
    /// Metodo che verifica se la stringa è di lunghezza compresa tra minimo e massimo
    /// </summary>
    /// <param name="input">La stringa da validare</param>
    /// <param name="minimo">La lunghezza minima</param>
    /// <param name="massimo">La lunghezza massima</param>
    /// <returns>True se la stringa è di lunghezza compresa tra minimo e massimo, false altrimenti</returns>
    public bool StringaLunghezza(string input, int minimo, int massimo)
    {
        if (input == null)
            throw new ArgumentNullException("La stringa non può essere nulla");
        if (input.Length < minimo || input.Length > massimo)
            throw new ArgumentException($"La stringa deve essere lunga almeno {minimo} caratteri e al massimo {massimo} caratteri");
        return true;
    }

    /// <summary>
    /// Metodo che verifica se la stringa rispetta il formato maiuscole e minuscole
    /// </summary>
    /// <param name="input">La stringa da validare</param>
    /// <returns>True se la stringa rispetta il formato maiuscole e minuscole, false altrimenti</returns>
    /// <exception cref="System.ArgumentException">Se la stringa non rispetta il formato specificato</exception>
    
    public bool StringaMaiuscole(string input)
    {
        if (input == null)
            throw new ArgumentNullException("La stringa non può essere nulla");
        if (input != input.ToUpper())
            throw new ArgumentException("La stringa deve contenere solo caratteri maiuscoli");
        return true;
    }

    /// <summary>
    /// Metodo che verifica se la stringa rispetta il formato maiuscole e minuscole
    /// </summary>
    /// <param name="input">La stringa da validare</param>
    /// <returns>True se la stringa rispetta il formato maiuscole e minuscole, false altrimenti</returns>
    /// <exception cref="System.ArgumentException">Se la stringa non rispetta il formato specificato</exception>
    
    public bool StringaMinuscole(string input)
    {
        if (input == null)
            throw new ArgumentNullException("La stringa non può essere nulla");
        if (input != input.ToLower())
            throw new ArgumentException("La stringa deve contenere solo caratteri minuscoli");
        return true;
    }

    /// <summary>
    /// Metodo che verifica se il valore è compreso nell'intervallo specificato
    /// </summary>
    /// <param name="valore">Il valore da validare</param>
    /// <param name="minimo">Il valore minimo</param>
    /// <param name="massimo">Il valore massimo</param>
    /// <returns>True se il valore è compreso nell'intervallo specificato, false altrimenti</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">Se il valore non è compreso nell'intervallo specificato</exception>
    
    public bool ValoreCompreso(int valore, int minimo, int massimo)
    {
        if (valore < minimo || valore > massimo)
            throw new ArgumentOutOfRangeException($"Il valore deve essere compreso tra {minimo} e {massimo}");
        return true;
    }
}