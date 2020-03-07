using System;

namespace codenation
{
    class Program
    {
        const string token = "3277aded868360b49307353022717d546bb28e69";
        static void Main(string[] args)
        {
            Import import = new Import(token);
            Data dados = import.GetData();
            Console.WriteLine(dados.numero_casas);
            char[] alfabeto = ("abcdefghijklmnopqrstuvwxyz").ToCharArray();

            char[] arrayCodificado = dados.cifrado.ToCharArray();
            char[] arrayDecodificado = new char[arrayCodificado.Length];

            Console.WriteLine(dados.cifrado);

            for (int i = 0; i < arrayCodificado.Length; i++)
            {
                try
                {
                    int j = Array.IndexOf(alfabeto, arrayCodificado[i]);
                    if (arrayCodificado[i] == char.Parse("a"))
                        arrayDecodificado[i] = char.Parse("v");
                    else if (arrayCodificado[i] == char.Parse("b"))
                        arrayDecodificado[i] = char.Parse("w");
                    else if (arrayCodificado[i] == char.Parse("c"))
                        arrayDecodificado[i] = char.Parse("x");
                    else if (arrayCodificado[i] == char.Parse("d"))
                        arrayDecodificado[i] = char.Parse("y");
                    else if (arrayCodificado[i] == char.Parse("e"))
                        arrayDecodificado[i] = char.Parse("z");
                    else
                        arrayDecodificado[i] = alfabeto[j - dados.numero_casas];
                }
                catch
                {
                    arrayDecodificado[i] = arrayCodificado[i];
                }
            }

            foreach (var item in arrayDecodificado)
                dados.decifrado += item;
            Console.WriteLine(dados.decifrado.ToString());
            dados.resumo_criptografico = Hash.coder(dados.decifrado);

            Export.SubmitAnswer(dados);
        }
    }
}