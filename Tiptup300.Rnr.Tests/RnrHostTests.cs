using Microsoft.Extensions.DependencyInjection;
using Tiptup300.Rnr.Host;

namespace Tiptup300.Rnr.Tests;



[TestClass]
public class RnrHostTests
{
   [TestMethod]
   public void CanBuildRnrHost()
   {
      // Arrange
      var services = new RnrServiceCollection()
         .AddSingleton<IRnrHost, RnrHost>()
         .AddSingleton(A.Fake<IRnrConfigurationService>())
         .AddSingleton(A.Fake<IRnrServiceFactory>());
      var rnrHostFactory = new RnrHostFactory(services);

      // Act
      var rnrHost = rnrHostFactory.Build();

      // Assert
      rnrHost.Should().BeOfType<RnrHost>();
   }

   [TestMethod]
   public async Task DoesStartServiceOnFirstRun()
   {
      // Arrange
      var config = new RnrServiceConfiguration();
      var rnrServiceFactory = A.Fake<IRnrServiceFactory>();
      var rnrConfigurationService = A.Fake<IRnrConfigurationService>();
      A.CallTo(() => rnrConfigurationService.GetConfiguration()).Returns(config);
      var rnrHost = new RnrHost(rnrServiceFactory, rnrConfigurationService);

      // Act
      await rnrHost.RunAsync();

      // Assert
      A.CallTo(() => rnrServiceFactory.Build(config)).MustHaveHappenedOnceExactly();
   }

   [TestMethod]
   public void DoesRestartServiceOnConfigurationChange()
   {

   }

   [TestMethod]
   public void DoesPassRunScriptCallToService()
   {

   }

   [TestMethod]
   public void DoesPassGetAllScriptsCallToService()
   {

   }
}
