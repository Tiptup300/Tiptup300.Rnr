using Moq;
using Tiptup300.ScriptRunner.ConsoleApplication;

namespace Tiptup300.ScriptRunner.Tests;

[TestClass]
public sealed class Test1
{
   private Mock<IConsoleWriter> _mockConsoleWriter;
   private Mock<IScriptCommandExecuter> _mockScriptCommandExecuter;

   [TestInitialize]
   public void Setup()
   {
      _mockConsoleWriter = new Mock<IConsoleWriter>();
      _mockScriptCommandExecuter = new Mock<IScriptCommandExecuter>();
      Program.ConsoleWriter = _mockConsoleWriter.Object;
      Program.ScriptCommandExecuter = _mockScriptCommandExecuter.Object;
   }

   [TestMethod]
   public void CanRunHelloWorldScript()
   {
      // Arrange
      var commandStr = "Scripts.HelloWorld";

      // Act
      Program.Main(commandStr.Split(' '));

      // Assert
      _mockConsoleWriter.Verify(
         writer => writer.WriteLine("Hello World"), Times.Once
      );
   }

   [TestMethod]
   public void CanRunAScriptWithRequiredArgs()
   {
      // Arrange
      var commandStr = "Script.HelloToPerson --Person John";

      // Act
      Program.Main(commandStr.Split(' '));

      // Assert
      _mockScriptCommandExecuter.Verify(
         executer => executer.Execute(new ScriptCommand(commandStr)), Times.Once
      );
      _mockConsoleWriter.Verify(
         writer => writer.WriteLine("Hello John"), Times.Once
      );
   }
}
