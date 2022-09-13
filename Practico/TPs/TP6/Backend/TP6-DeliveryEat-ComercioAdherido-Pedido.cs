using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Historia_PedidoComercioAdherido.Models
{
    public class Pedido
    {
        public long numeroPedido { get; set; } //Numero autoincremental generado en la BD
        public string direccion { get; set; } //Direccion completa en texto con el formato: <Calle>-<Altura>,<Ciudad>
        public string referencia { get; set; } //Referencia opcional de direccion
        public List<Producto> productosPedidos { get; set; } //Lista de los productos incluidos en el pedido
        public string formaPago { get; set; } //Forma de pago que puede ser: "Efectivo" o "TarjetaCredito"
        public float costoTotal { get; set; } //Costo total del pedido, suma de los precios unitarios de los productos por la cantidad de cada uno
        public float? cantidadAPagar { get; set; } //En caso de seleccionar forma de pago "Efectivo", cuanto va a pagar en efectivo para calculo de vuelto
        public DateTime? tiempoRecepcion { get; set; } //Cuando desea recibir el pedido, null para "lo antes posible", si tiene valor se guarda esa fecha/hora

    }
}