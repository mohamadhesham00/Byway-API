using Byway.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Byway.Application.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PagedResult<T>> PaginateAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var totalItems = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<T>(items, totalItems, pageNumber, pageSize);
        }

        public static PagedResult<TOut> Map<TIn, TOut>(
            this PagedResult<TIn> source,
            Func<TIn, TOut> mapper)
        {
            return new PagedResult<TOut>(
                source.Items.Select(mapper),
                source.TotalItems,
                source.PageNumber,
                source.PageSize
            );
        }
    }
}
