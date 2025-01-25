using Tiptup300.Rnr.Configuration;
using Tiptup300.Rnr.Integrations;

namespace Tiptup300.Rnr.Tests;

[TestClass]
public class ConfigurationReaderTests
{

   [TestMethod]
   public void CanReadConfiguration()
   {
      // Arrange
      var _fileSystemIntegration = A.Fake<IFileSystemIntegration>();
      var _configurationReader = new ConfigurationReader(_fileSystemIntegration);
      var configuration = "{ \"scriptLocations\": [ \"C:\\\\Directory\\\\\" ] }";
      A.CallTo(() => _fileSystemIntegration.DirectoryExists(@"C:\Directory\")).Returns(true);
      A.CallTo(() => _fileSystemIntegration.GetFullPath(@"C:\Directory\")).Returns(@"C:\Directory\");

      // Act
      var result = _configurationReader.Read(configuration);

      // Assert
      result.ScriptLocations.Should().SatisfyRespectively(
         scriptLocation => scriptLocation.FullPath.Should().Be(@"C:\Directory\")
      );
   }
}
