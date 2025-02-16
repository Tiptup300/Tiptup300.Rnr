using Microsoft.Extensions.DependencyInjection;

namespace Tiptup300.Rnr.PowerShellScriptModule;
public class PowershellModuleHost
{
   public PowerShellScriptModule Build()
   {
      var services = new ServiceCollection()
         .AddSingleton<PowerShellScriptRunner>()
         .AddSingleton<PowerShellScriptModule>()
         .AddSingleton<PowerShellScriptMetadataScanner>();

      var serviceProvider = services.BuildServiceProvider();
      var scriptModule = serviceProvider.GetRequiredService<PowerShellScriptModule>();
      return scriptModule;
   }
}
