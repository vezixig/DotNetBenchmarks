using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MemoryDiagnoser]
public class ToListBenchmark
{
    private readonly List<string> _data = [];
    
    
    [Params(1000, 10000, 100000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < Size; i++)
        {
            _data.Add(Guid.NewGuid().ToString());
        }
    }
    
    [Benchmark]
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