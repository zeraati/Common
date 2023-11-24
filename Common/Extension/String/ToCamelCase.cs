namespace Common.Extension;
public static partial class StringExtension
{
    public static string ToCamelCase(this string value)
    {
        var result= value.Replace("_", "");
        result = char.ToLowerInvariant(result[0]) + result.Substring(1);
        return result;
    }
}
