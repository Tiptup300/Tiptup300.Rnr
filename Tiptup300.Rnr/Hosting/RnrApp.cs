using Tiptup300.Rnr.Configuration;

namespace Tiptup300.Rnr.Hosting;

public class RnrApp
{
   private readonly IScriptScanner _scriptScanner;
   private readonly RnrConfiguration _rnrConfiguration;
   private readonly ScriptExecutionPayload _rnrRunCommand;
   private readonly IMissingScriptExplainer _missingScriptExplainer;
   private readonly IScriptRunner _scriptRunner;

   public RnrApp(IScriptScanner scriptScanner, RnrConfiguration rnrConfiguration, ScriptExecutionPayload rnrRunCommand, IMissingScriptExplainer missingScriptExplainer, IScriptRunner scriptRunner)
   {
      _scriptScanner = scriptScanner;
      _rnrConfiguration = rnrConfiguration;
      _rnrRunCommand = rnrRunCommand;
      _missingScriptExplainer = missingScriptExplainer;
      _scriptRunner = scriptRunner;
   }

   public void Run()
   {
      var scripts = _scriptScanner.GetScripts(_rnrConfiguration.ScriptLocations);
      ScriptModel? result = _scriptScanner.GetScripts(_rnrConfiguration.ScriptLocations)
         .FirstOrDefault(script => script.Tag == _rnrRunCommand.ScriptTag);

      if (result is null)
      {
         _missingScriptExplainer.ExplainMissingScript(_rnrRunCommand.ScriptTag, scripts);
         return;
      }
      var scriptToRun = result;

      _scriptRunner.Run(scriptToRun, _rnrRunCommand);
   }
}
