using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Backend.Common.Interfaces;
using Backend.Common.Providers;
using Backend.Common.Middleware;
using Backend.Service.BusinessLogic;

namespace Backend.Service
{
    /// <summary>
    /// Azure Function entry point
    /// </summary>
    public class Program
    {
        protected Program()
        {                
        }


        public static void Main()
        {
            var host = new HostBuilder()
              .ConfigureFunctionsWorkerDefaults(builder =>
              {
                  //builder.UseMiddleware<SessionMiddleware>();
                  builder.UseNewtonsoftJson();
              })
              .ConfigureOpenApi()
                .ConfigureAppConfiguration(builder =>
                {
                    var connectionString = Environment.GetEnvironmentVariable("AppConfiguration");
                    if (!string.IsNullOrEmpty(connectionString))
                    {
                        builder.AddAzureAppConfiguration(connectionString);
                    }
                })
              .ConfigureAppConfiguration(config => config
                  .SetBasePath(Environment.CurrentDirectory)
                   .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables())
              .ConfigureServices(services =>
              {
                  services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
                  {
                      var options = new OpenApiConfigurationOptions()
                      {
                          Info = new OpenApiInfo()
                          {
                              Version = "1.0.0",
                              Title = "API",
                              Description = "API",
                              Contact = new OpenApiContact()
                              {
                                  Name = "Soporte",
                                  Email = "soporte@soporte.com",
                              },                            
                          },
                          ForceHttps = false,
                          ForceHttp = false,
                      };

                      return options;
                  });
                  services.AddScoped<ISessionProvider, SessionProvider>();
                  services.AddScoped<IEventsLogic, ExampleLogic>();             
              })
              .Build();

            host.Run();
        }
    }
}
