namespace Common;
public static class ObjectExtension
{
    public static string? ToJson(this object input) => Util.Json.Serialize(input);
}
