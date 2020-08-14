using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace huyblog.Models.ResponseModel
{
    public class ResponseModel<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
