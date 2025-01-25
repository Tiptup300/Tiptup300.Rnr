using Microsoft.Extensions.DependencyInjection;
using Tiptup300.Rnr.Host;

namespace Tiptup300.Rnr.ConsoleApplication;

public class Program
{
   public static Action<IServiceCollection>? AddServices;

   public static async Task Main(string[] args)
   {
      var services = new RnrServiceCollection();
      AddServices?.Invoke(services);
      var rnrHostFactory = new RnrHostFactory(services);
      var rnrHost = rnrHostFactory.Build();
      await rnrHost.RunAsync();
   }
}
