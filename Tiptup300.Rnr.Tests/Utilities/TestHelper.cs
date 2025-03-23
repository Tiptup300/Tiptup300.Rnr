using System.Collections.Immutable;
using Tiptup300.Rnr.Hosting;

namespace Tiptup300.Rnr.Tests.Utilities;


public record class TestSetup
{
   public ImmutableArray<ScriptTestModel>? Scripts { get; private set; }

   public static TestSetup SetupTest() 
      => new TestSetup();


   public TestSetup WithScripts(ImmutableArray<ScriptTestModel> scripts)
   {
      if (Scripts != null)
         throw new Exception();

      return this with { Scripts = scripts };
   }

   internal TestSetup Run(string v)
   {
      throw new NotImplementedException();
   }
}

public record class ScriptTestModel
{
   public string Tag { get; init; } = "";
}

public static class CreateScript
{
   public static ScriptTestModel WithName(string tag)
   {
      return new ScriptTestModel { Tag = tag };
   }
   public static ScriptTestModel WithName(this ScriptTestModel scriptTestModel, string tag)
   {
      return scriptTestModel with { Tag = tag };
   }
   public static ScriptTestModel WithRequiredParameter(string withName)
   {
      throw new NotImplementedException();
   }
   public static ScriptTestModel WithRequiredParameter(this ScriptTestModel scriptTestModel, string withName)
   {
      throw new NotImplementedException();
   }
   public static ScriptTestModel WithOptionalParameter(string withName, string withDefaultValue)
   {
      throw new NotImplementedException();
   }
   public static ScriptTestModel WithOptionalParameter(this ScriptTestModel scriptTestModel, string withName, string withDefaultValue)
   {
      throw new NotImplementedException();
   }
}

public static class TestHelper
{
   public static void Setup(ImmutableArray<ScriptTestModel>? scripts = null)
   {

   }

   public static RunTestModel Run(string runStr)
   {
      return new RunTestModel();
   }
}
