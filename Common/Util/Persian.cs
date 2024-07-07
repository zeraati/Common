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


        public static string Money(int input)
        {
            var result = input.ToString("N0", new CultureInfo("fa-IR"));
            return Number(result) + " تومان";
        }
    }
}