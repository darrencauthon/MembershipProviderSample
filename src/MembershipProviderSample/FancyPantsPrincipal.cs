using System.Security.Principal;

namespace MembershipProviderSample
{
    public class FancyPantsPrincipal : GenericPrincipal
    {
        private readonly string pantsColor;

        public FancyPantsPrincipal(IIdentity identity, string pantsColor) : base(identity, new[] {"FancyPants"})
        {
            this.pantsColor = pantsColor;
        }

        public string PantsColor
        {
            get { return pantsColor; }
        }
    }
}