namespace Common;
public static class ObjectExtension
{
    public static string? ToJson(this object input, bool nullIgnore = false) => Util.Json.Serialize(input,nullIgnore);
}
