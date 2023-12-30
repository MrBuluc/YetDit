using Microsoft.Extensions.DependencyInjection;
using YetDit.Application.Abstractions.Token;
using YetDit.Infrastructure.Services.Token;

namespace YetDit.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
