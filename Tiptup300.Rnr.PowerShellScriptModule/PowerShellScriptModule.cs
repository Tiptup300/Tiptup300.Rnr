namespace Tiptup300.Rnr.PowerShellScriptModule;
public class PowerShellScriptModule : IScriptModule
{
   public IScriptRunner Runner => _runner;
   public IScriptMetadataScanner MetadataScanner => _metadataScanner;

   private readonly PowerShellScriptRunner _runner;
   private readonly PowerShellScriptMetadataScanner _metadataScanner;

   public PowerShellScriptModule(PowerShellScriptRunner runner, PowerShellScriptMetadataScanner metadataScanner)
   {
      _runner = runner;
      _metadataScanner = metadataScanner;
   }

}