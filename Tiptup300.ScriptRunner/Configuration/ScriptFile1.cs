using Tiptup300.ScriptRunner.Integrations;

namespace Tiptup300.ScriptRunner.Configuration;

public class ScriptFile
{
   public string FullPath { get; private set; }

   private ScriptFile(string fullPath)
   {
      FullPath = fullPath;
   }

   public static ScriptFile Build(string filePath, IFileSystemIntegration io)
   {
      if (!io.FileExists(filePath))
      {
         throw new ArgumentException("File does not exist");
      }
      return new ScriptFile(filePath);
   }
}
