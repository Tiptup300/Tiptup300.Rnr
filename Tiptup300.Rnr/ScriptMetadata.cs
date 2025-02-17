namespace Tiptup300.Rnr;

public record struct ScriptMetadata
{
   public bool HasImplementation { get; private init; }
   public string? Title { get; private init; }
   public string? Description { get; private init; }
   public string? TagOverride { get; private init; }
   public string? Usage { get; private init; }

   public ScriptMetadata(bool hasImplementation, string? title, string? description, string? tagOverride, string? usage)
   {
      HasImplementation = hasImplementation;
      Title = title;
      Description = description;
      TagOverride = tagOverride;
      Usage = usage;
   }
}