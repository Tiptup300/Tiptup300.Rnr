using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Tiptup300.ScriptRunner;

public record ScriptCommand
{
   public string Command { get; }
   public string ScriptTag { get; }
   public ImmutableArray<Arg> Args { get; }

   public ScriptCommand(string command)
   {
      if (string.IsNullOrEmpty(command))
      {
         throw new ArgumentException("Command cannot be null or empty", nameof(command));
      }
      var parts = command.Split(' ');
      if (parts.Length == 0)
      {
         throw new ArgumentException("Command must have at least one part", nameof(command));
      }
      Command = command;

      // ScriptTag must be Alphanumeric, underscore, hyphen, or period.
      if (!Regex.IsMatch(parts[0], @"^[a-zA-Z0-9_.-]+$"))
      {
         throw new ArgumentException("Script tag must be alphanumeric, underscore, hyphen, or period", nameof(command));
      }
      ScriptTag = parts[0];

      // Args must be in the form "--Name Value" or "--Name \"Value with spaces\""

      var argStrs = parts.Skip(1).ToArray();
      var args = new List<Arg>();
      if (argStrs.Length % 2 != 0)
      {
         throw new ArgumentException("Arguments must be in the form --Name Value", nameof(command));
      }
      for (int i = 0; i < argStrs.Length; i += 2)
      {
         if (!argStrs[i].StartsWith("--"))
         {
            throw new ArgumentException("Arguments must start with --", nameof(command));
         }
         args.Add(new Arg(argStrs[i].Substring(2), argStrs[i + 1]));
      }

      Args = args.ToImmutableArray();
   }
}
