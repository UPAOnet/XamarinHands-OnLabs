using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiXamarin.Models
{
    public class JugadorModel
    {
        public int IDJugador { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public Nullable<int> NumeroJugador { get; set; }
        public string Posicion { get; set; }
        public string EquipoJugador { get; set; }

    }
}