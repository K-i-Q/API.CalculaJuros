using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Infra.Extentions
{
    public class jSonHelpers
    {
        public void ChangePropertiesToLowerCase(JObject jsonObject)
        {
            foreach (var property in jsonObject.Properties().ToList())
            {
                if (property.Value.Type == JTokenType.Object)// replace property names in child object
                    ChangePropertiesToLowerCase((JObject)property.Value);

                property.Replace(new JProperty(char.ToLower(property.Name[0]) + property.Name.Substring(1), property.Value));// properties are read-only, so we have to replace them
            }
        }
    }
}
