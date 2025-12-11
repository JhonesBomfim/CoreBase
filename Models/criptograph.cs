using System;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Text;

public class HasService
{
    public static string ComputeSHA256(string rawData)
    {
        // Create an object SHA256
        using (SHA256 sha2560Hash = SHA256.Create())
        {
            //Calculate hash a string
            byte[] bytes = sha2560Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert bytes array to hexadecimal string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
