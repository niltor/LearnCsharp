using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Linq示例
{
    public partial class Province
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("city")]
        public List<City> City { get; set; }
    }

    public partial class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("area")]
        public string[] Area { get; set; }
    }
}
