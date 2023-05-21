using Newtonsoft.Json;

namespace OpusTool
{
    public class GitHubRelease
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prerelease")]
        public bool IsPrerelease { get; set; }

        [JsonProperty("assets")]
        public List<GitHubReleaseAsset> Assets { get; set; }
        public int getVersion()
        {
            return Int32.Parse(TagName.Substring(1, TagName.Length));
    }
    }

    public class GitHubReleaseAsset
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("browser_download_url")]
        public string BrowserDownloadUrl { get; set; }
    }
    

}