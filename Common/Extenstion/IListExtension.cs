namespace Common;
public static class IListExtension
{
    public static IList<TSource> ForEach<TSource>(this IList<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Count(); i++) action(source[i]);
        return source;
    }
}
