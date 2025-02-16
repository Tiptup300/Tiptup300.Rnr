using Tiptup300.Rnr.PowerShellScriptModule;

namespace Tiptup300.Rnr.ConsoleApplication;

public class Program
{
   public static void Main(string[] args)
   {
      var powershellModuleHost = new PowershellModuleHost();
      var powershellModule = powershellModuleHost.Build();
      var rnrAppHost = new RnrAppHost(powershellModule);

      rnrAppHost.Run(args);
   }
}
