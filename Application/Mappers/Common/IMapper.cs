namespace Application.Mappers.Common;

public interface IMapper<in TSource, out TDestination>
    where TSource : class
    where TDestination : notnull
{
    TDestination Map(TSource source);

    IReadOnlyList<TDestination> Map(IReadOnlyList<TSource> sources);
}
