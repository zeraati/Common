using Newtonsoft.Json;

namespace Common;
public static partial class Util
{
    public static class Json
    {
        public static string? Serialize(object obj)
            => obj != null ? JsonConvert.SerializeObject(obj) : null;
    }
}
