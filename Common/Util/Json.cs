using System.Text;
using System.Text.Json;

namespace Common;
public static partial class Util
{
    public static class Json
    {
        public static string? Serialize(object obj)
            => obj != null ? Newtonsoft.Json.JsonConvert.SerializeObject(obj) : null;
    }

    public static string AddDepthToJson(string json)
    {
        if (string.IsNullOrEmpty(json)) return json;

        var document = JsonDocument.Parse(json);
        var result = JsonSerializer.Serialize(document, new JsonSerializerOptions { WriteIndented = true });
        return result;
    }
}

