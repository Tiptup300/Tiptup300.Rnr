namespace System.Tiptup300;

using System;
using System.IO;

public class FileWrapper : IFile
{
   public bool Exists(string filePath) 
      => File.Exists(filePath);
   public void Delete(string filePath) 
      => File.Delete(filePath);
   public void Copy(string sourceFileName, string destFileName, bool overwrite) 
      => File.Copy(sourceFileName, destFileName, overwrite);
   public void Move(string sourceFileName, string destFileName) 
      => File.Move(sourceFileName, destFileName);
   public string ReadAllText(string filePath) 
      => File.ReadAllText(filePath);
   public void WriteAllText(string filePath, string contents) 
      => File.WriteAllText(filePath, contents);
   public byte[] ReadAllBytes(string filePath) 
      => File.ReadAllBytes(filePath);
   public void WriteAllBytes(string filePath, byte[] bytes) 
      => File.WriteAllBytes(filePath, bytes);
   public string[] ReadAllLines(string filePath) 
      => File.ReadAllLines(filePath);
   public void WriteAllLines(string filePath, string[] lines) 
      => File.WriteAllLines(filePath, lines);
   public FileStream Open(string filePath, FileMode mode, FileAccess access, FileShare share) 
      => File.Open(filePath, mode, access, share);
   public FileAttributes GetAttributes(string filePath) 
      => File.GetAttributes(filePath);
   public void SetAttributes(string filePath, FileAttributes attributes) 
      => File.SetAttributes(filePath, attributes);
   public DateTime GetCreationTime(string filePath) 
      => File.GetCreationTime(filePath);
   public void SetCreationTime(string filePath, DateTime creationTime) 
      => File.SetCreationTime(filePath, creationTime);
   public DateTime GetLastAccessTime(string filePath) 
      => File.GetLastAccessTime(filePath);
   public void SetLastAccessTime(string filePath, DateTime lastAccessTime) 
      => File.SetLastAccessTime(filePath, lastAccessTime);
   public DateTime GetLastWriteTime(string filePath) 
      => File.GetLastWriteTime(filePath);
   public void SetLastWriteTime(string filePath, DateTime lastWriteTime) 
      => File.SetLastWriteTime(filePath, lastWriteTime);
}
