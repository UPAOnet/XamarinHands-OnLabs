using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppFPF.Models
{
    public class Team
    {
        [JsonProperty("IDEquipo")]
        public int ID { get; set; } = 0;

        [JsonProperty("Nombre")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("Fundacion")]
        public string FoundingDate { get; set; } = string.Empty;

        [JsonProperty("Entrenador")]
        public string Trainer { get; set; } = string.Empty;

        [JsonProperty("Estadio")]
        public string Stadium { get; set; } = string.Empty;

        [JsonProperty("Copas")]
        public int CupsCount { get; set; } = 0;

        [JsonProperty("JugadorModel")]
        public List<Player> PlayersList { get; set; } = new List<Player>();
    }
}