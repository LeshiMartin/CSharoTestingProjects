using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ORMBenchMarks.DapperExecutions;
internal class DapperQuery
{
  private static readonly string Query = "SELECT * FROM [dbo].[TestTable]";

  public async Task<IEnumerable<TestTable>> ExecuteAsync ()
  {
    await using var connection = new SqlConnection (ConfigProvider.ConnectionString);
    return await connection.QueryAsync<TestTable> (Query);
  }
}
