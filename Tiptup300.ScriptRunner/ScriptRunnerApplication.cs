namespace Tiptup300.ScriptRunner;

public class ScriptRunnerApplication
{
   private readonly IConsoleWriter _consoleWriter;
   private readonly IScriptCommandExecuter _scriptCommandExecuter;

   public ScriptRunnerApplication(IConsoleWriter consoleWriter, IScriptCommandExecuter scriptCommandExecuter)
   {
      _consoleWriter = consoleWriter;
      _scriptCommandExecuter = scriptCommandExecuter;
   }

   public void Run(string args)
   {
      var scriptCommand = new ScriptCommand(args);
      _scriptCommandExecuter.Execute(scriptCommand);
   }
}
