namespace Lab2.Builder;

public interface IObjectContinuousBuilder<out T>
{
    void SetAttribute(KeyValuePair<string, string> pair);
    T BuildObject();
    void CleanBuilderCache();
}