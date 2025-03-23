namespace System.Tiptup300;

using System;
using System.IO;

public class DirectoryWrapper : IDirectory
{
   public bool Exists(string path) => Directory.Exists(path);
   public void CreateDirectory(string path) => Directory.CreateDirectory(path);
   public void Delete(string path, bool recursive) => Directory.Delete(path, recursive);
   public string[] GetFiles(string path) => Directory.GetFiles(path);
   public string[] GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);
   public string[] GetDirectories(string path) => Directory.GetDirectories(path);
   public string[] GetDirectories(string path, string searchPattern) => Directory.GetDirectories(path, searchPattern);
   public string[] GetFileSystemEntries(string path) => Directory.GetFileSystemEntries(path);
   public string GetCurrentDirectory() => Directory.GetCurrentDirectory();
   public void SetCurrentDirectory(string path) => Directory.SetCurrentDirectory(path);
   public string GetDirectoryRoot(string path) => Directory.GetDirectoryRoot(path);
   public string GetParent(string path) => Directory.GetParent(path)?.FullName;
   public DateTime GetCreationTime(string path) => Directory.GetCreationTime(path);
   public void SetCreationTime(string path, DateTime creationTime) => Directory.SetCreationTime(path, creationTime);
   public DateTime GetLastAccessTime(string path) => Directory.GetLastAccessTime(path);
   public void SetLastAccessTime(string path, DateTime lastAccessTime) => Directory.SetLastAccessTime(path, lastAccessTime);
   public DateTime GetLastWriteTime(string path) => Directory.GetLastWriteTime(path);
   public void SetLastWriteTime(string path, DateTime lastWriteTime) => Directory.SetLastWriteTime(path, lastWriteTime);
}

