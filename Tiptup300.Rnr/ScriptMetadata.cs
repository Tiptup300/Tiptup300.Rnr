namespace Tiptup300.Rnr;

public record struct ScriptMetadata
{
   public string? Title { get; init; }
   public string? Description { get; init; }
   public string? TagOverride { get; init; }
   public string? Usage { get; init; }
}
