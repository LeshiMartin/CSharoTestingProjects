using System.Xml.Serialization;

namespace XmlParsesLib.Models;
[XmlRoot]
public sealed class BookStore:TreeNode
{

  [XmlElement (ElementName = "Category")]
  public HashSet<Category> Categories { get; set; } = new HashSet<Category> ();
  public override string NodeName { get; } = "Bookstore";

  protected override IEnumerable<INode> _children () => Categories;
}
