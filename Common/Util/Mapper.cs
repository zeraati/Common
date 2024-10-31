namespace Common;
public static class AutoMapper
{
    public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
    {
        var destination = new TDestination();
        var sourceType = typeof(TSource);
        var destinationType = typeof(TDestination);

        foreach (var sourceProperty in sourceType.GetProperties())
        {
            var destinationProperty = destinationType.GetProperty(sourceProperty.Name);
            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
        return destination;
    }
}

