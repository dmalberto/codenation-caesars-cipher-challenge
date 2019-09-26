using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public class Import 
{
    public static Data GetData()
    {
        var requisicaoWeb = WebRequest.CreateHttp($"{Constants.getUrl}{Constants.token}");         
            requisicaoWeb.Method = "GET";

        using (var response = requisicaoWeb.GetResponse())
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            object objResponse = reader.ReadToEnd();
            Data data = new Data();
            data = JsonConvert.DeserializeObject<Data>(objResponse.ToString());
            response.Close();
            return data;
        }
    }
}