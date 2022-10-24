

namespace StringBenchmark;
[MemoryDiagnoser]
[Orderer (SummaryOrderPolicy.FastestToSlowest)]
public class GettingSingleInstanceRunner
{

  IEnumerable<string> Strings = Enumerable.Range (0, 100).Select (i => i.ToString ());

  [Benchmark (Baseline = true)]
  public string SingleOperator ()
  {
    var result = Strings.Single (x => x == "60");
    return result;
  }


  [Benchmark]
  public string FirstOperator ()
  {
    var result = Strings.First (x => x == "60");
    return result;
  }

  [Benchmark]
  public string ForLoopOperator ()
  {
    for ( int i = 0; i < Strings.Count (); i++ )
    {
      var currlet = Strings.ElementAt (i);
      if ( currlet == "60" )
      {
        return currlet;
      }
    }
    return null;
  }

  [Benchmark]
  public string ForEachOperator ()
  {
    foreach ( var item in Strings )
    {
      if ( item == "60" )
        return item;
    }
    return null;
  }


  [Benchmark]
  public string LinqOperator ()
  {
    var result = Strings.Where (x => x == "60").First ();
    return result;
  }

  [Benchmark]
  public string LinqOperator2 ()
  {
    var result = Strings.Where (x => x == "60").Single ();
    return result;
  }

  [Benchmark]
  public string ToArrayAndLoop ()
  {
    var arr = Strings.ToArray ();
    for ( int i = 0; i < arr.Length; i++ )
    {
      var currlet = arr[ i ];
      if ( currlet == "60" )
      {
        return currlet;
      }
    }
    return null;
  }

}
