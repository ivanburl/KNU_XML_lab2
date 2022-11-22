namespace Lab2.Filter;

public interface ISearchFilter<in T>
{
    bool IsValid(T obj);
}