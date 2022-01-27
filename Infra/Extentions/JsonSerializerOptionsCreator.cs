using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infra.Extentions
{
    public static class JsonSerializerOptionsCreator
    {
        public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = CreateSerializer();

        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = CreateSerializerSettings();

        private static JsonSerializerOptions CreateSerializer()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }

        private static JsonSerializerSettings CreateSerializerSettings()
        {
            var options = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Culture = System.Globalization.CultureInfo.InvariantCulture,
            };
            options.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter { CamelCaseText = true });
            return options;
        }
    }
}
