using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using Wj.Bizlogic.Json.SystemTextJson.JsonConverters;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Json.SystemTextJson
{
    [DependsOn(typeof(AppJsonAbstractionsModule))]
    public class AppJsonSystemTextJsonModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddOptions<AppSystemTextJsonSerializerOptions>()
                .Configure<IServiceProvider>((options, rootServiceProvider) =>
                {
                    // If the user hasn't explicitly configured the encoder, use the less strict encoder that does not encode all non-ASCII characters.
                    options.JsonSerializerOptions.Encoder ??= JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                    options.JsonSerializerOptions.Converters.Add(new AppStringToEnumFactory());
                    options.JsonSerializerOptions.Converters.Add(new AppStringToBooleanConverter());
                    options.JsonSerializerOptions.Converters.Add(new AppStringToGuidConverter());
                    options.JsonSerializerOptions.Converters.Add(new AppNullableStringToGuidConverter());
                    options.JsonSerializerOptions.Converters.Add(new ObjectToInferredTypesConverter());
                });
        }
    }
}

