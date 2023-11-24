namespace Common.Extension;
public static partial class DateTimeExtension
{
    public static bool IsEmpty(this DateTime value)=>value==DateTime.MinValue;

    public static bool IsEmpty(this DateTime? value)=> value.GetValueOrDefault().IsEmpty();
}