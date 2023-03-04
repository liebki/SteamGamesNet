using Newtonsoft.Json;

namespace SteamGamesNet.Models
{
    public partial class RawSteamGame
    {
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Success { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("steam_appid", NullValueHandling = NullValueHandling.Ignore)]
        public long? SteamAppid { get; set; }

        [JsonProperty("required_age", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequiredAge { get; set; }

        [JsonProperty("is_free", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsFree { get; set; }

        [JsonProperty("detailed_description", NullValueHandling = NullValueHandling.Ignore)]
        public string DetailedDescription { get; set; }

        [JsonProperty("about_the_game", NullValueHandling = NullValueHandling.Ignore)]
        public string AboutTheGame { get; set; }

        [JsonProperty("short_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDescription { get; set; }

        [JsonProperty("supported_languages", NullValueHandling = NullValueHandling.Ignore)]
        public string SupportedLanguages { get; set; }

        [JsonProperty("reviews", NullValueHandling = NullValueHandling.Ignore)]
        public string Reviews { get; set; }

        [JsonProperty("header_image", NullValueHandling = NullValueHandling.Ignore)]
        public Uri HeaderImage { get; set; }

        [JsonProperty("website", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Website { get; set; }

        [JsonProperty("legal_notice", NullValueHandling = NullValueHandling.Ignore)]
        public string LegalNotice { get; set; }

        [JsonProperty("publishers", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Publishers { get; set; }

        [JsonProperty("price_overview", NullValueHandling = NullValueHandling.Ignore)]
        public PriceOverview PriceOverview { get; set; }

        [JsonProperty("platforms", NullValueHandling = NullValueHandling.Ignore)]
        public Platforms Platforms { get; set; }

        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<Category> Categories { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<Genre> Genres { get; set; }

        [JsonProperty("screenshots", NullValueHandling = NullValueHandling.Ignore)]
        public List<Screenshot> Screenshots { get; set; }

        [JsonProperty("support_info", NullValueHandling = NullValueHandling.Ignore)]
        public SupportInfo SupportInfo { get; set; }

        [JsonProperty("background", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Background { get; set; }

        [JsonProperty("background_raw", NullValueHandling = NullValueHandling.Ignore)]
        public Uri BackgroundRaw { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Type)}={Type}, {nameof(Name)}={Name}, {nameof(SteamAppid)}={SteamAppid.ToString()}, {nameof(RequiredAge)}={RequiredAge.ToString()}, {nameof(IsFree)}={IsFree.ToString()}, {nameof(DetailedDescription)}={DetailedDescription}, {nameof(AboutTheGame)}={AboutTheGame}, {nameof(ShortDescription)}={ShortDescription}, {nameof(SupportedLanguages)}={SupportedLanguages}, {nameof(Reviews)}={Reviews}, {nameof(HeaderImage)}={HeaderImage}, {nameof(Website)}={Website}, {nameof(LegalNotice)}={LegalNotice}, {nameof(Publishers)}={Publishers}, {nameof(PriceOverview)}={PriceOverview}, {nameof(Platforms)}={Platforms}, {nameof(Categories)}={Categories}, {nameof(Genres)}={Genres}, {nameof(Screenshots)}={Screenshots}, {nameof(SupportInfo)}={SupportInfo}, {nameof(Background)}={Background}, {nameof(BackgroundRaw)}={BackgroundRaw}}}";
        }
    }

    public partial class Category
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public partial class Genre
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public partial class Platforms
    {
        [JsonProperty("windows", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Windows { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Mac { get; set; }

        [JsonProperty("linux", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Linux { get; set; }
    }

    public partial class PriceOverview
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("initial", NullValueHandling = NullValueHandling.Ignore)]
        public long? Initial { get; set; }

        [JsonProperty("final", NullValueHandling = NullValueHandling.Ignore)]
        public long? Final { get; set; }

        [JsonProperty("discount_percent", NullValueHandling = NullValueHandling.Ignore)]
        public long? DiscountPercent { get; set; }

        [JsonProperty("initial_formatted", NullValueHandling = NullValueHandling.Ignore)]
        public string InitialFormatted { get; set; }

        [JsonProperty("final_formatted", NullValueHandling = NullValueHandling.Ignore)]
        public string FinalFormatted { get; set; }
    }

    public partial class Screenshot
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("path_thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PathThumbnail { get; set; }

        [JsonProperty("path_full", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PathFull { get; set; }
    }

    public partial class SupportInfo
    {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    }
}