using Application.UseCases.Implementations.CreateWebsiteBlocks;
using Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Installers
{
    public static class UseCasesInstaller
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services
                .AddScoped<ICreateWebsiteBlocksUseCase, CreateWebsiteBlocksUseCase>();
        }
    }
}
