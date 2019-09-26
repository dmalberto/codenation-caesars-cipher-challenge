using System;

namespace codenation
{
    class Program
    {
        static Data dados = Import.GetData();
        static void Main(string[] args)
        {
            char[] alfabeto = ("abcdefghijklmnopqrstuvwxyz").ToCharArray();
            
            char[] arrayCodificado = dados.cifrado.ToCharArray();
            char[] arrayDecodificado = new char[arrayCodificado.Length];

            for (int i = 0; i < arrayCodificado.Length; i++)
            {
                try
                {
                    // int j = Array.IndexOf(alfabeto,arrayCodificado[i]);
                    // if (arrayCodificado[i] == char.Parse("a"))
                    //     arrayDecodificado[i] = char.Parse("y");
                    // else if (arrayCodificado[i] == char.Parse("b"))
                    //     arrayDecodificado[i] = char.Parse("z");
                    // else
                    //     arrayDecodificado[i] = alfabeto[j - 2];

                    int j = Array.IndexOf(alfabeto,arrayCodificado[i]);
                    arrayDecodificado[i] = alfabeto[j - 2];
                }

                catch
                {
                    arrayDecodificado[i] = arrayCodificado[i];
                }
            }
            GravaDados(arrayDecodificado);
        }
        static void GravaDados(char[] arrayDecodificado)
        {

            foreach (var item in arrayDecodificado)
                dados.decifrado += item;

            dados.resumo_criptografico = Hash.Coder(dados.decifrado);

            Export.SubmitAnswer(dados);
        }
    }
}
