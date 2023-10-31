using Application.Boundaries.Services;
using Infrastructure.IO.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IO.Installers
{
    public static class ServicesInstaller
    {
        public static IServiceCollection AddIOServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IWebsiteBlocksFileService, WebsiteBlocksFileService>();
        }
    }
}
