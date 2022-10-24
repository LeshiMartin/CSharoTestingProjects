using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMBenchMarks.AdoNetExecutions;
internal class AdoNetQuery
{
  private static readonly string SelectQuery = "SELECT * FROM [dbo].[TestTable]";

  public async Task<IEnumerable<TestTable>> ExecuteAsync ()
  {
    var connection = new SqlConnection (ConfigProvider.ConnectionString);
    try
    {
      connection.Open ();
      var command = connection.CreateCommand ();
      command.CommandType = System.Data.CommandType.Text;
      command.CommandText = SelectQuery;

      var result = await command.ExecuteReaderAsync (System.Data.CommandBehavior.CloseConnection);
      return MapTestTable (result);

    }
    finally
    {

      //connection.Close ();
    }

  }

  private static IEnumerable<TestTable> MapTestTable ( DbDataReader dbDataReader )
  {
    var table = new TestTable ();
    while ( dbDataReader.Read () )
    {
      table.Id = (int) dbDataReader[ 0 ]; //dbDataReader.GetInt32 (0);
      table.TimeStamp = (DateTime) dbDataReader[ 1 ];//dbDataReader.GetDateTime (1);
      table.TestValue = (int) dbDataReader[ 2 ]; //dbDataReader.GetInt32 (2);
      yield return table;
    }
  }
}
