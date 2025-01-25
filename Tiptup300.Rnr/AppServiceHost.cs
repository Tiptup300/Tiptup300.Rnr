using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tiptup300.Rnr;

public interface IAppService
{
   Task RunAsync(CancellationToken cancellationToken);
}

public class AppServiceHost
{
   private readonly IServiceProvider _serviceProvider;
   private readonly ILogger<AppServiceHost> _logger;

   public AppServiceHost(IServiceProvider serviceProvider, ILogger<AppServiceHost> logger)
   {
      _serviceProvider = serviceProvider;
      _logger = logger;
   }

   // run a new AppServiceFactory instance within it's own scope
   public async Task RunAsync(CancellationToken cancellationToken)
   {
      using var scope = _serviceProvider.CreateScope();
      var appService = scope.ServiceProvider.GetRequiredService<IAppService>();
      await appService.RunAsync(cancellationToken);
   }
}
