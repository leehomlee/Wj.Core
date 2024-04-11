using System.Text.Json;

namespace Wj.Bizlogic.Json.SystemTextJson
{
    public class AppSystemTextJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; }

        public AppSystemTextJsonSerializerOptions()
        {
            JsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true
            };
        }
    }
}

