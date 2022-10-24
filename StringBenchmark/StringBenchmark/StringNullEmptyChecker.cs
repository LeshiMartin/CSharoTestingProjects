using BenchmarkDotNet.Order;

namespace StringBenchmark;

[MemoryDiagnoser]
[Orderer (SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringNullEmptyChecker
{
  string str = "";
  [Benchmark (Baseline = true)]
  public bool StandardNullOrEmpty ()
  {
    var isEmpty = string.IsNullOrEmpty (str);
    return isEmpty;
  }

  [Benchmark]
  public bool NullCheck ()
  {
    var isEmpty = str == null || str == "";
    return isEmpty;
  }

  [Benchmark]
  public bool NullCheckLength ()
  {
    var isEmpty = str == null || str.Length == 0;
    return isEmpty;
  }

  [Benchmark]
  public bool OnlyNullCheck ()
  {
    var isEmpty = str == null;
    return isEmpty;
  }


}
