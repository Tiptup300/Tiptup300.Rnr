using System.Collections.Immutable;

namespace Tiptup300.Rnr;

public interface IScriptScanner
{
   ImmutableArray<ScriptModel> GetScripts(ImmutableArray<string> scriptLocations);
}
