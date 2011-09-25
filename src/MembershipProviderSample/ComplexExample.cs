using System;
using System.Security.Principal;
using MvcTurbine.MembershipProvider;

namespace MembershipProviderSample
{
    public class ComplexExample : IPrincipalProvider
    {
        public PrincipalProviderResult GetPrincipal(string userId, string password)
        {
            if (userId == "darren")
            {
                var color = password; // treat the password as a color to demonstrate passing data in and out of cookie
                return PrincipalForDarren(color);
            }
            return InvalidLogin();
        }

        public IPrincipal CreatePrincipalFromTicketData(string userName, string userData)
        {
            var pantsColor = userData;

            var genericIdentity = new GenericIdentity(userName);
            var principal = new FancyPantsPrincipal(genericIdentity, pantsColor);
            return principal;
        }

        public TicketData ConvertPrincipalToTicketData(IPrincipal principal)
        {
            var fancyPantsPrincipal = principal as FancyPantsPrincipal;

            if (fancyPantsPrincipal == null) throw new Exception("shenanigans");

            return new TicketData
                       {
                           IsPersistent = true,
                           NumberOfMinutesUntilExpiration = 300,
                           UserData = fancyPantsPrincipal.PantsColor,
                           Username = fancyPantsPrincipal.Identity.Name
                       };
        }

        private static PrincipalProviderResult PrincipalForDarren(string color)
        {
            var genericIdentity = new GenericIdentity("Darren");
            return new PrincipalProviderResult
                       {
                           Principal = new FancyPantsPrincipal(genericIdentity, color)
                       };
        }

        private static PrincipalProviderResult InvalidLogin()
        {
            return new PrincipalProviderResult();
        }
    }
}