namespace StringBenchmark;
[MemoryDiagnoser]
[Orderer (BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringRunner
{
  readonly int StringCount = 100;
  [Benchmark]
  public void StringPlusOperator ()
  {
    var stringArr = new string[ StringCount ];
    for ( int i = 0; i < StringCount; i++ )
    {
      stringArr[ i ] = "Hello";
    }

    var str = string.Concat (stringArr);
  }
  [Benchmark]
  public void StringInterpolation ()
  {
    string s = null;
    for ( int i = 0; i < StringCount; i++ )
    {
      s = $"{s}Hello";
    }
  }
  [Benchmark]
  public void StringBuilder ()
  {
    var sb = new StringBuilder ();
    for ( int i = 0; i < StringCount; i++ )
    {
      sb.Append ("Hello");
    }

    var res = sb.ToString ();
  }
}
