using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Serilog;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Test
{
    public class HelloWorldService : ITransientDependency
    {

        private readonly MyOptions _options;

        public HelloWorldService(IOptions<MyOptions> options)
        {
            _options = options.Value;
        }

        public Task SayHelloAsync()
        {
            Log.Information("Hello World!");
            Log.Information("MyOptions:Value1:" + _options.Value1);
            return Task.CompletedTask;
        }
    }
}

