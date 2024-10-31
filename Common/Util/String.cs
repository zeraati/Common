namespace Common;
public static class String
{
    public static TimeOnly ToTimeOnly(string time)
    {
        var split = time.Split(":");
        return new TimeOnly(int.Parse(split[0]), int.Parse(split[1]));
    }
}