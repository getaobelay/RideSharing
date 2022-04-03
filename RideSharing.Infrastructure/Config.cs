using Duende.IdentityServer.Models;

namespace RideSharing.Infrastructure
{
    internal class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResource(
                    name: "profile",
                    userClaims: new[] { "name", "email", "website" },
                    displayName: "Your profile data"),

                new IdentityResource(
                    name: "openid",
                    userClaims: new[] { "sub" },
                    displayName: "Your user identifier")
                };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "web_viewer",

                    AllowedScopes = { "openid", "profile", "read" }
                }

            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };
        }
    }
}