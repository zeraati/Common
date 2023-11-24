namespace Common.Extension;
public static partial class StringExtension
{
    public static string StringFormat(this string param, params object[] args) => string.Format(param, args);
}
