using DI_Example;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DIExample_Tests
{
    public class StartupTests
    {
        [Fact(DisplayName = "Resolve DiSampleFunction Services")]
        public void ResolveDiSampleFunctionServices()
        {
            // Arrange
            var host = new HostBuilder()
                .ConfigureFunctionsWebApplication()
                .ConfigureServices(Startup.Configure)
                .Build();
            // Act
            Action action = () => host.Services.GetRequiredService<DiSampleFunction>();

            //Assert
            action.Should().NotThrow();
        }

        [Fact(DisplayName = "Resolve Function1 Services")]
        public void ResolveFunction1Services()
        {
            // Arrange
            var host = new HostBuilder()
                .ConfigureFunctionsWebApplication()
                .ConfigureServices(Startup.Configure)
                .Build();
            // Act
            Action action = () => host.Services.GetRequiredService<Function1>();

            //Assert
            action.Should().NotThrow();
        }
    }
}