using DI_Example;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(Startup.Configure)
    .Build();

host.Run();
