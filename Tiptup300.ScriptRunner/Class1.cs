namespace Tiptup300.ScriptRunner;

public class Script
{
   public string Tag { get; private set; }
   public string ScriptText { get; private set; }

   public Script(string tag, string scriptText)
   {
      this.Tag = tag;
      this.ScriptText = scriptText;
   }
}