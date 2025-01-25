namespace Tiptup300.Rnr.Host;

public interface IRnrServiceFactory
{
   IRnrService Build(RnrServiceConfiguration config);
}
