using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class ListHashsetBenchmark
{
    private HashSet<int> hashy = Enumerable.Range(1, 10).ToHashSet();
    
    private List<int> listy = Enumerable.Range(1, 10).ToList();
    
    private Random random = new Random(DateTime.Now.Millisecond);
    
    [Benchmark]
    public void ListContains()
    {
        for (var i = 0; i < 10; i++)
        {
            var rnd = random.Next(1, 1001);
            _ = listy.Contains(rnd);
        }
    }
    
    [Benchmark]
    public void ListToHashsestContains()
    {
        var listyhashy = listy.ToHashSet();
        for (var i = 0; i < 10; i++)
        {
            var rnd = random.Next(1, 1001);
            _ = listyhashy.Contains(rnd);
        }
    }

    
    [Benchmark]
    public void HashSetContains()
    {
        for (var i = 0; i < 10; i++)
        {
            var rnd = random.Next(1, 1001);
            _ = hashy.Contains(rnd);
        }
    }
}