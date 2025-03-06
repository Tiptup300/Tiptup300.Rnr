namespace Tiptup300.Rnr;

public interface IRunScriptCommandFactory
{
   ScriptExecutionPayload Build(string[] commandArgs);
}