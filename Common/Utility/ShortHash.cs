namespace Common
{
    public static partial class Utility
    {
        public static string ShortHash(string value)
        {
            var result = string.Format("{0:X2}", value.GetHashCode());
            return result;
        }
    }
}
