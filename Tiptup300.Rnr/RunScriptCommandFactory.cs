using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Tiptup300.Rnr;

public class RunScriptCommandFactory : IRunScriptCommandFactory
{
   public const string RNR_ARGS_PREFIX = "Rnr:";

   public RunScriptCommand Build(string[] commandArgs)
   {
      var fullCommand = string.Join(" ", commandArgs);
      if (string.IsNullOrEmpty(fullCommand))
      {
         throw new ArgumentException("Command cannot be null or empty", nameof(fullCommand));
      }
      var parts = commandArgs;
      if (parts.Length == 0)
      {
         throw new ArgumentException("Command must have at least one part", nameof(fullCommand));
      }

      // ScriptTag must be Alphanumeric, underscore, hyphen, or period.
      if (!Regex.IsMatch(parts[0], @"^[a-zA-Z0-9_.-]+$"))
      {
         throw new ArgumentException("Script tag must be alphanumeric, underscore, hyphen, or period", nameof(fullCommand));
      }
      var scriptTag = parts[0];

      // Args must be in the form "--Name Value" or "--Name \"Value with spaces\""

      var argStrs = parts.Skip(1).ToArray();
      var scriptArgs = new List<Arg>();
      var rnrArgs = new List<Arg>();
      if (argStrs.Length % 2 != 0)
      {
         throw new ArgumentException("Arguments must be in the form --Name Value", nameof(fullCommand));
      }
      for (int i = 0; i < argStrs.Length; i += 2)
      {
         if (!argStrs[i].StartsWith("--"))
         {
            throw new ArgumentException("Arguments must start with --", nameof(fullCommand));
         }
         var name = argStrs[i].Substring(2);
         var value = argStrs[i + 1];
         if ((name.StartsWith(RNR_ARGS_PREFIX)))
         {
            var rnrArgName = value.Substring(RNR_ARGS_PREFIX.Length);
            rnrArgs.Add(new Arg(rnrArgName, value));
         }
         else
         {
            scriptArgs.Add(new Arg(name, argStrs[i + 1]));
         }
      }

      return new RunScriptCommand
      {
         ScriptTag = scriptTag,
         ScriptArgs = new ScriptArgs() { Args = scriptArgs.ToImmutableArray() },
         RnrArgs = ImmutableArray<Arg>.Empty
      };
   }
}
