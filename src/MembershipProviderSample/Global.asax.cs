using MvcTurbine.ComponentModel;
using MvcTurbine.StructureMap;
using MvcTurbine.Web;

namespace MembershipProviderSample
{
    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            ServiceLocatorManager.SetLocatorProvider(() => new StructureMapServiceLocator());
        }
    }
}