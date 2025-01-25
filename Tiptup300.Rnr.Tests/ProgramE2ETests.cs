//using Tiptup300.Rnr.ConsoleApplication;

//namespace Tiptup300.Rnr.Tests;

//[TestClass]
//public sealed class ProgramE2ETests
//{
//   [TestMethod]
//   public async Task CanRunHelloWorldScript()
//   {
//      // Arrange
//      string[] commandStr = ["Scripts.HelloWorld"];
//      var rnrApp = new RnrApp(_mockConsoleWriter, _mockScriptCommandExecuter);

//      // Act
//      await Program.Main(commandStr);

//      // Assert
//      A.CallTo(() => _mockConsoleWriter.WriteLine("Hello World")).MustHaveHappenedOnceExactly();
//   }

//   [TestMethod]
//   public async Task CanRunAScriptWithRequiredArgs()
//   {
//      // Arrange
//      string[] commandStr = ["Script.HelloToPerson", "--Person", "John"];

//      // Act
//      await Program.Main(commandStr);

//      // Assert
//      A.CallTo(() => _mockScriptCommandExecuter.Execute(new ScriptCommand(commandStr))).MustHaveHappenedOnceExactly();
//      A.CallTo(() => _mockConsoleWriter.WriteLine("Hello John")).MustHaveHappenedOnceExactly();
//   }
//}
