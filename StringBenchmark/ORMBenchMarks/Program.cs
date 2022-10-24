// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ORMBenchMarks;

//Console.WriteLine ("Hello, World!");
//async Task TestRun ()
//{
//  var runner = new OrmRunner ();
//  await runner.GetAllUsingEfCore ();
//  await runner.GetAllUsingAdoNet ();
//  await runner.GetAllUsingDapper ();
//}


//await TestRun ();
BenchmarkRunner.Run<OrmRunner> ();
