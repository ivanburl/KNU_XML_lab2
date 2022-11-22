using System.Xml;
using Lab2.Builder;
using Lab2.Filter;

namespace Lab2.Search.impl;

public class XmlDomSearch<T> : IXmlSearchStrategy<T>
{
    private readonly IObjectContinuousBuilder<T> _continuousBuilder;
    private readonly XmlDocument _document;

    public XmlDomSearch(XmlDocument document, IObjectContinuousBuilder<T> continuousBuilder)
    {
        _document = document;
        _continuousBuilder = continuousBuilder;
    }

    public IList<T> SearchByFilter(ISearchFilter<T> filter)
    {
        XmlNode? node = _document.DocumentElement;
        if (node is null) return new List<T>();

        var found = new List<T>();

        foreach (XmlNode elem in node.ChildNodes)
        {
            if (elem.Attributes is null) continue;
            foreach (XmlAttribute attribute in elem.Attributes)
            {
                _continuousBuilder.SetAttribute(new KeyValuePair<string, string>(attribute.Name, attribute.Value));
            }

            var builtObject = _continuousBuilder.BuildObject();
            if (filter.IsValid(builtObject)) found.Add(builtObject);

            _continuousBuilder.CleanBuilderCache();
        }

        return found;
    }
}