namespace Tiptup300.Rnr.PowerShell;

public class PowerShellRuntime : IDisposable
{
   private System.Management.Automation.PowerShell _powerShell;

   public PowerShellRuntime()
   {
      _powerShell = System.Management.Automation.PowerShell.Create();
   }

   internal void Visit(Action<System.Management.Automation.PowerShell> action)
   {
      action(_powerShell);
   }

   public void Dispose()
   {
      _powerShell.Dispose();
   }
}