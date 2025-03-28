﻿using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Timers;
using System.Tiptup300;

namespace Tiptup300.Rnr.Configuration;

public interface IRnrConfigurationReader
{
   RnrConfiguration ReadConfiguration();
}
public class RnrConfigurationReader : IRnrConfigurationReader
{
   private readonly ILogger<RnrConfigurationReader> _logger;
   private readonly IFile _file;

   public RnrConfigurationReader(ILogger<RnrConfigurationReader> logger, IFile file)
   {
      _logger = logger;
      _file = file;
   }

   public RnrConfiguration ReadConfiguration()
   {
      RnrConfiguration output;

      try
      {
         // get configuration from from windows file location
         // $HOME/rnr.config.json
         // we're not using the Integration
         // and $HOME isnt a real thing we have to ask windows for the
         // actual location of the home directory
         var homeDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
         var configurationFilePath = System.IO.Path.Combine(homeDirectory, "rnr.config.json");

         if (!_file.Exists(configurationFilePath))
         {
            _logger.LogError($"No configuration file found at `{configurationFilePath}`");
            return GenerateDefault();
         }
         var fileDataJson = _file.ReadAllText(configurationFilePath);
         var fileData = System.Text.Json.JsonSerializer.Deserialize<RnrConfigurationFileDataV1>(fileDataJson);
         if (fileData == null)
         {
            _logger.LogError("Invalid configuration data in file ");
            return GenerateDefault();
         }
         if (fileData.ScriptLocations == null)
         {
            _logger.LogError("Invalid configuration data in file ");
            return GenerateDefault();
         }
         if (fileData.ScriptLocations.Length == 0)
         {
            _logger.LogError("Invalid configuration data in file ");
            return GenerateDefault();
         }
         output = new RnrConfiguration(
            scriptLocations: fileData.ScriptLocations.ToImmutableArray()
         );
      }
      catch (Exception ex)
      {
         _logger.LogError(ex, "Failed to read configuration.");
         return GenerateDefault();
      }
      return output;
   }

   private RnrConfiguration GenerateDefault()
   {
      var applicationDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
      var applicationScriptsDirectory = applicationDirectory is null ? null : System.IO.Path.Combine(applicationDirectory, "RnrScripts");

      var homeDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
      var homeScriptsDirectory = homeDirectory is null ? null : System.IO.Path.Combine(homeDirectory, "RnrScripts");

      return new RnrConfiguration(
         scriptLocations: new string?[]
         {
         applicationScriptsDirectory,
         homeScriptsDirectory
         }.OfType<string>().ToImmutableArray()
      );
   }

   private class RnrConfigurationFileDataV1
   {
      public string[]? ScriptLocations { get; init; }
   }
}