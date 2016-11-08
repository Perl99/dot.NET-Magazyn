using System.Data.Entity;
using GameStore.Domain.Concrete;

public static class DBContextExtensions
{
    public static void DeleteAll<T>(this EFDbContext context)
        where T : class
    {
        foreach (var p in context.Set<T>())
        {
            context.Entry(p).State = EntityState.Deleted;
        }
    }
}