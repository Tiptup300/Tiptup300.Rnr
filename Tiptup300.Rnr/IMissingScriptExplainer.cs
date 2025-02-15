using System.Collections.Immutable;

namespace Tiptup300.Rnr;

public interface IMissingScriptExplainer
{
   void ExplainMissingScript(string scriptTag, ImmutableArray<ScriptModel> scripts);
}
