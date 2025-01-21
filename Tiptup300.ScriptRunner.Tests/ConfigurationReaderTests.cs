using FluentAssertions;
using Moq;
using Tiptup300.ScriptRunner.Configuration;
using Tiptup300.ScriptRunner.Integrations;

namespace Tiptup300.ScriptRunner.Tests;

[TestClass]
public class ConfigurationReaderTests
{
   private Mock<IFileSystemIntegration> _fileSystemIntegration;
   private ConfigurationReader _configurationReader;

   [TestInitialize]
   public void Setup()
   {
      // Setup
      _fileSystemIntegration = new Mock<IFileSystemIntegration>();
      _configurationReader = new ConfigurationReader(_fileSystemIntegration.Object);
   }

   [TestMethod]
   public void CanReadConfiguration()
   {
      // Arrange
      var configuration = "{ \"scriptLocations\": [ \"C:\\\\Directory\\\\\" ] }";
      _fileSystemIntegration.Setup(
         fs => fs.DirectoryExists(@"C:\Directory\")
      ).Returns(true);
      // fs integration should be mocked to return getfullpath
      _fileSystemIntegration.Setup(
         fs => fs.GetFullPath(@"C:\Directory\")
      ).Returns(@"C:\Directory\");


      // Act
      var result = _configurationReader.Read(configuration);

      // Assert
      result.ScriptLocations.Should().SatisfyRespectively(
         scriptLocation => scriptLocation.FullPath.Should().Be(@"C:\Directory\")
      );
   }
}
