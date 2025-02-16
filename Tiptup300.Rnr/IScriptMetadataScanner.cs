namespace Tiptup300.Rnr;

public interface IScriptMetadataScanner
{
   ScriptMetadata? ScanScriptFileForMetadata(string filePath);
}
