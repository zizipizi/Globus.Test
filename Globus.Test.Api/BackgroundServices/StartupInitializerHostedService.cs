using System.Threading;
using System.Threading.Tasks;
using Globus.Test.Application.Commands.InitializeProduct;
using Globus.Test.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Globus.Test.Api.BackgroundServices;

public class StartupInitializerHostedService : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public StartupInitializerHostedService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(new InitializeProductCommand(), cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}