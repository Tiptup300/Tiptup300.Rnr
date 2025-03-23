using System.Collections.Immutable;
using Shouldly;
using Tiptup300.Rnr.Tests.Utilities;
using static Tiptup300.Rnr.Tests.Utilities.TestHelper;

namespace Tiptup300.Rnr.Tests.VersionOnePointOh;

[TestClass]
public class ParameterTests
{
   [TestMethod]
   public void ShouldTakeInParameter()
   {
      // Arrange
      Setup(scripts: [
         CreateScript
            .WithName("Local.HelloWorld")
            .WithRequiredParameter(withName:"Name")
      ]);

      // Act
      var scriptRunConfig = Run("rnr Local.HelloWorld --Name 'John'")
         .GetScriptRunConfig();

      // Assert
      scriptRunConfig.Parameters.ShouldContainKey("Name");
      scriptRunConfig.Parameters["Name"].ShouldBe("John");
   }

   [TestMethod]
   public void ShouldSetFirstParameter()
   {
      // Arrange
      Setup(scripts: [
         CreateScript
            .WithName("Local.DrawShape")
            .WithRequiredParameter(withName: "Shape")
            .WithOptionalParameter(withName: "Color", withDefaultValue: "Black")
      ]);

      // Act
      var scriptRunConfig = Run("rnr Local.DrawShape Circle")
         .GetScriptRunConfig();

      // Assert
      scriptRunConfig.Parameters[0].ShouldBe("Circle");
      scriptRunConfig.Parameters["Shape"].ShouldBe("Circle");
      scriptRunConfig.Parameters["Color"].ShouldBe("Black");
   }

   [TestMethod]
   public void ShouldThrowErrorOnMissingRequiredParameter()
   {
      // Arrange
      Setup(scripts: [
         CreateScript
            .WithName("Local.DrawShape")
            .WithRequiredParameter(withName: "Shape")
            .WithOptionalParameter(withName: "Color", withDefaultValue: "Black")
      ]);

      // Act
      var output = Run("rnr Local.DrawShape --Color Blue")
         .GetOutput();

      // Assert
      output.ShouldContain("error", Case.Insensitive);
   }

   [TestMethod]
   public void ShouldAllowCaseInsensitiveParameters()
   {
      // Arrange
      Setup(scripts: [
         CreateScript
            .WithName("Local.DrawShape")
            .WithRequiredParameter(withName: "Shape")
      ]);

      // Act
      var scriptRunConfig = Run("rnr Local.DrawShape --sHAPE Circle")
         .GetScriptRunConfig();

      // Assert
      scriptRunConfig.Parameters["Shape"].ShouldBe("Circle");
   }

   [TestMethod]
   public void ShouldAllowAnyPrefixedHyphens()
   {
      // Arrange
      Setup(scripts: [
         CreateScript
            .WithName("Local.Do")
            .WithRequiredParameter(withName: "X")
            .WithRequiredParameter(withName: "Y")
            .WithRequiredParameter(withName: "Z")
      ]);

      // Act
      var scriptRunConfig = Run("rnr Local.Do -X 1 --Y 2 ---Z 3")
         .GetScriptRunConfig();

      // Assert
      scriptRunConfig.Parameters["X"].ShouldBe("1");
      scriptRunConfig.Parameters["Y"].ShouldBe("2");
      scriptRunConfig.Parameters["Z"].ShouldBe("3");
   }

   [TestMethod]
   public void ShouldRequireParamethensis()
   {
      // Arrange
      Setup(scripts: [
         CreateScript
            .WithName("Local.Do")
            .WithRequiredParameter(withName: "Type")
      ]);

      // Act
      var output = Run("rnr Local.Do Type 1")
         .GetOutput();

      // Assert
      output.ShouldContain("error", Case.Insensitive);
   }
}