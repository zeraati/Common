using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Common.Extension;
public static partial class ObjectExtension
{
    public static string ToJson(this object value)
    {
        if (value == null) return "{}";
        else if (value.ToString()?.IsJson() == true) return value.ToString()!;

        var setting = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        return JsonConvert.SerializeObject(value, setting);
    }
}
