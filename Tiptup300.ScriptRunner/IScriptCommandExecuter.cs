
namespace Tiptup300.ScriptRunner;

public interface IScriptCommandExecuter
{
   void Execute(ScriptCommand scriptCommand);
}
public class ScriptCommandExecuter : IScriptCommandExecuter
{
   private readonly IConsoleWriter _consoleWriter;
   public ScriptCommandExecuter(IConsoleWriter consoleWriter)
   {
      _consoleWriter = consoleWriter;
   }
   public void Execute(ScriptCommand scriptCommand)
   {
      _consoleWriter.WriteLine($"Executing script command: {scriptCommand.Command}");
   }
}