using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMBenchMarks;
internal static class ConfigProvider
{
  public static string ConnectionString
  {
    get
    {
      return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BenchmarkTesting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
  }
}
