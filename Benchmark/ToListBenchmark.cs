using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MemoryDiagnoser]
public class ToListBenchmark
{
    private readonly List<string> _data = [];
    
    
    [Params(1, 10, 100)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < Size; i++)
        {
            _data.Add(Guid.NewGuid().ToString());
        }
    }
    
    [Benchmark(Baseline = true)]
    public void ToList()
    {
      var x = _data.Select(x => x).ToList();
    }
    
    [Benchmark]
    public void CollectionSpread()
    {
      List<string> x = [.. _data.Select(x => x)];
    }
}