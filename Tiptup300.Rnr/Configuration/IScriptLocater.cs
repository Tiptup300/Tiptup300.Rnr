using System.Collections.Immutable;

namespace Tiptup300.Rnr.Configuration;

public interface IScriptLocater
{
   ImmutableArray<ScriptFile> GetScripts(ScriptDirectory scriptLocationPath);
}
