namespace Tiptup300.Rnr;

public record Arg
{
   public string Name { get; }
   public string? Value { get; }

   public Arg(string name, string? value)
   {
      if (string.IsNullOrEmpty(name))
      {
         throw new ArgumentException("Argument name cannot be null or empty", nameof(name));
      }
      Name = name;
      Value = value;
   }
}


