using System;

namespace codenation
{
    class Program
    {
        const string token = "94fbe8b6066b7612bb28f720e61a05cd05edf0e9";
        static void Main(string[] args)
        {
            Import import = new Import(token);
            Data dados = import.GetData();

            char[] alfabeto = ("abcdefghijklmnopqrstuvwxyz").ToCharArray();
            
            char[] arrayCodificado = dados.cifrado.ToCharArray();
            char[] arrayDecodificado = new char[arrayCodificado.Length];

            for (int i = 0; i < arrayCodificado.Length; i++)
            {
                try
                {
                    int j = Array.IndexOf(alfabeto,arrayCodificado[i]);
                    if (arrayCodificado[i] == char.Parse("a"))
                        arrayDecodificado[i] = char.Parse("y");
                    else if (arrayCodificado[i] == char.Parse("b"))
                        arrayDecodificado[i] = char.Parse("z");
                    else
                        arrayDecodificado[i] = alfabeto[j - 2];
                }

                catch
                {
                    arrayDecodificado[i] = arrayCodificado[i];
                }
            }

            foreach (var item in arrayDecodificado)
                dados.decifrado += item;

            dados.resumo_criptografico = Hash.coder(dados.decifrado);

            Export.SubmitAnswer(dados);
        }
    }
}
