namespace Tests.config.impl;

public class Customer
{
    public string? CompanyName { get; set; }
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public long? PostalCode { get; set; }
    public string? Country { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(CompanyName)}: {CompanyName}, {nameof(ContactName)}: {ContactName}, {nameof(ContactTitle)}: {ContactTitle}, {nameof(Phone)}: {Phone}, {nameof(Address)}: {Address}, {nameof(City)}: {City}, {nameof(Region)}: {Region}, {nameof(PostalCode)}: {PostalCode}, {nameof(Country)}: {Country}";
    }
}