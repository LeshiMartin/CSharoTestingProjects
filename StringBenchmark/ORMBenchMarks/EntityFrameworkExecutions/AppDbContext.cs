using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMBenchMarks.EntityFrameworkExecutions;
internal class AppDbContext : DbContext
{
  public AppDbContext () : base ()
  {

  }


  protected override void OnModelCreating ( ModelBuilder modelBuilder )
  {

    modelBuilder.Entity<TestTable> (b => b.ToTable ("TestTable"));
  }

  protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
  {
    optionsBuilder.UseSqlServer (ConfigProvider.ConnectionString);
    base.OnConfiguring (optionsBuilder);
  }

  public DbSet<TestTable> TestTable { get; set; }
}
