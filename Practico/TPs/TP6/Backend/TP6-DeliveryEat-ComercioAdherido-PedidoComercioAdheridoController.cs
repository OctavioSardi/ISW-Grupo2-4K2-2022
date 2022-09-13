using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP6_Historia_PedidoComercioAdherido.Models;

namespace TP6_Historia_PedidoComercioAdherido.Controllers
{
    public class PedidoComercioAdheridoController : ApiController
    {
        [Route("pedidoAdherido/verificar")]
        [HttpPost]
        public IHttpActionResult procesarPedido([FromBody]Formulario formu) //Aqui se procesa la peticion de confirmar/verificar el pedido y guardarlo en BD
        {   //Se recibe en el cuerpo del HttpRequest un formulario en formato JSON
            try
            {
                Formulario formulario = formu;
                formulario.verificarValores(); //Se verifica si los valores del formulario son correctos
                Pedido pedido = formulario.construirPedido(); //Se guardan los valores del formulario en un pedido
                return Ok(pedido); //Se devuelve una respuesta con codigo 200 (OK) si no hay fallos en los datos, y con el pedido generado en el cuerpo en formato JSON/el solicitado
            }
            catch (ApplicationException aex) //En caso de que algun valor sea invalido
            {
                return BadRequest(aex.Message); //Se devuelve una respuesta con codigo 400 (BadRequest) y con el mensaje de cual fue el error
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //En caso de suceder algun problema no previsto devuelve una respuesta con codigo 500 (Error interno del servidor) con el problema sucedido en el cuerpo
            }

        }
    }
}
