// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using Benchmark;


BenchmarkRunner.Run<MediatRRecordBenchmark>();







