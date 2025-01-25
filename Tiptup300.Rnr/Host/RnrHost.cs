namespace Tiptup300.Rnr.Host;

public class RnrHost : IRnrHost
{
   private readonly IRnrServiceFactory _rnrServiceFactory;
   private readonly IRnrConfigurationService _rnrConfigurationService;

   public RnrHost(IRnrServiceFactory rnrServiceFactory, IRnrConfigurationService rnrConfigurationService)
   {
      _rnrServiceFactory = rnrServiceFactory;
      _rnrConfigurationService = rnrConfigurationService;
   }

   public async Task RunAsync()
   {
      var config = _rnrConfigurationService.GetConfiguration();
      _rnrServiceFactory.Build(config);
   }
}
