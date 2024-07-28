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

        public static T ToEnum<T>(string input) where T: struct,Enum
        {
            _ = Enum.TryParse(input, out T result);
            return result;
        }
    }
}