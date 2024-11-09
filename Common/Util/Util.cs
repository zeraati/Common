using System.Text;

namespace Common;
public static partial class Util
{
    public enum CharacterTypeEnum { PersianNumber, PersianLetter, LatineNumber, LatineLetter }

    public static string GenerateRandomText(CharacterTypeEnum characterType, int length = 10)
    {
        var characters = "ابتثجحخدذرزسشصضطظعغفقکلمنهو";
        if (characterType == CharacterTypeEnum.PersianNumber) characters = "۰۱۲۳۴۵۶۷۸۹";
        else if (characterType == CharacterTypeEnum.LatineNumber) characters = "0123456789";
        else if (characterType == CharacterTypeEnum.LatineLetter) characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        var result = new StringBuilder();
        var random = new Random();

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characters.Length);
            result.Append(characters[index]);
        }

        return result.ToString();
    }

    public static bool HasProperty(object input, string propertyName)
    {
        return input!.GetType().GetProperty(propertyName) != null;
    }

    public static TResult GetProperty<TResult>(object input, string propertyName)
    {
        return (TResult)input!.GetType().GetProperty(propertyName)!.GetValue(input)!;
    }

    public static void GetProperty<TResult>(object input, string propertyName,TResult value)
    {
        input!.GetType().GetProperty(propertyName)!.SetValue(input,value);
    }
}

