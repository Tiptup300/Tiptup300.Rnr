using System.Collections;
using System.Management.Automation;
using System.Tiptup300;

namespace Tiptup300.Rnr.PowerShellScriptModule;

public class PowerShellRnrScript
{
   public string? Title { get; private init; }
   public string? Description { get; private init; }
   public string? Tag { get; private init; }
   public string? Usage { get; private init; }
   public ScriptBlock? Function { get; private init; }

   public PowerShellRnrScript(string? title, string? description, string? tag, string? usage, ScriptBlock? function)
   {
      Title = title;
      Description = description;
      Tag = tag;
      Usage = usage;
      Function = function;
   }
}

public class PowerShellRnrScriptLoader
{
   private PowerShell _ps;
   private IFile _file;

   public PowerShellRnrScriptLoader(PowerShell ps, IFile file)
   {
      _ps = ps;
      _file = file;
   }

   public PowerShellRnrScript LoadScript(string filePath)
   {
      var scriptData = _file.ReadAllText(filePath);
      _ps.AddScript(scriptData);
      var result = _ps.Invoke()[0].BaseObject as Hashtable;
      if (result is null)
      {
         throw new Exception("Script metadata not found.");
      }
      return new PowerShellRnrScript(
         title: result.TryGet<string>("Title"),
         description: result.TryGet<string>("Description"),
         tag: result.TryGet<string>("Tag"),
         usage: result.TryGet<string>("Usage"),
         function: result.TryGet<ScriptBlock>("Function")
      );
   }
}

public class PowerShellScriptMetadataScanner : IScriptMetadataScanner
{
   private readonly PowerShellRnrScriptLoader _scriptLoader;

   public PowerShellScriptMetadataScanner(PowerShellRnrScriptLoader powerShellRnrScriptLoader)
   {
      _scriptLoader = powerShellRnrScriptLoader;
   }

   public ScriptMetadata? ScanScriptFileForMetadata(string filePath)
   {
      var script = _scriptLoader.LoadScript(filePath);


      return new ScriptMetadata(
         hasImplementation: script.Function is not null,
         title: script.Title,
         description: script.Description,
         tagOverride: script.Tag,
         usage: script.Usage
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