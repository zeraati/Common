using System.Globalization;

namespace Common.Extension;
public static partial class DateTimeExtension
{
    public static string PersianDate(this DateTime value,string seperator="/")
    {
        var persianCalendar = new PersianCalendar();
        var year = persianCalendar.GetYear(value);
        var month = persianCalendar.GetMonth(value);
        var day = persianCalendar.GetDayOfMonth(value);

        var result = $"{year}{seperator}{month.ToString("D2")}{seperator}{day.ToString("D2")}";
        return result;
    }

    public static string PersianDate(this DateTime? value)
    {
        if (value == null) throw new NullReferenceException();
        return value.GetValueOrDefault().PersianDate();
    }

    public static string PersianDayName(this DateTime value)
    {
        var result = "";
        switch (value.DayOfWeek)
        {
            case DayOfWeek.Saturday: result = "شنبه"; break;
            case DayOfWeek.Sunday: result = "یکشنبه"; break;
            case DayOfWeek.Monday: result = "دوشنبه"; break;
            case DayOfWeek.Tuesday: result = "سه شنبه"; break;
            case DayOfWeek.Wednesday: result = "چهارشنبه"; break;
            case DayOfWeek.Thursday: result = "پنجشنبه"; break;
            case DayOfWeek.Friday: result = "جمعه"; break;
        }

        return result;
    }

    public static string PersianDayName(this DateTime? value)
    {
        if (value == null) throw new NullReferenceException();
        return value.GetValueOrDefault().PersianDayName();
    }
}