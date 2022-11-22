using System.Xml;
using System.Xml.Xsl;

namespace Lab2.Transform;

public static class XmlTransformer
{
    public static void Transform(in XmlReader style, in XmlReader input, in XmlWriter writer)
    {
        XslCompiledTransform xct = new XslCompiledTransform();
        xct.Load(style);
        xct.Transform(input, writer);
    }
}