using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS_Teams_API.Application.Interfaces;
using MS_Teams_API.Domain.Settings;
using MS_Teams_API.Infrastructure.Shared.Services;

namespace MS_Teams_API.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
