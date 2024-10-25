using System.Text.RegularExpressions;

namespace Common;
public static partial class Util
{
    public class Validation
    {
        public static bool IsValidMobil(string number)
        {
            string pattern = @"^09\d{9}$";
            return Regex.IsMatch(number, pattern);
        }
    }
}