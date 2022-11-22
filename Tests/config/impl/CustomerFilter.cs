using Lab2.Filter;

namespace Tests.config.impl;

public class CustomerFilter : ISearchFilter<Customer>
{
    public bool IsValid(Customer obj)
    {
        return obj.CompanyName is null or "Great Lakes Food Market";
    }
}