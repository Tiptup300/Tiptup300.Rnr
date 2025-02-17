namespace Tiptup300.Rnr.PowerShellScriptModule;
public class PowerShellScriptRunner : IScriptRunner
{
   private readonly PowerShellRnrScriptLoader _scriptLoader;

   public PowerShellScriptRunner(PowerShellRnrScriptLoader scriptLoader)
   {
      _scriptLoader = scriptLoader;
   }

   public void Run(ScriptModel script, RunScriptCommand runScriptCommand)
   {
      if (script.DirectoryPath is null)
      {
         throw new Exception("Script location not found.");
      }
      var psScript = _scriptLoader.LoadScript(script.FilePath);
      if (psScript.Function is null)
      {
         throw new Exception("Script function not found.");
      }
      var result = psScript.Function.Invoke();
   }
}
