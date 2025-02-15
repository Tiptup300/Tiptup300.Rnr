using Microsoft.Extensions.DependencyInjection;
using Tiptup300.Rnr.Configuration;

namespace Tiptup300.Rnr;

public interface IScriptModule
{
   IScriptRunner Runner { get; }
   IScriptMetadataScanner MetadataScanner { get; }
}
public class RnrAppHost
{
   private readonly IScriptModule _scriptModule;

   public RnrAppHost(IScriptModule scriptModule)
   {
      _scriptModule = scriptModule;
   }

   public void Run(string[] args)
   {
      var services = new ServiceCollection()
         .RegisterSingleton<IScriptScanner, ScriptScanner>()
         .RegisterSingleton<IScriptMetadataScanner>(_scriptModule.MetadataScanner)
         .RegisterSingleton<IScriptRunner>(_scriptModule.Runner)
         .RegisterSingleton<IMissingScriptExplainer, MissingScriptExplainer>()
         .RegisterSingleton<IRunScriptCommandFactory, RunScriptCommandFactory>()
         .RegisterSingleton((sp) => sp.GetRequiredService<IRnrConfigurationReader>().ReadConfiguration())
         .RegisterSingleton((sp) => sp.GetRequiredService<IRunScriptCommandFactory>().Build(args));

      var serviceProvider = services.BuildServiceProvider();

      var rnrHost = serviceProvider.GetRequiredService<RnrApp>();
      rnrHost.Run();
   }
}
