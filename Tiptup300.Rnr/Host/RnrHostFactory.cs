using Microsoft.Extensions.DependencyInjection;

namespace Tiptup300.Rnr.Host;

public class RnrHostFactory
{
   private readonly IServiceCollection _services;

   public RnrHostFactory(IServiceCollection services)
   {
      _services = services;
   }

   public IRnrHost Build()
   {
      return _services.BuildServiceProvider()
         .GetRequiredService<IRnrHost>();
   }
}
