using DI_Sample_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DI_Example
{
    public class DiSampleFunction
    {
        private readonly ILogger<DiSampleFunction> _logger;
        public IDemoSingleton DemoSingleton;
        public IDemoScoped DemoScoped;
        public IDemoTransient DemoTransient;
        public IDemoSingleton DemoSingleton1;
        public IDemoScoped DemoScoped1;
        public IDemoTransient DemoTransient1;

        public DiSampleFunction(ILogger<DiSampleFunction> logger, IDemoSingleton demoSingleton, IDemoScoped demoScoped, IDemoTransient demoTransient, IDemoSingleton demoSingleton1, IDemoScoped demoScoped1, IDemoTransient demoTransient1)
        {
            _logger = logger;
            DemoSingleton = demoSingleton;
            DemoScoped = demoScoped;
            DemoTransient = demoTransient;
            DemoSingleton1 = demoSingleton1;
            DemoScoped1 = demoScoped1;
            DemoTransient1 = demoTransient1;
        }

        [Function("DISampleFunction")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("DISampleFunction1 function processed a request.");
            int numSingleton = DemoSingleton.ReturnNumber();
            string result = "numSingleton = " + numSingleton;

            numSingleton = DemoSingleton1.ReturnNumber();
            result = "numSingleton1 = " + numSingleton;

            _logger.LogInformation("numSingleton = " + numSingleton);
            int numScoped = DemoScoped.ReturnNumber();
            result += " numScoped Call 1= " + numScoped;

            _logger.LogInformation("numScoped Call 2= " + numScoped);
            numScoped = DemoScoped1.ReturnNumber();
            result += " numScoped Call 2= " + numScoped;

            int numTransient = DemoTransient.ReturnNumber();
            result += " numTransient Call 1 = " + numTransient;
            _logger.LogInformation("numTransient Call 1 = " + numTransient);

            numTransient = DemoTransient1.ReturnNumber();
            result += " numTransient Call 2 = " + numTransient;
            _logger.LogInformation("numTransient Call 2 = " + numTransient);                            
            return new OkObjectResult(result);
        }
    }
}
