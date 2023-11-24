namespace Common.Extension;
public static partial class StringExtension
{
    public static string NullToEmpty(this string? value) => value.IsEmpty()?"":value;
}
