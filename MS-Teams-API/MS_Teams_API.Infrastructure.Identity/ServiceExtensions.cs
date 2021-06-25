using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TProd.Portal.Api.Infrastructure.Identity.Authentication;

namespace TProd.Portal.Api.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add samesite cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.IsEssential = true;
                });

            //Add authentication
            services.AddOptions<AuthenticationOptions>().Configure<IConfiguration>((authenticationOptions, configuration) =>
            {
                ServiceRegistration.FillAuthenticationOptionsProperties(authenticationOptions, configuration);
            });
            services.AddHttpContextAccessor();
            AuthenticationOptions authenticationOptionsParameter = new AuthenticationOptions();
            ServiceRegistration.FillAuthenticationOptionsProperties(authenticationOptionsParameter, configuration);
            services.AddAuthentication(configuration, authenticationOptionsParameter);
        }

        private static void FillAuthenticationOptionsProperties(AuthenticationOptions authenticationOptions, IConfiguration configuration)
        {
            // NOTE: This AzureAd:Instance configuration setting does not need to be
            // overridden by any deployment specific value. It can stay the default value
            // that is set in the project's configuration.
            authenticationOptions.AzureAdInstance = configuration.GetValue<string>("AzureAd:Instance");

            authenticationOptions.AzureAdTenantId = configuration.GetValue<string>("AzureAd:TenantId");
            authenticationOptions.AzureAdClientId = configuration.GetValue<string>("AzureAd:ClientId");
            authenticationOptions.AzureAdValidAudiences = configuration.GetValue<string>("AzureAd:ValidAudiences").Split(';').Select(x => x.Trim()).ToArray();

            // NOTE: This AzureAd:ValidIssuers configuration setting does not need to be
            // overridden by any deployment specific value. It can stay the default value
            // that is set in the project's configuration.
            authenticationOptions.AzureAdValidIssuers = configuration.GetValue<string>("AzureAd:ValidIssuers");

            authenticationOptions.DisableCreatorUpnCheck = configuration.GetValue<bool>("DisableCreatorUpnCheck", false);
            authenticationOptions.AuthorizedCreatorUpns = configuration.GetValue<string>("AuthorizedCreatorUpns");
            authenticationOptions.AuthorizedAppClientIds = configuration.GetValue<string>("AuthorizedAppClientIds");
        }
    }
}
