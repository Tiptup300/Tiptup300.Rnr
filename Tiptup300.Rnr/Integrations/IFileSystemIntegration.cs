namespace Tiptup300.Rnr.Integrations;

public interface IFileSystemIntegration
{
   string GetFullPath(string path);
   string[] GetFilesFromPath(string path);
   bool DirectoryExists(string path);
   bool FileExists(string fullPath);
}
