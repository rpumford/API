using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Models
{
    public class Root
    {
        public string total { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
        public List<PassportLocation> data { get; set; }
    }

    public class PassportLocation
    {
        [JsonProperty("data:")]
        public string id { get; set; }
        public string label { get; set; }
        public List<Park> parks { get; set; }
        public string type { get; set; }
    }

    public class Park
    {
        [JsonProperty("parks:")]
        public string states { get; set; }
        public string parkCode { get; set; }
        public string designation { get; set; }
        public string fullName { get; set; }
        public string url { get; set; }
        public string name { get; set; }
    }

}
