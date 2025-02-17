using System.Collections.Immutable;

namespace Tiptup300.Rnr.Configuration;

public record RnrConfiguration
{
   public ImmutableArray<string> ScriptLocations { get; init; }

   public RnrConfiguration(ImmutableArray<string> scriptLocations)
   {
      ScriptLocations = scriptLocations;
   }
}