// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using System.Xml.Linq;
using XmlParsesLib.Converters;
using XmlParsesLib.Models;
using XmlRunnerConsole;

Console.WriteLine("Hello, World!");

var xDoc = XDocument.Load("D:\\Projects\\TestProjects\\C#\\XMLParsers\\test.xml");

var bookStore = xDoc.Element("BookStore");

var constructBook = (XElement element) => new Book()
{
    Author = element.Element("Author")!.Value,
    Price = double.Parse(element.Element("Price")!.Value),
    Title = element.Element("Title")!.Value

};
var getBooks = (XElement element) => element.Elements(nameof(Book)).Select(constructBook);
var categories = bookStore!.Elements(nameof(Category)).Select(x => new Category
{
    Name =  x.Element("Name")!.Value,
    Books = getBooks(x).ToHashSet()
});

foreach ( var item in categories )
{
    Console.WriteLine(item.NodeName);
    foreach ( var book in item.Books )
    {
        Console.WriteLine(book.ToString());
    }
}


//Console.WriteLine(books);
//BenchmarkRunner.Run<BookStoreRunner> ();
//var store = BookStoreXmlConverter.Convert ("test.xml");
//using var fs = new FileStream ("test.xml", FileMode.Open);
//var serializer = new XmlSerializer (typeof (BookStore));
//var store1 = (BookStore) serializer.Deserialize (fs);
//Console.WriteLine (store.ToString ());
