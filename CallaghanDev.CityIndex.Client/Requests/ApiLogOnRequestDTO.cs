using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Requests
{
    public class  ApiLogOnRequestDTO
    {
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("AppVersion")]
        public string AppVersion { get; set; }
        [JsonProperty("AppComments")]
        public string AppComments { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("AppKey")]
        public string AppKey { get; set; }
    }

}