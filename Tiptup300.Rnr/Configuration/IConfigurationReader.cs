namespace Tiptup300.Rnr.Configuration;

public interface IConfigurationReader
{
   AppConfiguration Read(string configuration);
}