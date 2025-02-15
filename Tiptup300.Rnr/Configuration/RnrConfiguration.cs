using System.Collections.Immutable;

namespace Tiptup300.Rnr.Configuration;

public record struct RnrConfiguration
{
   public ImmutableArray<string> ScriptLocations { get; init; }
}