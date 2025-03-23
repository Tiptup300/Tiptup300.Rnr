using System.Tiptup300;
using Microsoft.Extensions.DependencyInjection;
using Tiptup300.Rnr.Configuration;

namespace Tiptup300.Rnr.Hosting;

public interface IScriptModule
{
   IScriptRunner Runner { get; }
   IScriptMetadataScanner MetadataScanner { get; }
}
public class RnrAppHost
{
   private readonly IScriptModule _scriptModule;
   private readonly Action<IServiceCollection>? _registerServicesAction;

   public RnrAppHost(IScriptModule scriptModule, Action<IServiceCollection>? registerServicesAction = null)
   {
      _scriptModule = scriptModule;
      _registerServicesAction = registerServicesAction;
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
         .AddSingleton(_scriptModule.MetadataScanner)
         .AddSingleton(_scriptModule.Runner)
         .AddSingleton<IMissingScriptExplainer, MissingScriptExplainer>()
         .AddSingleton<IRunScriptCommandFactory, ScriptExecutionPayloadFactory>()
         .AddSingleton<IRnrConfigurationReader, RnrConfigurationReader>()
         .AddSingleton<IFile, FileWrapper>()
         ;

      _registerServicesAction?.Invoke(services);

      var serviceProvider = services.BuildServiceProvider();

      var rnrHost = serviceProvider.GetRequiredService<RnrApp>();
      rnrHost.Run();
   }
}
