using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

public class Export 
{

    
    static void SaveFile(Data data)
    {
        string json = Data.json(data);
        File.WriteAllText(Constants.file, json);
    }
    public static void SubmitAnswer(Data data)
    {
        SaveFile(data);
        
        // Referência: https://stackoverflow.com/questions/566462/upload-files-with-httpwebrequest-multipart-form-data

        NameValueCollection nvc = new NameValueCollection();

        string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
        byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

        HttpWebRequest wr = (HttpWebRequest)WebRequest.Create($"{Constants.postUrl}{data.token}");
        wr.ContentType = "multipart/form-data; boundary=" + boundary;
        wr.Method = "POST";
        wr.KeepAlive = true;
        wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

        Stream rs = wr.GetRequestStream();

        string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
        foreach (string key in nvc.Keys)
        {
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string formitem = string.Format(formdataTemplate, key, nvc[key]);
            byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
            rs.Write(formitembytes, 0, formitembytes.Length);
        }
        rs.Write(boundarybytes, 0, boundarybytes.Length);

        string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
        string header = string.Format(headerTemplate, Constants.paramName, Constants.file, Constants.contentType);
        byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
        rs.Write(headerbytes, 0, headerbytes.Length);

        FileStream fileStream = new FileStream(Constants.file, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[4096];
        int bytesRead = 0;
        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) {
            rs.Write(buffer, 0, bytesRead);
        }
        fileStream.Close();

        byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
        rs.Write(trailer, 0, trailer.Length);
        rs.Close();

        WebResponse wresp = null;
        try {
            wresp = wr.GetResponse();
            Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            var teste = reader2.ReadToEnd();
            Console.Write(teste.ToString());
        } catch {
            if(wresp != null) {
                wresp.Close();
                wresp = null;
            }
        } finally {
            wr = null;
        }
    }
    
}