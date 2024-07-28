namespace Common;
public static class TimeOnlyExtension
{
    public static TimeOnly TehranToUtc(this TimeOnly input) => input.Add(-new TimeSpan(3, 30, 0));
    public static TimeOnly UtcToTehran(this TimeOnly input) => input.Add(new TimeSpan(3, 30, 0));
}