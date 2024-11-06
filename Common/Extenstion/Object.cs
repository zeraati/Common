using Newtonsoft.Json;

namespace Common;
public static class ObjectExtension
{
    public static string? ToJson(this object input,bool indented=true, bool nullIgnore = false)
    {
        if (input == null) return null;

        var setting = new JsonSerializerSettings
        {
            NullValueHandling = nullIgnore == true ? NullValueHandling.Ignore : NullValueHandling.Include,
            Formatting = indented ? Formatting.Indented:Formatting.None,
        };
        var json = JsonConvert.SerializeObject(input, setting);
        return json;
    }
}
