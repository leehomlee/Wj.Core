using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Test
{
    public class MyConsoleAppModule : AppModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //SkipAutoServiceRegistration = true;
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.Configure<MyOptions>(options =>
            {
                options.Value1 = 10;
            });
        }
    }

    public class MyOptions
    { 
        public int Value1 { get; set; }

        public bool Value2 { get; set; }

        public string? Value3 { get; set; }
    }
}

