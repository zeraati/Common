using Newtonsoft.Json;
using System.Text.Json;

namespace Common;
public static partial class Util
{
    public static class Json
    {
        public static string? Serialize(object? obj, bool nullIgnore = false)
        {
            if (obj == null) return null;

            var setting = new JsonSerializerSettings
            {
                NullValueHandling = nullIgnore == true ? NullValueHandling.Ignore : NullValueHandling.Include
            };
            var json = JsonConvert.SerializeObject(obj,setting);
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
        var result = System.Text.Json.JsonSerializer.Serialize(document, new JsonSerializerOptions { WriteIndented = true });
        return result;
    }
}

