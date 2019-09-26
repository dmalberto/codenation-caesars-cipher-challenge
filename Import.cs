using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public class Import 
{
    public Import(string Token)
    {
        token = Token;
    }

    private string token {get; set;}
    private Data dados {get; set;}

    public Data GetData()
    {
        var requisicaoWeb = WebRequest.CreateHttp($"https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token={token}");         
            requisicaoWeb.Method = "GET";

        using (var resposta = requisicaoWeb.GetResponse())
        {
            StreamReader reader = new StreamReader(resposta.GetResponseStream());
            object objResponse = reader.ReadToEnd();
            dados = JsonConvert.DeserializeObject<Data>(objResponse.ToString());
            resposta.Close();
            return dados;
        }
    }
}