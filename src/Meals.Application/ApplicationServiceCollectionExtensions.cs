using Microsoft.Extensions.DependencyInjection;
using Meals.Application.Repositories;

namespace Meals.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMealRepository, MealRepository>();
        return services;
    }
}