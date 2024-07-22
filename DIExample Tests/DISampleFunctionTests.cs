using DI_Example;
using DI_Sample_Logic;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace DIExample_Tests
{
    public class DISampleFunctionTests
    {
        private readonly DiSampleFunction _sut;
        private readonly Mock<IDemoSingleton> _demoSingleton;
        private readonly Mock<IDemoScoped> _demoScoped;
        private readonly Mock<IDemoTransient> _demoTransient;

        public DISampleFunctionTests()
        {
            var loggerMock = new Mock<ILogger<DiSampleFunction>>();
            _demoSingleton = new Mock<IDemoSingleton>();
            _demoScoped = new Mock<IDemoScoped>();
            _demoTransient = new Mock<IDemoTransient>();
            _sut = new DiSampleFunction(loggerMock.Object, _demoSingleton.Object, _demoScoped.Object,
                _demoTransient.Object, _demoSingleton.Object, _demoScoped.Object, _demoTransient.Object);
        }

        [Fact]
        public void DiSampleFunctionShouldReturn200Ok()
        {
            //Arrange
            _demoSingleton.Setup(x=>x.ReturnNumber()).Returns(1);
            _demoScoped.Setup(x => x.ReturnNumber()).Returns(2);
            _demoTransient.Setup(x => x.ReturnNumber()).Returns(3);
            var mockRequest = new Mock<HttpRequest>();

            // Act
            var result = (OkObjectResult)_sut.Run(mockRequest.Object);

            //Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
