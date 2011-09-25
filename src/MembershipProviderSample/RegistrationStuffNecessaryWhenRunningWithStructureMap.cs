using MvcTurbine.ComponentModel;
using MvcTurbine.MembershipProvider;
using MvcTurbine.MembershipProvider.PrincipalHelpers;

namespace MembershipProviderSample
{
    public class RegistrationStuffNecessaryWhenRunningWithStructureMap : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IUnauthenticatedPrincipalCreator, DefaultUnauthenticatedPrincipalCreator>();
        }
    }
}