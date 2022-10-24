using System.Xml.Serialization;

namespace XmlParsesLib.Models;

public sealed class Book : TreeNode
{
    [XmlElement("Title")]
    public string Title { get; set; } = string.Empty;
    [XmlElement("Author")]
    public string Author { get; set; } = string.Empty;
    [XmlElement("Price")]
    public double Price { get; set; }
    public override string NodeName => $"Book : {Title}";

    protected override IEnumerable<INode> _children() => Array.Empty<INode>();

    public override string ToString() => $"Title : {Title};\nAutor : {Author};\nPrice : {Price}\n";
}