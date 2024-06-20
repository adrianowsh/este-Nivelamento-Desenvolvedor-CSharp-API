using Newtonsoft.Json;

namespace Questao2
{
    public sealed class Result
    {
        public string Page { get; set; }
        public string PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty("Total_pages")]
        public int TotalPage { get; set; }
        public Team[] Data { get; set; }
    }
}