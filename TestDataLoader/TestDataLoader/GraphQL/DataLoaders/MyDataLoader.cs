using GreenDonut.Projections;
using Microsoft.EntityFrameworkCore;
using TestDataLoader.Db;

namespace TestDataLoader.GraphQL.DataLoaders;

public class MyDataLoader
{
    [DataLoader]
    public static async Task<Dictionary<Guid, Foo>> GetFoos(
        IReadOnlyList<Guid> ids,
        ApplicationDbContext context,
        ISelectorBuilder selection,
        CancellationToken ct)
    {
        var res = await context.Foos
            .Where(t => ids.Contains(t.Id))
            .Select(selection, key: f => f.Id)
            .ToDictionaryAsync(t => t.Id, ct);
        return res;
    }
}