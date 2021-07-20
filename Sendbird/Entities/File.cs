using Newtonsoft.Json;
using Sendbird.Core;
using System;
using System.Net;

namespace Sendbird.Entities
{
    public class File : SendbirdEntity<File>
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }

    public static class FileExtensions
    {
        public static void SaveAs(this File file, string filePath)
        {
            if (string.IsNullOrWhiteSpace(file.Url))
                throw new ArgumentException("File.Url cannot be the empty.", nameof(file.Url));

            using (var client = new WebClient())
            {
                client.Headers.Add("Api-Token", SendbirdConfiguration.ApiToken);
                client.DownloadFile(file.Url, filePath);
            }
        }
    }
}
