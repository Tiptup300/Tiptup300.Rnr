namespace System.Tiptup300;

using System;
using System.IO;

public interface IFile
{
   bool Exists(string filePath);
   void Delete(string filePath);
   void Copy(string sourceFileName, string destFileName, bool overwrite);
   void Move(string sourceFileName, string destFileName);
   string ReadAllText(string filePath);
   void WriteAllText(string filePath, string contents);
   byte[] ReadAllBytes(string filePath);
   void WriteAllBytes(string filePath, byte[] bytes);
   string[] ReadAllLines(string filePath);
   void WriteAllLines(string filePath, string[] lines);
   FileStream Open(string filePath, FileMode mode, FileAccess access, FileShare share);
   FileAttributes GetAttributes(string filePath);
   void SetAttributes(string filePath, FileAttributes attributes);
   DateTime GetCreationTime(string filePath);
   void SetCreationTime(string filePath, DateTime creationTime);
   DateTime GetLastAccessTime(string filePath);
   void SetLastAccessTime(string filePath, DateTime lastAccessTime);
   DateTime GetLastWriteTime(string filePath);
   void SetLastWriteTime(string filePath, DateTime lastWriteTime);
}
