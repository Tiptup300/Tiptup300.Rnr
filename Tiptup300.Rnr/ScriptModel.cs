namespace Tiptup300.Rnr;

public record ScriptModel
{
   public string Tag { get; init; }
   public string Title { get; init; }
   public string FilePath { get; init; }
   public string? Description { get; init; }
   public string? Usage { get; init; }
   public string? DirectoryPath { get; set; }

   public ScriptModel(string tag, string title, string path, string? description, string? usage, string? scriptDirectory = null)
   {
      Tag = tag;
      Title = title;
      FilePath = path;
      Description = description;
      Usage = usage;
      DirectoryPath = scriptDirectory;
   }
}