using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFPF.Models
{
    public class Equipo
    {
        public int IDEquipo { get; set; }
        public string Nombre { get; set; }
        public string Fundacion { get; set; }
        public string Entrenador { get; set; }
        public string Estadio { get; set; }
        public int Copas { get; set; }
        [JsonProperty("JugadorModel")]
        public List<Jugador> ListaJugadores { get; set; }
    }
}
