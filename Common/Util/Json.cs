using System.Text;
using System.Text.Json;

namespace Common;
public static partial class Util
{
    public static class Json
    {
        public static string? Serialize(object? obj)
        {
            if (obj == null) return null;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return json;
        }

        public static TData? Deserialize<TData>(string? jsonData)
        {
            if (jsonData == null) return default;
            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<TData>(jsonData);
            return json;
        }
    }

    public static string AddDepthToJson(string json)
    {
        if (string.IsNullOrEmpty(json)) return json;

        var document = JsonDocument.Parse(json);
        var result = JsonSerializer.Serialize(document, new JsonSerializerOptions { WriteIndented = true });
        return result;
    }
}

