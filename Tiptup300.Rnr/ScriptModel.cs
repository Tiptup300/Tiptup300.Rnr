namespace Tiptup300.Rnr;

public record struct ScriptModel
{
   public string Tag { get; init; }
   public string Title { get; init; }
   public string Path { get; init; }
   public string? Description { get; init; }
   public string? Usage { get; init; }
   public string? ScriptLocation { get; init; }
}