namespace Tiptup300.ScriptRunner.ConsoleApplication;


public class Program
{
   public static IConsoleWriter? ConsoleWriter;
   public static IScriptCommandExecuter? ScriptCommandExecuter;

   public static void Main(string args)
   {
      var scriptRunnerApplication = new ScriptRunnerApplication(ConsoleWriter!, ScriptCommandExecuter!);
      scriptRunnerApplication.Run(args);
   }
}
