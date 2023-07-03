namespace Core;

using Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPizzaCore), typeof(PizzaCore));

        return services;
    }
}