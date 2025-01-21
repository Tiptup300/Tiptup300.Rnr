using System.Collections.Immutable;

namespace Tiptup300.ScriptRunner.Configuration;

public interface IScriptLocater
{
   ImmutableArray<ScriptFile> GetScripts(ScriptDirectory scriptLocationPath);
}
