using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP6_Historia_PedidoComercioAdherido.Models;

namespace TP6_Historia_PedidoComercioAdherido.Controllers
{
    public class CiudadesController : ApiController
    {
        [Route("ciudades/consulta")]
        [HttpGet]
        public IHttpActionResult obtenerCiudades() //Aqui se procesa la peticion de obtener las ciudades
        {
            try
            {
                List<Ciudad> ciudadesRespuesta = Ciudad.obtenerCiudades();
                return Ok(ciudadesRespuesta); //Se devuelve una respuesta con codigo 200 (OK) y con la lista de ciudades en el cuerpo en formato JSON/el solicitado
            }
            catch (ApplicationException aex)
            {
                return NotFound(); //En caso de suceder algun problema previsto devuelve una respuesta con codigo 404 (Not Found)
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //En caso de suceder algun problema no previsto devuelve una respuesta con codigo 500 (Error interno del servidor) con el problema sucedido en el cuerpo
            }

        }
    }
}
