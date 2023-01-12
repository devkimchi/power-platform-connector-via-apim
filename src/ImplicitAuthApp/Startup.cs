using System;

using ImplicitAuthApp.Models;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations.AppSettings.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using OpenApiSettings = Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations.OpenApiSettings;

[assembly: FunctionsStartup(typeof(ImplicitAuthApp.Startup))]

namespace ImplicitAuthApp
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            builder.ConfigurationBuilder
                   .AddEnvironmentVariables();

            base.ConfigureAppConfiguration(builder);
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureAppSettings(builder.Services);
            ConfigureHttpClient(builder.Services);
        }

        private static void ConfigureAppSettings(IServiceCollection services)
        {
            var settings = services.BuildServiceProvider()
                                   .GetService<IConfiguration>()
                                   .Get<GraphSettings>(GraphSettings.Name);
            services.AddSingleton(settings);

            var openapi = services.BuildServiceProvider()
                                  .GetService<IConfiguration>()
                                  .Get<OpenApiSettings>(OpenApiSettings.Name);

            var options = new DefaultOpenApiConfigurationOptions()
            {
                OpenApiVersion = openapi.Version,
                Info = new OpenApiInfo()
                {
                    Version = "1.0.0",
                    Title = "API AuthN'd by Implicit Auth",
                    Description = "This is the API authN'd by Implicit Auth."
                }
            };

            /* ⬇️⬇️⬇️ for GH Codespaces ⬇️⬇️⬇️ */
            var codespaces = bool.TryParse(Environment.GetEnvironmentVariable("OpenApi__RunOnCodespaces"), out var isCodespaces) && isCodespaces;
            if (codespaces)
            {
                options.IncludeRequestingHostName = false;
            }
            /* ⬆️⬆️⬆️ for GH Codespaces ⬆️⬆️⬆️ */
            services.AddSingleton<IOpenApiConfigurationOptions>(options);
        }

        private static void ConfigureHttpClient(IServiceCollection services)
        {
            services.AddHttpClient("profile");
        }
    }
}