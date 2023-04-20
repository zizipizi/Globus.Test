using System.Threading;
using System.Threading.Tasks;
using Globus.Test.Application.Commands.InitializeProduct;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Globus.Test.Api.BackgroundServices;

public class ProductInitializerHostedService : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ProductInitializerHostedService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var scope = _serviceScopeFactory.CreateAsyncScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        await mediator.Send(new InitializeProductCommand(), cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}