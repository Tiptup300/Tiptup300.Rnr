using System.Collections.Immutable;

namespace Tiptup300.ScriptRunner.Configuration;

public class AppConfiguration
{
   public ImmutableArray<ScriptDirectory> ScriptLocations { get; private set; }

   public AppConfiguration(ImmutableArray<ScriptDirectory> scriptLocations)
   {
      ScriptLocations = scriptLocations;
   }
}
