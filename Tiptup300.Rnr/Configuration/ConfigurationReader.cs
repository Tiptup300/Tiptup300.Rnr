using System.Collections.Immutable;
using Tiptup300.Rnr.Integrations;

namespace Tiptup300.Rnr.Configuration;

public class ConfigurationReader : IConfigurationReader
{
   private readonly IFileSystemIntegration _fileSystemIntegration;

   public ConfigurationReader(IFileSystemIntegration fileSystemIntegration)
   {
      _fileSystemIntegration = fileSystemIntegration;
   }

   public AppConfiguration Read(string configuration)
   {
      AppConfiguration output;

      var prototype = System.Text.Json.JsonSerializer.Deserialize<AppConfigurationPrototype>(configuration);
      var scriptLocations = prototype!.scriptLocations.Select(s => ScriptDirectory.Build(s, _fileSystemIntegration)).ToImmutableArray();
      output = new AppConfiguration(scriptLocations);

      return output;
   }

   private class AppConfigurationPrototype
   {
      public string[] scriptLocations { get; set; }
   }
}