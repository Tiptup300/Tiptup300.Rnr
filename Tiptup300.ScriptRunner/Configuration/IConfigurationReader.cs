namespace Tiptup300.ScriptRunner.Configuration;

public interface IConfigurationReader
{
   AppConfiguration Read(string configuration);
}