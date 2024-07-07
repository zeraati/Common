namespace Common;
public static class TimeSpanExtension
{
    public static TimeSpan TehranToUtc(this TimeSpan input) => input.Add(-new TimeSpan(3, 30, 0));
    public static TimeSpan UtcToTehran(this TimeSpan input) => input.Add(new TimeSpan(3, 30, 0));
}