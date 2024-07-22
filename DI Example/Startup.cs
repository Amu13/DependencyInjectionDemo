using DI_Sample_Logic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Example
{
    public class Startup
    {
        public static void Configure(IServiceCollection  services)
        {
            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();

            services.AddSingleton<IDemoSingleton, DemoDi>();
            services.AddScoped<IDemoScoped, DemoDi>();
            services.AddTransient<IDemoTransient, DemoDi>();

            services.AddScoped< DiSampleFunction>(); // Adding scoped of Azure Functions is not required. 
            services.AddScoped<Function1>(); // But adding it will do the testing of its dependencies in Unit Testing.
        }
    }
}
