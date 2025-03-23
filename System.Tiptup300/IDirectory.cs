namespace System.Tiptup300;

using System;

public interface IDirectory
{
   bool Exists(string path);
   void CreateDirectory(string path);
   void Delete(string path, bool recursive);
   string[] GetFiles(string path);
   string[] GetFiles(string path, string searchPattern);
   string[] GetDirectories(string path);
   string[] GetDirectories(string path, string searchPattern);
   string[] GetFileSystemEntries(string path);
   string GetCurrentDirectory();
   void SetCurrentDirectory(string path);
   string GetDirectoryRoot(string path);
   string GetParent(string path);
   DateTime GetCreationTime(string path);
   void SetCreationTime(string path, DateTime creationTime);
   DateTime GetLastAccessTime(string path);
   void SetLastAccessTime(string path, DateTime lastAccessTime);
   DateTime GetLastWriteTime(string path);
   void SetLastWriteTime(string path, DateTime lastWriteTime);
}