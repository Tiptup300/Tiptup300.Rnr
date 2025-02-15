using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

namespace Tiptup300.Rnr;

public class MissingScriptExplainer : IMissingScriptExplainer
{
   private readonly ILogger<MissingScriptExplainer> _logger;

   public MissingScriptExplainer(ILogger<MissingScriptExplainer> logger)
   {
      _logger = logger;
   }

   public void ExplainMissingScript(string scriptTag, ImmutableArray<ScriptModel> scripts)
   {
      _logger.LogInformation($"Script '{scriptTag}' not found.");

      // print out similar scripts
      // break scripttag by period and compare each part to script tags for all scripts
      var scriptTagParts = scriptTag.Split('.');
      var similarScripts = scripts
         .Where(script => scriptTagParts.All(part => script.Tag.Contains(part)))
         .OrderBy(script => script.Tag)
         .ToArray();
      if (similarScripts.Length > 0)
      {
         _logger.LogInformation("Did you mean one of these?");
         foreach (var script in similarScripts)
         {
            _logger.LogInformation($"  {script.Tag}");
         }
      }
   }
}
