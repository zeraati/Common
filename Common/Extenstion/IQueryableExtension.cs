using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace System.Linq;
public static class IQueryableExtension
{
    public static async Task<TSource[]> ToArrayPagingAsync<TSource>(this IQueryable<TSource> source, Paging paging, CancellationToken cancellationToken = default)
    {
        var result = await source.Skip(paging.PageSize * (paging.PageNumber - 1)).Take(paging.PageSize)
            .ToListAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
        return result.ToArray();
    }
}