using System.Security.Cryptography;

namespace Common;
public static partial class Utility
{
    public static string CalculateHmacSha256(string input, string key)
    {
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);
        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        using (HMACSHA256 hmac = new HMACSHA256(keyBytes))
        {
            byte[] hashBytes = hmac.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}

