namespace Tiptup300.Rnr.Hosting;

public record AppArg
{
   public string Name { get; }
   public string Value { get; }

   public AppArg(string name, string value)
   {
      Name = !string.IsNullOrEmpty(name) 
         ? name
         : throw new ArgumentException("Argument name cannot be null or empty", nameof(name));

      Value = !string.IsNullOrEmpty(value)
         ? value
         : throw new ArgumentException("Argument value cannot be null or empty", nameof(value));
   }
}

