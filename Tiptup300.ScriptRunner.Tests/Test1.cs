using Tiptup300.ScriptRunner.ConsoleApplication;

namespace Tiptup300.ScriptRunner.Tests;





[TestClass]
public sealed class Test1
{
   [TestMethod]
   public void CanRunScriptThatExists()
   {
      var helloWorldScript = new Script(
         tag: "Scripts.SayHelloWorld",
         scriptText: "Write-Host 'Hello, World!'"
      );
      var scriptRunner = new ScriptRunnerApp();
      scriptRunner.AddScript(helloWorldScript);
      scriptRunner.RunScript(helloWorldScript.Tag);
   }
}
