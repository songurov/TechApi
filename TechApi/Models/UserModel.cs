using Newtonsoft.Json;

namespace TechApi.Models
{
    public class UserModelSearch
    {
        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("cognome")]
        public string Lastname { get; set; }

        [JsonProperty("posizione")]
        public string Position { get; set; }

        [JsonProperty("societa")]
        public string Society { get; set; }

        [JsonProperty("solution")]
        public string Solution { get; set; }

        [JsonProperty("citta")]
        public string City { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }
    }

    public class UserModelContact : UserModelSearch
    {
        [JsonProperty("indirizzo")]
        public string Address { get; set; }

        [JsonProperty("cap")]
        public string cap { get; set; }

        [JsonProperty("dipartimento")]
        public string dipartimento { get; set; }

        [JsonProperty("stanza")]
        public string stanza { get; set; }

        [JsonProperty("telefono")]
        public string Phone { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("mobilepubblico")]
        public string mobilepubblico { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("interno")]
        public string interno { get; set; }

        [JsonProperty("segretaria")]
        public string segretaria { get; set; }

        [JsonProperty("attributo1")]
        public string attributo1 { get; set; }
    }
}