using System.Xml;
using Lab2.Builder;
using Lab2.Filter;

namespace Lab2.Search.impl;

public class XmlSaxSearch<T> : IXmlSearchStrategy<T>
{
    private readonly IObjectContinuousBuilder<T> _continuousBuilder;
    private readonly XmlReader _xmlTextReader;

    public XmlSaxSearch(XmlReader xmlTextReader, IObjectContinuousBuilder<T> continuousBuilder)
    {
        _xmlTextReader = xmlTextReader;
        _continuousBuilder = continuousBuilder;
    }

    public IList<T> SearchByFilter(ISearchFilter<T> filter)
    {
        IList<T> res = new List<T>();
        while (_xmlTextReader.Read())
            if (_xmlTextReader.HasAttributes)
            {
                var buildFlag = true;
                while (_xmlTextReader.MoveToNextAttribute())
                {
                    _continuousBuilder.SetAttribute(new KeyValuePair<string, string>(_xmlTextReader.Name,
                        _xmlTextReader.Value));
                    var tmpObject = _continuousBuilder.BuildObject();
                    if (!filter.IsValid(tmpObject))
                    {
                        buildFlag = false;
                        _continuousBuilder.CleanBuilderCache();
                        break;
                    }
                }

                if (buildFlag)
                {
                    res.Add(_continuousBuilder.BuildObject());
                    _continuousBuilder.CleanBuilderCache();
                }
            }

        return res;
    }
}