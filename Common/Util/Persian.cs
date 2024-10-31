using System.Text;
using System.Globalization;

namespace Common;
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
        char[] persian = { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
        char[] latin = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        for (int i = 0; i < persian.Length; i++) input = input.Replace(persian[i], latin[i]);
        return input;
    }

    public static string Money(int input)
    {
        var result = input.ToString("N0", new CultureInfo("fa-IR"));
        return Number(result) + " تومان";
    }

    public static DateTime PersianToGregorian(string persianDate)
    {
        var persianCalendar = new PersianCalendar();

        var dateParts = persianDate.Split(['/', '-']);
        int year = int.Parse(dateParts[0]);
        int month = int.Parse(dateParts[1]);
        int day = int.Parse(dateParts[2]);

        var gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        return gregorianDate;
    }

    public static DayOfWeekPersianEnum? ToDayOfWeek(string dayName)
    {
        if (dayName == "شنبه") return DayOfWeekPersianEnum.شنبه;
        if (dayName == "يکشنبه") return DayOfWeekPersianEnum.يکشنبه;
        if (dayName == "دوشنبه") return DayOfWeekPersianEnum.دوشنبه;
        if (dayName == "سه‌شنبه") return DayOfWeekPersianEnum.سهشنبه;
        if (dayName == "سه شنبه") return DayOfWeekPersianEnum.سهشنبه;
        if (dayName == "چهارشنبه") return DayOfWeekPersianEnum.چهارشنبه;
        if (dayName == "پنجشنبه") return DayOfWeekPersianEnum.پنجشنبه;
        if (dayName == "جمعه") return DayOfWeekPersianEnum.جمعه;

        return null;
    }
}