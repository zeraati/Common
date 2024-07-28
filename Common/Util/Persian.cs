using System.Globalization;
using System.Text;

namespace Common;
public static partial class Util
{
    public class Persian
    {
        public static string Number(string input)
        {
            var persianDigits = new string[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            var result = new StringBuilder();

            foreach (char character in input)
            {
                if (char.IsDigit(character)) result.Append(persianDigits[(int)char.GetNumericValue(character)]);
                else result.Append(character);
            }

            return result.ToString();
        }

        public static string Number(int input) => Number(input.ToString());

        public static string ToLatinNumber(string input)
        {
            var result = "";
            char[] persian = { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            char[] latin = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < persian.Length; i++) result = result.Replace(persian[i], latin[i]);
            return result;
        }

        public static string ToLatinNumber(int input) => ToLatinNumber(input.ToString());

        public static string Money(int input)
        {
            var result = input.ToString("N0", new CultureInfo("fa-IR"));
            return Number(result) + " تومان";
        }
    }
}