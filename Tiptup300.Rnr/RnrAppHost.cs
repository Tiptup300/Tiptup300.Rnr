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
         .AddLogging()
         .AddSingleton<RnrApp>()

         // configurations
         .AddSingleton((sp) => sp.GetRequiredService<IRnrConfigurationReader>().ReadConfiguration())
         .AddSingleton((sp) => sp.GetRequiredService<IRunScriptCommandFactory>().Build(args))

         .AddSingleton<IScriptScanner, ScriptScanner>()
         .AddSingleton<IScriptMetadataScanner>(_scriptModule.MetadataScanner)
         .AddSingleton<IScriptRunner>(_scriptModule.Runner)
         .AddSingleton<IMissingScriptExplainer, MissingScriptExplainer>()
         .AddSingleton<IRunScriptCommandFactory, RunScriptCommandFactory>()
         .AddSingleton<IRnrConfigurationReader, RnrConfigurationReader>()
         ;

      var serviceProvider = services.BuildServiceProvider();

      var rnrHost = serviceProvider.GetRequiredService<RnrApp>();
      rnrHost.Run();
   }
}
