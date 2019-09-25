using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public class Export 
{
    public static void SubmitAnswer(Data data)
    {
        string json = Data.json(data);
        File.WriteAllText("answer.json", json);
        
        
    }
}