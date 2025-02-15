namespace Tiptup300.Rnr;

public interface IRunScriptCommandFactory
{
   RunScriptCommand Build(string[] commandArgs);
}