using FluentAssertions;
using Moq;
using Tiptup300.ScriptRunner.Configuration;
using Tiptup300.ScriptRunner.Integrations;

namespace Tiptup300.ScriptRunner.Tests;

[TestClass]
public class ScriptLocaterTests
{
   private Mock<IFileSystemIntegration>? _fileSystemIntegration;
   private ScriptLocater? _scriptLocater;

   [TestInitialize]
   public void Setup()
   {
      // Setup
      _fileSystemIntegration = new Mock<IFileSystemIntegration>();
      _scriptLocater = new ScriptLocater(_fileSystemIntegration.Object);
   }

   [TestMethod]
   public void CanBuildScriptDirectory()
   {
      // Arrange
      _fileSystemIntegration!.Setup(
         fs => fs.DirectoryExists(@"C:\Directory\")).Returns(true);
      _fileSystemIntegration.Setup(
        fs => fs.GetFullPath(@"C:\Directory\")).Returns(@"C:\Directory\");

      // Act
      var result = ScriptDirectory.Build(@"C:\Directory\", _fileSystemIntegration!.Object);

      // Assert
      result.FullPath.Should().Be(@"C:\Directory\");
   }

   [TestMethod]
   public void CanBuildScriptFile()
   {
      // Arrange
      _fileSystemIntegration!.Setup(
         fs => fs.FileExists(@"C:\Directory\HelloWorld.cs.ps1")).Returns(true);
      // Act
      var result = ScriptFile.Build(@"C:\Directory\HelloWorld.cs.ps1", _fileSystemIntegration!.Object);
      // Assert
      result.FullPath.Should().Be(@"C:\Directory\HelloWorld.cs.ps1");
   }

   [TestMethod]
   public void CanGetScriptsFromScriptLocationPath()
   {
      // Arrange
      _fileSystemIntegration!.Setup(
         fs => fs.FileExists(@"C:\Directory\HelloWorld.cs.ps1")).Returns(true);

      _fileSystemIntegration!.Setup(
         fs => fs.DirectoryExists(@"C:\Directory\")).Returns(true);

      _fileSystemIntegration.Setup(
        fs => fs.GetFullPath(@"C:\Directory\")).Returns(@"C:\Directory\");

      _fileSystemIntegration!.Setup(
         fs => fs.GetFilesFromPath(@"C:\Directory\")
      ).Returns(new string[] { @"C:\Directory\HelloWorld.cs.ps1" });

      // Act
      var scriptLocationPath = ScriptDirectory.Build(@"C:\Directory\", _fileSystemIntegration!.Object);
      var result = _scriptLocater!.GetScripts(scriptLocationPath);

      // Assert
      result.Should().SatisfyRespectively(
         script => script.FullPath.Should().Be(@"C:\Directory\HelloWorld.cs.ps1")
      );
   }
}
