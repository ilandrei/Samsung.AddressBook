using System.Linq.Expressions;

namespace Samsung.AddressBook.Common.LinqExtensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> WhereIfTrue<TSource>(
        this IQueryable<TSource> source,
        bool condition,
        Expression<Func<TSource, bool>> predicate)
    {
        return condition == false ? source : source.Where(predicate);
    }

    public static IQueryable<TSource> WhereIfNotNull<TSource>(
        this IQueryable<TSource> source,
        dynamic? toCheckNull,
        Expression<Func<TSource, bool>> predicate)
    {
        return toCheckNull == null ? source : source.Where(predicate);
    }

}