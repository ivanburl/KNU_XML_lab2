using System.ComponentModel;
using Lab2.Builder;

namespace Tests.config.impl;

public class CustomerBuilder : IObjectContinuousBuilder<Customer>
{
    private readonly IDictionary<string, string> _attributes
        = new Dictionary<string, string>();

    public void SetAttribute(KeyValuePair<string, string> pair)
    {
        _attributes[pair.Key] = pair.Value;
    }

    public Customer BuildObject()
    {
        var res = new Customer();
        var propertyInfos =
            typeof(Customer).GetProperties();

        foreach (var i in propertyInfos)
            if (_attributes.ContainsKey(i.Name))
            {
                var val = _attributes[i.Name];
                i.SetMethod?.Invoke(res,
                    i.PropertyType == typeof(long?) ? new object?[] { long.Parse(val) } : new object?[] { val });
            }

        return res;
    }

    public void CleanBuilderCache()
    {
        _attributes.Clear();
    }
}