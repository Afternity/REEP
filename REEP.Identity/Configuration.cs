using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace REEP.Identity
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScope =>
            new List<ApiScope>()
            {
                new ApiScope("REEP-WebApi", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>()
            {
                new ApiResource("REEP-WebApi", "Web API", new[]
                    {JwtClaimTypes.Name})
                {
                    Scopes = { "REEP-WebApi" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>()
            {
                new Client()
                {
                    ClientId = "reep-web-api",
                    ClientName = "REEP Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://.../signic-oidc" // липовая строка, с неверныим uri
                    },
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http:/.../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "REEP-WebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
