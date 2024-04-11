using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Text.Json;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Json.SystemTextJson
{
    public class AppSystemTextJsonSerializer : IJsonSerializer, ITransientDependency
    {
        protected AppSystemTextJsonSerializerOptions Options { get; }

        public AppSystemTextJsonSerializer(IOptions<AppSystemTextJsonSerializerOptions> options)
        {
            Options = options.Value;
        }

        public string Serialize(object obj, bool camelCase = true, bool indented = false)
        {
            return JsonSerializer.Serialize(obj, CreateJsonSerializerOptions(camelCase, indented));
        }

        public T Deserialize<T>(string jsonString, bool camelCase = true)
        {
            return JsonSerializer.Deserialize<T>(jsonString, CreateJsonSerializerOptions(camelCase))!;
        }

        public object Deserialize(Type type, string jsonString, bool camelCase = true)
        {
            return JsonSerializer.Deserialize(jsonString, type, CreateJsonSerializerOptions(camelCase))!;
        }

        private static readonly ConcurrentDictionary<object, JsonSerializerOptions> JsonSerializerOptionsCache =
            new ConcurrentDictionary<object, JsonSerializerOptions>();

        protected virtual JsonSerializerOptions CreateJsonSerializerOptions(bool camelCase = true, bool indented = false)
        {
            return JsonSerializerOptionsCache.GetOrAdd(new
            {
                camelCase,
                indented,
                Options.JsonSerializerOptions
            }, _ =>
            {
                var settings = new JsonSerializerOptions(Options.JsonSerializerOptions);

                if (camelCase)
                {
                    settings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                }

                if (indented)
                {
                    settings.WriteIndented = true;
                }

                return settings;
            });
        }
    }
}

