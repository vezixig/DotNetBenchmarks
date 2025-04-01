using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class RecordBenchmark
{
    public record NormalRecord(int id, string name, string description);

    public sealed record SealedRecord(int id, string name, string description);
    
    [Benchmark]
    public void NewNormalRecord()
    {
        for (var i = 0; i < 1000000; i++)
        {
            _ = new NormalRecord(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }

    [Benchmark]
    public void NewSealedRecord()
    {
        for (var i = 0; i < 1000000; i++)
        {
            _ = new SealedRecord(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }
}
