using System.Xml;
using System.Xml.Linq;
using Lab2.Search.impl;
using Lab2.Transform;
using Tests.config.impl;

namespace Tests;

public class Tests
{
    private XmlReader _reader;

    private const string Input = @"C:\Users\burluiva\Documents\KNU\OOP\Lab2\Tests\config\resources\test.xml";
    private const string Output = @"C:\Users\burluiva\Documents\KNU\OOP\Lab2\Tests\config\resources\test.html";
    private const string Style = @"C:\Users\burluiva\Documents\KNU\OOP\Lab2\Tests\config\resources\test.xsl";
    [SetUp]
    public void Setup()
    {
        _reader = new XmlTextReader(Input);
    }

    [Test]
    public void  BuilderTest()
    {
        var a = new CustomerBuilder();
        a.SetAttribute(new KeyValuePair<string, string>("CompanyName", "ABOBUS"));
        a.SetAttribute(new KeyValuePair<string, string>("PostalCode", "123"));
        var res = a.BuildObject();
        Console.WriteLine(res);
    }
    
    [Test]
    public void AlgoDomTest()
    {
        var docXml = new XmlDocument();
        docXml.Load(_reader);
        var algo = new XmlDomSearch<Customer>(docXml, new CustomerBuilder());
        var res = algo.SearchByFilter(new CustomerFilter());
        res.ToList().ForEach(Console.WriteLine);
    }
    
    [Test]
    public void AlgoSaxTest()
    {
        var algo = new XmlSaxSearch<Customer>(_reader, new CustomerBuilder());
        var res = algo.SearchByFilter(new CustomerFilter());
        res.ToList().ForEach(Console.WriteLine);
    }
    
    [Test]
    public void AlgoLinqTest()
    {
        var xDocument = XDocument.Load(_reader);
        var algo = new XmlLinqSearch<Customer>(xDocument, new CustomerBuilder());
        var res = algo.SearchByFilter(new CustomerFilter());
        res.ToList().ForEach(Console.WriteLine);
    }

    [Test]
    public void ConvertToHTML()
    {
        var file = File.Create(Output);
        var writer = XmlWriter.Create(file);
        var style = new XmlTextReader(Style);
        XmlTransformer.Transform(style, _reader, writer);
    }
}