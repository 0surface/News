using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace News.Service.Model
{
    public class ScrapeConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }

        public ScrapeConfig()
        {

        }

        public ScrapeConfig(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
