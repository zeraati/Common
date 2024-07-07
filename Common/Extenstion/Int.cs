using System.Text;

namespace Common;
public static class IntExtension
{
    public static string ToPersian(this int input)
    {
        var persianDigits = new string[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        var result = new StringBuilder();

        foreach (char character in input.ToString())
        {
            if (char.IsDigit(character)) result.Append(persianDigits[(int)char.GetNumericValue(character)]);
            else result.Append(character);
        }

        return result.ToString();
    }
}

