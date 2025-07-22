using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class ToListBenchmark
{

    public ToListBenchmark()
    {
        for (var i = 0; i < 1000; i++)
        {
            Data.Add(Guid.NewGuid().ToString());
        }
    }
    
    private readonly List<string> Data = [];
    
    [Benchmark]
    public void ToList()
    {
      var x = Data.Select(x => x).ToList();
    }
    
    [Benchmark]
    public void CollectionSpread()
    {
      List<string> x = [.. Data.Select(x => x)];
    }
}