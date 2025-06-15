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
                    ClientId = "reep-wpf-client", // Измените для WPF
                    ClientName = "REEP WPF Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RequireClientSecret = false,
                    RequirePkce = false, // Для ResourceOwnerPassword не требуется
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "REEP-WebApi" // Исправлено на правильное написание
                    },
                    AllowOfflineAccess = true, // Для refresh токенов
                    AccessTokenLifetime = 3600, // 1 час
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime = 2592000 // 30 дней
                }
            };
    }
}
