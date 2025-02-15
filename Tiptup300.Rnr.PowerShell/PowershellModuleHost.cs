using Microsoft.Extensions.DependencyInjection;

namespace Tiptup300.Rnr.PowerShell;
public class PowershellModuleHost
{
   public PowerShellScriptModule Build()
   {
      var services = new ServiceCollection()
         .RegisterSingleton<PowerShellScriptRunner>()
         .RegisterSingleton<PowerShellScriptModule>()
         .RegisterSingleton<PowerShellScriptMetadataScanner>();

      var serviceProvider = services.BuildServiceProvider();
      var scriptModule = serviceProvider.GetRequiredService<PowerShellScriptModule>();
      return scriptModule;

   }
}
