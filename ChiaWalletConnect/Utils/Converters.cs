using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.Utils
{
    internal class Converters
    {
        public static T? ToObject<T>(JObject? j, string childItem)
        {
            if (j is not null)
            {
                var token = string.IsNullOrEmpty(childItem) ? j : j.GetValue(childItem);

                return ToObject<T>(token);
            }

            return default;
        }

        public static T? ToObject<T>(JToken? token)
        {
            return token is not null
                ? token.ToObject<T>(JsonSerializer.Create(new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    MissingMemberHandling = MissingMemberHandling.Ignore
                }))
                : default;
        }
    }
}
