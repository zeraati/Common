namespace Common.Extension;

public static partial class EnumerableExtension
{
    public static bool IsEmpty<T>(this IEnumerable<T>? value)
    {
        if (value == null) return true;
        return value.Any() == false;
    }
}
