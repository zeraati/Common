namespace Common;
public static partial class Util
{
    public class String
    {
        public static TimeOnly ToTimeOnly(string time)
        {
            var split = time.Split(":");
            return new TimeOnly(int.Parse(split[0]), int.Parse(split[1]));
        }
    }
}