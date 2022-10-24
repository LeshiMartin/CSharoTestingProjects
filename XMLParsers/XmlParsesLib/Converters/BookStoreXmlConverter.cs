
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using XmlParsesLib.Models;

namespace XmlParsesLib.Converters;



public class BookStoreXmlConverter
{

  public BookStore XmlSerializer ( string xmlPath )
  {
    using var fs = new FileStream (xmlPath, FileMode.Open);
    var serializer = new XmlSerializer (typeof (BookStore));
    return (BookStore) serializer.Deserialize (fs)!;
  }

  public BookStore Convert ( string xmlPath )
  {
    var store = new BookStore ();
    var reader = new XmlTextReader (xmlPath);
    while ( reader.Read () )
    {
      if ( reader.Name != "Category" )
        continue;
      store.Categories.Add (GetCategory (reader));
    }
    reader.Dispose ();
    return store;
  }

  private static Category GetCategory ( XmlTextReader reader )
  {
    var category = new Category ();
    while ( reader.Read () )
    {
      if ( reader.NodeType == XmlNodeType.EndElement )
        break;
      if ( reader.Name == "Book" )
        category.Books.Add (GetBook (reader));
      else if ( reader.Name == "Name" )
        category.Name = reader.ReadString ();
    }
    return category;

  }
  private static Book GetBook ( XmlTextReader reader )
  {

    var book = new Book ();
    while ( reader.Read () )
    {
      if ( reader.NodeType == XmlNodeType.EndElement )
        break;
      if ( reader.Name == "Title" )
        book.Title = reader.ReadString ();
      else if ( reader.Name == "Author" )
        book.Author = reader.ReadString ();
      else if ( reader.Name == "Price" )
      {
        var priceStr = reader.ReadString ();
        if ( double.TryParse (
          priceStr,
          NumberStyles.AllowDecimalPoint,
          NumberFormatInfo.InvariantInfo,
          out var price) )
          book.Price = price;
      }
    }
    return book;

  }

}


