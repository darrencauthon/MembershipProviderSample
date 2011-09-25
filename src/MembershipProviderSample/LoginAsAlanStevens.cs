using System.Security.Principal;
using MvcTurbine.MembershipProvider;

namespace MembershipProviderSample
{
    public class LoginAsAlanStevens : PrincipalProvider
    {
        public override PrincipalProviderResult GetPrincipal(string userId, string password)
        {
            if (userId == "alan" && password == "stevens")
                return AlansPrincipal();
            return InvalidResult();
        }

        private static PrincipalProviderResult InvalidResult()
        {
            return new PrincipalProviderResult();
        }

        private static PrincipalProviderResult AlansPrincipal()
        {
            return new PrincipalProviderResult
                       {
                           Principal = new GenericPrincipal(new GenericIdentity("Alan"), new[] {"SuperAdministrator"})
                       };
        }
    }
}