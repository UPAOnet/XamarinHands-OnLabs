using Newtonsoft.Json;

namespace AppFPF.Models
{
    public class Player
    {
        [JsonProperty("IDJugador")]
        public int ID { get; set; }

        [JsonProperty("Nombre")]
        public string Name { get; set; }

        [JsonProperty("Foto")]
        public string Photo { get; set; }

        [JsonProperty("NumeroCamiseta")]
        public int Number { get; set; }

        [JsonProperty("Posicion")]
        public string Position { get; set; }

        [JsonProperty("EquipoJugador")]
        public string Team { get; set; }
    }
}