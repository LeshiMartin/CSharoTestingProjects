using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.EntityFrameworkCore;
using ORMBenchMarks.AdoNetExecutions;
using ORMBenchMarks.DapperExecutions;
using ORMBenchMarks.EntityFrameworkExecutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMBenchMarks;

[MemoryDiagnoser]
[Orderer (SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class OrmRunner
{
  private readonly AppDbContext _appDbContext = new AppDbContext ();
  private readonly AdoNetQuery _adoExecuter = new AdoNetQuery ();
  private readonly DapperQuery _dapperQuery = new DapperQuery ();

  [Benchmark (Baseline = true)]
  public async Task GetAllUsingEfCore ()
  {
    var result = await _appDbContext.TestTable.ToArrayAsync ();
  }

  [Benchmark]
  public async Task GetAllUsingAdoNet ()
  {
    var result = (await _adoExecuter.ExecuteAsync ()).ToArray ();
  }

  [Benchmark]
  public async Task GetAllUsingDapper ()
  {
    var result = (await _dapperQuery.ExecuteAsync ()).ToArray ();
  }
}
