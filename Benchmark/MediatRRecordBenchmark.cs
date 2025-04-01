using System.Reflection;
using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

public class MediatRRecordBenchmark
{
    public MediatRRecordBenchmark()
    {
        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatRRecordBenchmark).Assembly));

        var serviceProvider = services.BuildServiceProvider();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    private readonly IMediator _mediator;

    [Benchmark]
    public async Task ClassRequestBenchmark()
    {
        for (var i = 0; i < 100000; i++)
        {
            _ = await _mediator.Send(new ClassRequest(Guid.NewGuid(), Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()));
        }
    }

    [Benchmark]
    public async Task RecordRequestBenchmark()
    {
        for (var i = 0; i < 100000; i++)
        {
            _ = await _mediator.Send(new RecordRequest(Guid.NewGuid(), Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()));
        }
    }
}

public class ClassRequest(Guid id, string name, string description) : IRequest<Guid>
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string Description { get; } = description;
}

public sealed record RecordRequest(Guid Id, string Name, string Description) : IRequest<Guid>
{
}

public class ClassRequestHandler : IRequestHandler<ClassRequest, Guid>
{
    public Task<Guid> Handle(ClassRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Id);
    }
}

public class RecordRequestHandler : IRequestHandler<RecordRequest, Guid>
{
    public Task<Guid> Handle(RecordRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Id);
    }
}