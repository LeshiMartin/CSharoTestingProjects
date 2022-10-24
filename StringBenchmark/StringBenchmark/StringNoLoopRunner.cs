namespace StringBenchmark;

[MemoryDiagnoser]
[Orderer (BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringNoLoopRunner
{
  [Benchmark (Baseline = true)]
  public void PlusOperator ()
  {
    var s1 = "Hello";
    var s2 = " World";
    var s3 = ".";
    var s4 = "How";
    var s5 = " are";
    var s6 = " you";
    var s7 = "?";
    var s8 = s1 + s2 + s3 + s4 + s5 + s6 + s7;
  }

  [Benchmark]
  public void StringInterpolation ()
  {
    var s1 = "Hello";
    var s2 = " World";
    var s3 = ".";
    var s4 = "How";
    var s5 = " are";
    var s6 = " you";
    var s7 = "?";
    var s8 = $"{s1}{s2}{s3}{s4}{s5}{s6}{s7}";
  }

  [Benchmark]
  public void StringBuilder ()
  {
    var sb = new StringBuilder ();
    sb.Append ("Hello");
    sb.Append (" World");
    sb.Append (".");
    sb.Append ("How");
    sb.Append (" are");
    sb.Append (" you");
    sb.Append ("?");
    var res = sb.ToString ();
  }

  [Benchmark]
  public void NewString ()
  {

    var s8 = new string (new char[] { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '.', 'H', 'o', 'w', ' ', 'a', 'r', 'e', ' ', 'y', 'o', 'u', '?' });
  }
}
