using System.Collections.Immutable;

namespace Tiptup300.Rnr;

public record RunScriptCommand
{
   public string ScriptTag { get; init; }
   public ScriptArgs ScriptArgs { get; init; }
   public ImmutableArray<Arg> RnrArgs { get; init; }

   public RunScriptCommand(string scriptTag, ScriptArgs scriptArgs, ImmutableArray<Arg> rnrArgs)
   {
      ScriptTag = scriptTag;
      ScriptArgs = scriptArgs;
      RnrArgs = rnrArgs;
   }
}
