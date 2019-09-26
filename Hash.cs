using System;
using System.Text;
using System.Security.Cryptography;
public class Hash
{
    public static string coder(string input)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(input);

        var sha1 = SHA1.Create();
        byte[] hashBytes = sha1.ComputeHash(bytes);

        return HexStringFromBytes(hashBytes);
    }

    public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
}