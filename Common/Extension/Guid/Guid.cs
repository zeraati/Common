namespace Common.Extension;

public static partial class GuidExtension
{
    public static bool IsEmpty(this Guid value)=> value == Guid.Empty;
    public static bool IsEmpty(this Guid? value)=> value.GetValueOrDefault().IsEmpty();
}
