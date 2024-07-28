using System.Globalization;

namespace Common;
public static class DateTimeExtension
{
    public static DateTime TehranToUtc(this DateTime date) => date.Add(-new TimeSpan(3, 30, 0));
    public static DateTime UtcToTehran(this DateTime date) => date.Add(new TimeSpan(3, 30, 0));

    public static TimeOnly TehranToUtc(this TimeOnly time) => time.Add(-new TimeSpan(3, 30, 0));
    public static TimeOnly UtcToTehran(this TimeOnly time) => time.Add(new TimeSpan(3, 30, 0));
    
    public static DateOnly GetDateOnly(this DateTime date) => DateOnly.FromDateTime(date);
    public static TimeOnly GetTimeOnly(this DateTime date) => TimeOnly.FromDateTime(date);

    public static string ToPersianDate(this DateTime date)
    {
        var persianCalendar = new PersianCalendar();
        int year = persianCalendar.GetYear(date);
        int month = persianCalendar.GetMonth(date);
        int day = persianCalendar.GetDayOfMonth(date);

        var persianDate = $"{year}/{month:D2}/{day:D2}";
        return Util.Persian.Number(persianDate);
    }
}

