using Lab2.Filter;

namespace Lab2.Search;

public interface IXmlSearchStrategy<T>
{
    IList<T> SearchByFilter(ISearchFilter<T> filter);
}