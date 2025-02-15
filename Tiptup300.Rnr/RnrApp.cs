using Tiptup300.Rnr.Configuration;

namespace Tiptup300.Rnr;

public class RnrApp
{
   private readonly IScriptScanner _scriptScanner;
   private readonly RnrConfiguration _rnrConfiguration;
   private readonly RunScriptCommand _rnrRunCommand;
   private readonly IMissingScriptExplainer _missingScriptExplainer;
   private readonly IScriptRunner _scriptRunner;

   public RnrApp(IScriptScanner scriptScanner, RnrConfiguration rnrConfiguration, RunScriptCommand rnrRunCommand, IMissingScriptExplainer missingScriptExplainer, IScriptRunner scriptRunner)
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
      ScriptModel? scriptToRun = _scriptScanner.GetScripts(_rnrConfiguration.ScriptLocations)
         .FirstOrDefault(script => script.Tag == _rnrRunCommand.ScriptTag);

      if (scriptToRun is null)
      {
         _missingScriptExplainer.ExplainMissingScript(_rnrRunCommand.ScriptTag, scripts);
         return;
      }
      _scriptRunner.Run(scriptToRun.Value, _rnrRunCommand);
   }
}
