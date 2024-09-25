using TestDataLoader.Db;

namespace TestDataLoader.GraphQL;

public class Query
{
    [UseProjection]
    public IQueryable<Foo> GetFoos([Service] ApplicationDbContext _context) =>
        _context.Foos;
}