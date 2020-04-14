using System;

namespace codenation {
    class Program {
        const string token = "";
        static char[] alphabet = ("abcdefghijklmnopqrstuvwxyz").ToCharArray ();
        static void Main (string[] args) {
            Import import = new Import (token);
            Data data = import.GetData ();
            Console.WriteLine (data);

            char[] codedArray = data.cifrado.ToCharArray ();
            char[] decodedArray = new char[codedArray.Length];

            Console.WriteLine (data.cifrado);

            for (int i = 0; i < codedArray.Length; i++) {
                try {
                    int oldPos = Array.IndexOf (alphabet, codedArray[i]);
                    int newPos = GetNewPos (oldPos, data);

                    decodedArray[i] = alphabet[newPos];
                } catch {
                    decodedArray[i] = codedArray[i];
                }
            }

            foreach (var item in decodedArray)
                data.decifrado += item;
            Console.WriteLine (data.decifrado.ToString ());
            data.resumo_criptografico = Hash.coder (data.decifrado);

            Export.SubmitAnswer (data);
        }
        static int GetNewPos (int oldPos, Data data) {
            int pos = oldPos - data.numero_casas;

            if (pos < 0 && Math.Abs (pos) <= data.numero_casas)
                pos = alphabet.Length + oldPos - data.numero_casas;

            return pos;
        }
    }
}