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
            char[] alfabeto = ("abcdefghijklmnopqrstuvwxyz").ToCharArray();

            char[] arrayCodificado = dados.cifrado.ToCharArray();
            char[] arrayDecodificado = new char[arrayCodificado.Length];

            Console.WriteLine(dados.cifrado);

            for (int i = 0; i < arrayCodificado.Length; i++)
            {
                try
                {
                    int j = Array.IndexOf(alfabeto, arrayCodificado[i]);
                    int newPos = j - dados.numero_casas;

                    if (newPos < 0 && Math.Abs(newPos) <= dados.numero_casas)
                        newPos = alfabeto.Length - Math.Abs(j) - dados.numero_casas;

                    arrayDecodificado[i] = alfabeto[newPos];
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