using Moq;

namespace Tiptup300.ScriptRunner.Tests;
internal class AppRunner
{
   public void RunApp()
   {
      var consoleWriterMock = new Mock<IConsoleWriter>();
      Tiptup300.ScriptRunner.ConsoleApplication.Program.ConsoleWriter = consoleWriterMock.Object;
      Tiptup300.ScriptRunner.ConsoleApplication.Program.Main(new string[] { });
   }
}
