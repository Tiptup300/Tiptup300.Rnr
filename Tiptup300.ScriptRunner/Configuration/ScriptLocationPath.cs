using Tiptup300.ScriptRunner.Integrations;

namespace Tiptup300.ScriptRunner.Configuration;

public class ScriptDirectory
{
   public string FullPath { get; private set; }

   private ScriptDirectory(string fullPath)
   {
      FullPath = fullPath;
   }

   public static ScriptDirectory Build(string path, IFileSystemIntegration fileSystemIntegration)
   {
      if (!fileSystemIntegration.DirectoryExists(path))
      {
         throw new DirectoryNotFoundException($"Directory not found: {path}");
      }

      var fullPath = fileSystemIntegration.GetFullPath(path);

      return new ScriptDirectory(fullPath);
   }
}
