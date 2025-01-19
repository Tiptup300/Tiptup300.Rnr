
using System.Collections.Immutable;

namespace Tiptup300.ScriptRunner.ConsoleApplication;

public class ScriptRunnerApp
{
   private ImmutableArray<Script> _scripts = ImmutableArray<Script>.Empty;

   public void AddScript(Script helloWorldScript)
   {
      _scripts = _scripts.Add(helloWorldScript);
   }

   public void RunScript(string tag)
   {
      var script = _scripts.FirstOrDefault(s => s.Tag == tag);
      if (script is null)
      {
         throw new NotImplementedException();
      }
      Console.WriteLine($"Running script '{tag}'...");
      Console.WriteLine(script.ScriptText);
   }
}
