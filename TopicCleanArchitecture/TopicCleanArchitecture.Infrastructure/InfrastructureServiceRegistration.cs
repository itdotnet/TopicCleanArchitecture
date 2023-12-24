using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopicCleanArchitecture.Application.Contracts.Email;
using TopicCleanArchitecture.Application.Contracts.Logging;
using TopicCleanArchitecture.Application.Models.Email;
using TopicCleanArchitecture.Infrastructure.EmailService;
using TopicCleanArchitecture.Infrastructure.Logging;

namespace TopicCleanArchitecture.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
