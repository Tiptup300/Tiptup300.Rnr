using System.Collections.Immutable;

namespace Tiptup300.Rnr.Configuration;

public sealed record RnrConfiguration
{
   public ImmutableArray<string> ScriptLocations { get; init; }

   public RnrConfiguration(ImmutableArray<string> scriptLocations)
   {
      ScriptLocations = scriptLocations;
   }

   public bool Equals(RnrConfiguration? other)
   {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ScriptLocations.SequenceEqual(other.ScriptLocations);
   }

   public override int GetHashCode()
   {
      return ScriptLocations.GetHashCode();
   }
}