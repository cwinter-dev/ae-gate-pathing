using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AEBestGatePath.API;

public class Paged<T> where T : class
{
    public static async Task<Paged<T>> GetPaged(IQueryable<T> query, Expression<Func<T, Guid>> idField, int page = 1, int itemsPerPage = 0, string? sort = null, bool asc = true)
    {
        page = Math.Max(0, page - 1);

        query = (sort != null ? query.OrderBy($"{sort} {(asc ? "ASC" : "DESC")}") : query.OrderBy(idField)).ThenBy(idField);
        var count = await query.CountAsync();
        var skip = Math.Min(count, page * itemsPerPage);
        if (skip > 0)
            query = query.Skip(skip);
        if (itemsPerPage < count - skip)
            query = query.Take(itemsPerPage);
        return new()
        {
            Items = await query.ToListAsync(),
            Count = count
        };
    }
    
    public required List<T> Items { get; set; }
    public required long Count { get; set; }
    
    public Dictionary<string, string>? LastScannedKey { get; set; }
}