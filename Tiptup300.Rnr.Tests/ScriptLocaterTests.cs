using Tiptup300.Rnr.Configuration;
using Tiptup300.Rnr.Integrations;

namespace Tiptup300.Rnr.Tests;

[TestClass]
public class ScriptLocaterTests
{

   [TestMethod]
   public void CanBuildScriptDirectory()
   {
      // Arrange

      var _fileSystemIntegration = A.Fake<IFileSystemIntegration>();
      A.CallTo(() => _fileSystemIntegration.DirectoryExists(@"C:\Directory\")).Returns(true);
      A.CallTo(() => _fileSystemIntegration.GetFullPath(@"C:\Directory\")).Returns(@"C:\Directory\");
      var _scriptLocater = new ScriptLocater(_fileSystemIntegration);

      // Act
      var result = ScriptDirectory.Build(@"C:\Directory\", _fileSystemIntegration);

      // Assert
      result.FullPath.Should().Be(@"C:\Directory\");
   }

   [TestMethod]
   public void CanBuildScriptFile()
   {
      // Arrange
      var _fileSystemIntegration = A.Fake<IFileSystemIntegration>();
      A.CallTo(() => _fileSystemIntegration.FileExists(@"C:\Directory\HelloWorld.cs.ps1")).Returns(true);

      // Act
      var result = ScriptFile.Build(@"C:\Directory\HelloWorld.cs.ps1", _fileSystemIntegration);
      // Assert
      result.FullPath.Should().Be(@"C:\Directory\HelloWorld.cs.ps1");
   }

   [TestMethod]
   public void CanGetScriptsFromScriptLocationPath()
   {
      // Arrange
      var _fileSystemIntegration = A.Fake<IFileSystemIntegration>();
      A.CallTo(() => _fileSystemIntegration.FileExists(@"C:\Directory\HelloWorld.cs.ps1")).Returns(true);
      A.CallTo(() => _fileSystemIntegration.DirectoryExists(@"C:\Directory\")).Returns(true);
      A.CallTo(() => _fileSystemIntegration.GetFullPath(@"C:\Directory\")).Returns(@"C:\Directory\");
      A.CallTo(() => _fileSystemIntegration.GetFilesFromPath(@"C:\Directory\")).Returns([@"C:\Directory\HelloWorld.cs.ps1"]);
      var _scriptLocater = new ScriptLocater(_fileSystemIntegration);

      // Act
      var scriptLocationPath = ScriptDirectory.Build(@"C:\Directory\", _fileSystemIntegration);
      var result = _scriptLocater.GetScripts(scriptLocationPath);

      // Assert
      result.Should().SatisfyRespectively(
         script => script.FullPath.Should().Be(@"C:\Directory\HelloWorld.cs.ps1")
      );
   }
}
