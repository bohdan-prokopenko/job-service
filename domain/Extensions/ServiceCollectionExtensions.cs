using JobService.Domain.UseCase;

using Microsoft.Extensions.DependencyInjection;

namespace JobService.Domain.Extensions;
public static class ServiceCollectionExtensions {
    public static IServiceCollection AddDomain(this IServiceCollection services) {
        return services.AddTransient<ICalculateTotalUseCase, CalculateTotalUseCase>();
    }
}
