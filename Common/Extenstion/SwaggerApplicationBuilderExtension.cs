using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;
public static class SwaggerApplicationBuilderExtension
{
    public static WebApplicationBuilder AddSwaggerBasicAuthorization(this WebApplicationBuilder builder, string title, string version)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")== "Development") title += " Dev";
        version = "v" + version.Replace("v", "");
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc(version.Split('.').First(), new OpenApiInfo { Title = title, Version = version });
            option.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKey",
                In = ParameterLocation.Header,
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme {Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "ApiKey"}},
                    new string[] {}
                }
            });
        });

        return builder;
    }

    public static IApplicationBuilder UseSwaggerCustom(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(option => { 
            option.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            option.DefaultModelsExpandDepth(-1);
        });

        return app;
    }
}