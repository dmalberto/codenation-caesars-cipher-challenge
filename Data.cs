using System;
using Newtonsoft.Json;
public class Data
{
    public Data()
    {

    }
    public int numero_casas {get; set;}
    public string token {get; set;}
    public string cifrado {get; set;}
    public string decifrado {get; set;}
    public string resumo_criptografico {get; set;}

    public static string json(Data data)
    {
        return JsonConvert.SerializeObject(data);
    }
}