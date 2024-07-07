using System.Globalization;

namespace Common;

public static class DateTimeExtension
{
    public static DateTime TehranToUtc(this DateTime input) => input.Add(-new TimeSpan(3, 30, 0));
    public static DateTime UtcToTehran(this DateTime input) => input.Add(new TimeSpan(3, 30, 0));

    public static string DatePersian(this DateTime input)
    {
        var persianCalendar = new PersianCalendar();

        int year = persianCalendar.GetYear(input);
        int month = persianCalendar.GetMonth(input);
        int day = persianCalendar.GetDayOfMonth(input);

        var result= $"{year}/{month:D2}/{day:D2}";

        return Util.Persian.Number(result);
    }

    public static string DayOfWeekPersian(this DateTime input)
    {
        string[] persianWeekDays = ["شنبه", "یک‌شنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه"];

        var dayOfWeek = input.DayOfWeek;
        var persianDayOfWeek = persianWeekDays[(int)dayOfWeek];
        return persianDayOfWeek;
    }
}

