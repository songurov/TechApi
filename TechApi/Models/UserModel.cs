using Newtonsoft.Json;

namespace TechApi.Models
{
    public class UserModelSearch
    {
        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("cognome")]
        public string cognome { get; set; }

        [JsonProperty("posizione")]
        public string posizione { get; set; }

        [JsonProperty("societa")]
        public string societa { get; set; }

        [JsonProperty("solution")]
        public string solution { get; set; }

        [JsonProperty("citta")]
        public string citta { get; set; }

        [JsonProperty("mail")]
        public string mail { get; set; }
    }

    public class UserModelContact
    {
        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("cognome")]
        public string cognome { get; set; }

        [JsonProperty("posizione")]
        public string posizione { get; set; }

        [JsonProperty("societa")]
        public string societa { get; set; }

        [JsonProperty("solution")]
        public string solution { get; set; }

        [JsonProperty("indirizzo")]
        public string indirizzo { get; set; }

        [JsonProperty("citta")]
        public string citta { get; set; }

        [JsonProperty("cap")]
        public string cap { get; set; }

        [JsonProperty("dipartimento")]
        public string dipartimento { get; set; }

        [JsonProperty("stanza")]
        public string stanza { get; set; }

        [JsonProperty("mail")]
        public string mail { get; set; }

        [JsonProperty("telefono")]
        public string telefono { get; set; }

        [JsonProperty("mobile")]
        public string mobile { get; set; }

        [JsonProperty("mobilepubblico")]
        public string mobilepubblico { get; set; }

        [JsonProperty("fax")]
        public string fax { get; set; }

        [JsonProperty("interno")]
        public string interno { get; set; }

        [JsonProperty("segretaria")]
        public string segretaria { get; set; }

        [JsonProperty("attributo1")]
        public string attributo1 { get; set; }
    }
}