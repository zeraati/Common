using Common.Extension;

namespace Common;
public static partial class Utility
{
    public static string? ConcatString(string separator, params string?[] values)
    {
        if (values.IsEmpty() == true) return null;
        var result = values.Where(x => x.IsEmpty() == false).StringJoin(separator);
        return result;
    }
}