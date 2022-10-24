using System.Xml.Serialization;

namespace XmlParsesLib.Models;

public sealed class Category:TreeNode
{
  [XmlElement ("Name")]
  public string Name { get; set; } = string.Empty;

  [XmlElement (ElementName = "Book")]
  public HashSet<Book> Books { get; set; } = new HashSet<Book> ();
  public override string NodeName => $"Category : {Name}";

  protected override IEnumerable<INode> _children () => Books;
}