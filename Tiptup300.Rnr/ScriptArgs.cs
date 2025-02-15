using System.Collections.Immutable;

namespace Tiptup300.Rnr;

public record struct ScriptArgs
{
   public ImmutableArray<Arg> Args { get; init; }
}
