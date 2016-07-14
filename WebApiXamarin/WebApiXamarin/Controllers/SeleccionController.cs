using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiXamarin.Models;

namespace WebApiXamarin.Controllers
{
    public class SeleccionController : ApiController
    {
        // GET: Seleccion
        BDEventoXamarinEntities bd = new BDEventoXamarinEntities();  // Instanciamos la base de datos

        //Creamos un controlador del Tipo GET con el nombre GetJugador y el parámetro ID
        public List<JugadorModel> GetJugador(int id)
        {
           // Realizamos la consulta a nuestra BD de la tabla Jugador

            var query = (from J in bd.Jugador.ToList()
                         where J.jugador_id == id
                         select new JugadorModel()
                         {
                             //Almacenamos la informacion de nuestra consulta a nuestro modelo JugadorModel
                             IDJugador = J.jugador_id,
                             Nombre = J.jugador_nombre,
                             Foto = J.jugador_foto,
                             NumeroJugador = J.jugador_numero,
                             Posicion = J.jugador_posicion,
                             EquipoJugador = J.jugador_equipo
                         });
            return query.ToList();

            // URL: http://localhost:{Puerto}/api/Seleccion/1 
        }

        //Creamos un controlador del Tipo GET con el nombre GetJugadores
        public List<EquipoModel> GetJugadores()
        {
            // Realizamos la consulta a nuestra BD de la tabla Equipo
            var query = (from E in bd.Equipo.ToList()
                         select new EquipoModel
                         {
                             //Almacenamos la informacion de nuestra consulta a nuestro modelo EquipoModel
                             IDEquipo = E.equipo_id,
                             Nombre = E.equipo_nombre,
                             Copas = E.equipo_copas,
                             Entrenador = E.equipo_entrenador,
                             Estadio = E.equipo_estadio,
                             Fundacion = E.equipo_fundacion,
                             JugadorModel = (from J in bd.Jugador.ToList() //Almacenamos la informacion de nuestra consulta a nuestro modelo JugadorModel
                                             select new JugadorModel
                                             {
                                                 IDJugador = J.jugador_id,
                                                 Nombre = J.jugador_nombre,
                                                 Foto = J.jugador_foto,
                                                 NumeroJugador = J.jugador_numero,
                                                 Posicion = J.jugador_posicion,
                                                 EquipoJugador = J.jugador_equipo
                                             }).ToList()                        
              
                        }).ToList();

            return query.ToList();

            // URL: http://localhost:{Puerto}/Api/Seleccion
        }
    }
}