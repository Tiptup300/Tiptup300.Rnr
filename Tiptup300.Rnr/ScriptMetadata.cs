namespace Tiptup300.Rnr;

public record ScriptMetadata
   (
   bool HasImplementation,
   string? Title = null,
   string? Description = null,
   string? TagOverride = null,
   string? Usage = null
   );
