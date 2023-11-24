namespace Common.Extension;

public static partial class EnumerableExtension
{
    public static string StringJoin<T>(this IEnumerable<T>? values,string separator = ",")
    {
        if (values.IsEmpty() == true) return "";

        var result = string.Join(separator, values!);
        return result;
    }
}