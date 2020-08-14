using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huyblog.Common.Utils
{
    public class JsonUtils
    {
        public static string FormatJson<T>(T data)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new LowercaseNamingStrategy() },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(data, settings);
        }


        public class LowercaseNamingStrategy : NamingStrategy
        {
            protected override string ResolvePropertyName(string name)
            {
                return Char.ToLowerInvariant(name[0]) + name.Substring(1);
            }
        }
    }
}
