using System.Text.Json.Serialization;

namespace DataAccessLibrary
{
    public class Charts
    {
        [JsonPropertyName("1month")]
        public OneMonth[] OneMonth { get; set; }
    }
            

}


