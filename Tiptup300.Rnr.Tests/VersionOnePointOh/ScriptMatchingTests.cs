using Shouldly;
using Tiptup300.Rnr.Tests.Utilities;
using static Tiptup300.Rnr.Tests.Utilities.TestSetup;

namespace Tiptup300.Rnr.Tests.VersionOne;

[TestClass]
public class ScriptMatchingTests
{
   [TestMethod]
   public void DoesGetPartialMatchScripts()
   {
      // Arrange
      var testSetup = SetupTest().WithScripts([
         CreateScript.WithName("Utilities.AppleSauce"),
         CreateScript.WithName("Local.Apple"),
         CreateScript.WithName("Local.RedAppleGoose"),
         CreateScript.WithName("Local.Banana"),
      ]);

      // Act
      var output = testSetup.Run("rnr Apple")
         .GetPartialMatches();

      //Assert
      output.ShouldContain("Local.Apple");
      output.ShouldContain("Local.RedAppleGoose");
   }

   [TestMethod]
   public void ShouldFindScriptsCaseInsenstive()
   {
      // Arrange
      Setup(scripts: [
         CreateScript.WithName("Local.Script")]
      );

      // Act
      var script = Run("rnr loCaL.scRipt")
         .GetScriptResult();

      // Assert
      script.ShouldHaveTag("Local.Script");
   }

   [TestMethod]
   public void ShouldAllowForPartialMatches()
   {
      // Arrange
      Setup(scripts: [
         CreateScript.WithName("Local.Script")]
      );

      // Act
      var script = Run("rnr Script")
         .GetScriptResult();

      // Assert
      script.ShouldHaveTag("Local.Script");
   }

   [TestMethod]
   public void ShouldNotRunIfMultiplePartialMatches()
   {
      // Arrange
      Setup(scripts: [
         CreateScript.WithName("Local.Script"),
         CreateScript.WithName("Script")]
      );

      // Act
      var script = Run("rnr Script")
         .GetScriptResult();

      // Assert
      script.ShouldBeNull();
   }
}
