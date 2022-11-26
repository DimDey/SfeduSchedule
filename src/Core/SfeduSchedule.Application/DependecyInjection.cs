using System.Reflection;
using FluentValidation;
using MediatR;
using SfeduSchedule.Application.Common.Behaviors;

namespace SfeduSchedule.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}