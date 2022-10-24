// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using StringBenchmark;

Console.WriteLine ("Hello, World!");
BenchmarkRunner.Run<GettingSingleInstanceRunner> ();
