using Tiptup300.Rnr.PowerShellScriptModule;

namespace Tiptup300.Rnr.Tests;

[TestClass]
public class Tests
{
   [TestMethod]
   public void DoesDo()
   {
      using var powershellModuleHost = new PowershellModuleHost();
      var powershellModule = powershellModuleHost.Build();
      var rnrAppHost = new RnrAppHost(powershellModule);

      rnrAppHost.Run(["DoThing"]);
   }
}
