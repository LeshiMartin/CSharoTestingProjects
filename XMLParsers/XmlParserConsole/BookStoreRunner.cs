using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using XmlParsesLib.Converters;
using XmlParsesLib.Models;

namespace XmlRunnerConsole;

[MemoryDiagnoser]
[Orderer (SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BookStoreRunner
{
  private readonly string xmlPath = @"D:\Projects\TestProjects\C#\XMLParsers\test.xml";
  private readonly BookStoreXmlConverter _converter = new BookStoreXmlConverter ();

  [Benchmark (Baseline = true)]

  public BookStore XmlSerializer ()
  {
    return _converter.XmlSerializer (xmlPath);
  }

  [Benchmark]

  public BookStore XmlReaderConvert ()
  {
    return _converter.Convert (xmlPath);
  }

}
