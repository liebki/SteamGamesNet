using Newtonsoft.Json;
using System;
using System.Linq;

namespace SteamGamesNet.Models
{
    public partial class AppListContainer
    {
        [JsonProperty("applist", NullValueHandling = NullValueHandling.Ignore)]
        public Applist Applist { get; set; }
    }

    public partial class Applist
    {
        [JsonProperty("apps", NullValueHandling = NullValueHandling.Ignore)]
        public App[] Apps { get; set; }
    }

    public partial class App
    {
        [JsonProperty("appid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Appid { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
