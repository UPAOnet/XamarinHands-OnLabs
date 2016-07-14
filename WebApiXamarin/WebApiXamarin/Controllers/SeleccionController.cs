using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiXamarin.Models;

namespace WebApiXamarin.Controllers
{
    public class SeleccionController : ApiController
    {
        // GET: Seleccion
        BDEventoXamarinEntities bd = new BDEventoXamarinEntities();  // Instanciamos la base de datos

        //Creamos un controlador del Tipo GET con el nombre GetJugador y el parámetro ID
        public JugadorModel GetJugador(int id)
        {
            // Realizamos la consulta a nuestra BD de la tabla Jugador

            JugadorModel jugador = (from J in bd.Jugador
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
                                    }).FirstOrDefault();

            return jugador;

        }

        //Creamos un controlador del Tipo GET con el nombre GetJugadores

        public EquipoModel GetJugadores()
        {

            // Realizamos la consulta a nuestra BD de la tabla Equipo
            EquipoModel equipo = (from E in bd.Equipo
                                  select new EquipoModel
                                  {
                                      //Almacenamos la informacion de nuestra consulta a nuestro modelo EquipoModel
                                      IDEquipo = E.equipo_id,
                                      Nombre = E.equipo_nombre,
                                      Copas = E.equipo_copas,
                                      Entrenador = E.equipo_entrenador,
                                      Estadio = E.equipo_estadio,
                                      Fundacion = E.equipo_fundacion,
                                      Jugadores = (from J in bd.Jugador //Almacenamos la informacion de nuestra consulta a nuestro modelo JugadorModel
                                                   select new JugadorModel
                                                   {
                                                       IDJugador = J.jugador_id,
                                                       Nombre = J.jugador_nombre,
                                                       Foto = J.jugador_foto,
                                                       NumeroJugador = J.jugador_numero,
                                                       Posicion = J.jugador_posicion,
                                                       EquipoJugador = J.jugador_equipo
                                                   }).ToList()

                                  }).FirstOrDefault();

            return equipo;


        }
    }
}