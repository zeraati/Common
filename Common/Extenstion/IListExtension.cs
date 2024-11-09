namespace Common;
public static class IListExtension
{
    public static IList<TSource> ForEach<TSource>(this IList<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Count(); i++) action(source[i]);
        return source;
    }

    public static ICollection<TSource> ForEach<TSource>(this ICollection<TSource> source, Action<TSource> action)
    {
        for (var i = 0; i < source.Count(); i++) {

            var item = source.ElementAt(i);
            action(item);
        }
        return source;
    }
}
