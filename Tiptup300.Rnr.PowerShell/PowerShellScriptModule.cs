namespace Tiptup300.Rnr.PowerShell;
public class PowerShellScriptModule : IScriptModule
{
   public IScriptRunner Runner => _runner;
   public IScriptMetadataScanner MetadataScanner => _metadataScanner;

   private readonly IScriptRunner _runner;
   private readonly IScriptMetadataScanner _metadataScanner;

   public PowerShellScriptModule(IScriptRunner runner, IScriptMetadataScanner metadataScanner)
   {
      _runner = runner;
      _metadataScanner = metadataScanner;
   }

}