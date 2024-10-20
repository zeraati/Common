using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;
public static class MediatRBuilderExtension
{
    public static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        var assemblies = new Assembly[] { Assembly.GetEntryAssembly()!, Assembly.GetExecutingAssembly(), Assembly.GetCallingAssembly() };

        builder.Services
            .AddMediatR(options => options.RegisterServicesFromAssemblies(assemblies))
            .Decorate(typeof(IRequestHandler<,>), typeof(RequestHandlerValidatorDecorator<,>))
            .Scan(scan => scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestValidator<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return builder;
    }
}