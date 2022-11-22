using System.Xml.Linq;
using Lab2.Builder;
using Lab2.Filter;

namespace Lab2.Search.impl;

public class XmlLinqSearch<T> : IXmlSearchStrategy<T>
{
    private readonly IObjectContinuousBuilder<T> _continuousBuilder;
    private readonly XDocument _document;

    public XmlLinqSearch(XDocument document, IObjectContinuousBuilder<T> continuousBuilder)
    {
        _document = document;
        _continuousBuilder = continuousBuilder;
    }

    public IList<T> SearchByFilter(ISearchFilter<T> filter)
    {
        var result = _document.Descendants()
            .Select(i =>
            {
                i.Attributes().ToList()
                    .ForEach(j =>
                    {
                        _continuousBuilder.SetAttribute(new KeyValuePair<string, string>(j.Name.LocalName, j.Value));
                    });
                return _continuousBuilder.BuildObject();
            })
            .Where(filter.IsValid)
            .ToList();
        return result;
    }
}