using Newtonsoft.Json;

namespace Common.Extension
{
    public static partial class StringExtension
    {
        public static T JsonToModel<T>(this string value)
        {
            if (value != null)
            {
                var result = JsonConvert.DeserializeObject<T>(value);
                if (result != null) return result;
            }

            return default!;
        }
    }
}
