using System.Collections;
using System.Management.Automation;

namespace Tiptup300.Rnr.PowerShellScriptModule;
public class PowerShellScriptMetadataScanner : IScriptMetadataScanner
{
   public ScriptMetadata? ScanScriptFileForMetadata(string filePath)
   {
      var scriptData = File.ReadAllText(filePath);

      using PowerShell ps = PowerShell.Create();
      ps.AddScript(scriptData);

      var result = ps.Invoke()[0].BaseObject as Hashtable;

      if(result is null)
      {
         return null;
      }

      return new ScriptMetadata(
         HasImplementation: result.Has<ScriptBlock>("Function"),
         Title: result.TryGet<string>("Title"),
         Description: result.TryGet<string>("Description"),
         TagOverride: result.TryGet<string>("Tag"),
         Usage: result.TryGet<string>("Usage")
      );
   }
}

public static class HashtableExtensions
{
   public static T? TryGet<T>(this Hashtable hashtable, string key) where T : class
   {
      return hashtable.ContainsKey(key) ? hashtable[key] as T : null;
   }
   public static bool Has<T>(this Hashtable hashtable, string key) where T : class
   {
      return hashtable.ContainsKey(key) && hashtable is T;
   }
}