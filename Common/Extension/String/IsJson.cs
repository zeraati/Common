using Newtonsoft.Json.Linq;

namespace Common.Extension
{
    public static partial class StringExtension
    {
        public static bool IsJson(this string value)
        {
            if (value == null || value.ToString() == "") return false;
            try
            {
                JToken.Parse(value);
                return true;
            }
            catch { return false; }
        }
    }
}
