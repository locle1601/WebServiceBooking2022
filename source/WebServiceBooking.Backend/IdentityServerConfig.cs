using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace WebServiceBooking.Backend
{
    public class IdentityServerConfig
    {
        public const string ApiName = "api";
        public const string ApiFriendlyName = "api booking";
        public const string QuickAppClientID = "angular";
        public const string SwaggerClientID = "swaggerui";
        //public const string ApiScopes = "ApiScopes";


        public static IEnumerable<IdentityResource> Ids =>
          new IdentityResource[]
          {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
          };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(ApiName, ApiFriendlyName)

            };
        public static IEnumerable<ApiScope> GetApiScopes =>
            new ApiScope[]
            {
                        new ApiScope("api", "ServiceBooking API")
            };
        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //    //WebGuest
        //        new Client
        //        {
        //            ClientId = "webportal",
        //            ClientSecrets = { new Secret("secret".Sha256()) },
        //            AllowedGrantTypes = GrantTypes.Code,
        //            RequireConsent = false,
        //            RequirePkce = true,
        //            AllowOfflineAccess = true,

        //            // where to redirect to after login
        //            RedirectUris = { "https://localhost:5002/signin-oidc" },

        //            // where to redirect to after logout
        //            PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
        //            AllowedScopes = new List<string>
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                IdentityServerConstants.StandardScopes.OfflineAccess,
        //                ApiName
        //            }
        //         },
        //    // SwaggerClientID
        //        new Client
        //        {
        //            ClientId = SwaggerClientID,
        //            ClientName = "Swagger Client",

        //            AllowedGrantTypes = GrantTypes.Implicit,
        //            AllowAccessTokensViaBrowser = true,
        //            RequireConsent = false,

        //            RedirectUris =           { "http://localhost:5001/swagger/oauth2-redirect.html" },
        //            PostLogoutRedirectUris = { "http://localhost:5001/swagger/oauth2-redirect.html" },
        //            AllowedCorsOrigins =     { "http://localhost:5001" },

        //            AllowedScopes = new List<string>
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                ApiName
        //            }
        //        },
        //    // Web_Admin
        //        new Client
        //        {
        //            ClientName = "Angular Admin",
        //            ClientId = QuickAppClientID,
        //            AccessTokenType = AccessTokenType.Reference,
        //            RequireConsent = false,

        //            RequireClientSecret = false,
        //            AllowedGrantTypes = GrantTypes.Code,
        //            RequirePkce = true,

        //            AllowAccessTokensViaBrowser = true,
        //            RedirectUris = new List<string>
        //            {
        //                "http://localhost:4200",
        //                "http://localhost:4200/login-callback", // sau khi dang nhập thành công 
        //                "http://localhost:4200/silent-renew.html" // dùng để khi web cần refesh token cho client 
        //            },
        //            PostLogoutRedirectUris = new List<string>
        //            {
        //                "http://localhost:4200/unauthorized",
        //                "http://localhost:4200/logout-callback",// sau khi dang xuất 
        //                "http://localhost:4200"
        //            },
        //            AllowedCorsOrigins = new List<string>
        //            {
        //                "http://localhost:4200"
        //            },
        //            AllowedScopes = new List<string>
        //            {
        //                IdentityServerConstants.StandardScopes.OpenId,
        //                IdentityServerConstants.StandardScopes.Profile,
        //                ApiName
        //            }
        //        }
        //    };
    }
}