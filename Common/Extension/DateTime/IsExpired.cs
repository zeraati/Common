namespace Common.Extension;
public static partial class DateTimeExtension
{
    public static bool IsExpired(this DateTime value,bool isUtc = true)
    {
        var now=DateTime.UtcNow;
        if (isUtc == false) now = DateTime.Now;

        return value < now;
    }

    public static bool IsExpired(this DateTime? value, bool isUtc = true)=> value.GetValueOrDefault().IsExpired(isUtc);
}