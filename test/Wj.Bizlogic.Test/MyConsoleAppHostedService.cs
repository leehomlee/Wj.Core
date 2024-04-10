using Microsoft.Extensions.Hosting;
using Serilog;

namespace Wj.Bizlogic.Test
{
    public class MyConsoleAppHostedService : IHostedService
    {
        private readonly HelloWorldService _helloWorldService;

        public MyConsoleAppHostedService(HelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _helloWorldService.SayHelloAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

