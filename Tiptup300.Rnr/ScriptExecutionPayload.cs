using System.Collections.Immutable;
using Tiptup300.Rnr.Hosting;

namespace Tiptup300.Rnr;

public class ScriptParameterCollection
{
   private readonly ImmutableArray<ScriptParameter> _parameters;

   public ScriptParameterCollection(ImmutableArray<ScriptParameter> parameters)
   {
      _parameters = parameters;
   }

   public ScriptParameter this[int index]
      => _parameters[index];

   public ScriptParameter? this[string name] 
      => _parameters.FirstOrDefault(p => p.Name == name);
}

public record ScriptParameter
{
   public string Name { get; private init; }
   public string Value { get; private init; }

   public ScriptParameter(string name, string value)
   {
      Name = name;
      Value = value;
   }
}

public record ScriptExecutionPayload
{
   public string ScriptTag { get; private init; }
   public ScriptParameterCollection Parameters { get; private init; }
   public ImmutableArray<AppArg> RnrArgs { get; private init; }

   public ScriptExecutionPayload(
      string scriptTag, 
      IEnumerable<ScriptParameter> parameters, ImmutableArray<AppArg> rnrArgs)
   {
      ScriptTag = scriptTag;
      Parameters = new ScriptParameterCollection(parameters.ToImmutableArray());
      RnrArgs = rnrArgs;
   }
}
