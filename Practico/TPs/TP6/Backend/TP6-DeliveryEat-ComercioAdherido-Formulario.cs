using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP6_Historia_PedidoComercioAdherido.RepoHard;

namespace TP6_Historia_PedidoComercioAdherido.Models
{
    public class Formulario
    {
        public string calleDireccion { get; set; } //Nombre de la calle de la direccion pasada
        public int? alturaDireccion { get; set; } //Numero de altura de la direccion pasada
        public Ciudad ciudadDireccion { get; set; } //Ciudad seleccionada de la direccion pasada
        public string referenciaDireccion { get; set; } //Referencia opcional de direccion
        public List<Producto> productosPedidos { get; set; } //Lista de los productos incluidos en el pedido
        public string formaPagoPedido { get; set; } //Forma de pago que puede ser: "Efectivo" o "TarjetaCredito"
        public float costoTotalPedido { get; set; } //Costo total del pedido, suma de los precios unitarios de los productos por la cantidad de cada uno
        public float? montoAPagarPedido { get; set; } //En caso de seleccionar forma de pago "Efectivo", cuanto va a pagar en efectivo para calculo de vuelto
        public string fechaRecepcionPedido { get; set; } //Cuando desea recibir el pedido, vacio para "lo antes posible", si tiene valor se espera formato: "dd/MM/yyyy HH:mm:ss"
        public ulong? numeroTarjeta { get; set; } //En caso de seleccionar "TarjetaCredito" se debe el numero de la tarjeta de credito
        public string nombreTitularTarjeta { get; set; } //En caso de seleccionar "TarjetaCredito" se debe el nombre del titular de la tarjeta de credito
        public string apellidoTitularTarjeta { get; set; } //En caso de seleccionar "TarjetaCredito" se debe el apellido del titular de la tarjeta de credito
        public string fechaVencimientoTarjeta { get; set; } //En caso de seleccionar "TarjetaCredito" se debe la fecha de vencimiento de la tarjeta de credito con el formato: MM/AAAA
        public int? cvcTarjeta { get; set; } //En caso de seleccionar "TarjetaCredito" se debe CVC de la tarjeta de credito, numeros de atras

        public bool verificarValores()
        {
            if (this.calleDireccion == "")
                throw new ApplicationException("No se ingreso el nombre de la calle");
            if (this.alturaDireccion == null)
                throw new ApplicationException("No se ingreso la altura de la calle");
            if (!this.ciudadDireccion.esCiudadValida())
                throw new ApplicationException("No se selecciono correctamente la ciudad");
            if (!(this.formaPagoPedido == "Efectivo" || this.formaPagoPedido == "TarjetaCredito"))
                throw new ApplicationException("No se selecciono correcamente la forma de pago");
            if (this.formaPagoPedido == "Efectivo")
                if (this.montoAPagarPedido == null)
                    throw new ApplicationException("No se ingreso el monto a pagar con la opcion de efectivo");
            if(this.formaPagoPedido == "TarjetaCredito")
            {
                //Se podrian hacer verificaciones de datos de tarjeta validos preguntando a los proveedores de TC quizas, pero aqui solo haremos la validacion de que sean ingresados
                if (this.numeroTarjeta == null || (this.numeroTarjeta.ToString().Length < 14 || this.numeroTarjeta.ToString().Length > 20))
                    throw new ApplicationException("No se ingreso un numero de tarjeta valido");
                if (this.nombreTitularTarjeta == "")
                    throw new ApplicationException("No se ingreso el nombre del titular de la tarjeta");
                if (this.apellidoTitularTarjeta == "")
                    throw new ApplicationException("No se ingreso el apellido del titular de la tarjeta");
                if (this.fechaVencimientoTarjeta == "")
                    throw new ApplicationException("No se ingreso la fecha de vencimiento de la tarjeta");
                if (this.cvcTarjeta == null)
                    throw new ApplicationException("No se ingreso un numero de CVC de la tarjeta valido");
            }
            if (this.fechaRecepcionPedido != "")
                if (Convert.ToDateTime(this.fechaRecepcionPedido) < DateTime.Now.Date)
                    throw new ApplicationException("No se ingreso una fecha de recepcion valida");
            if (this.productosPedidos == null || this.productosPedidos.Count == 0)
                throw new ApplicationException("El carrito esta vacio, no se selecciono ningun producto");
            return true;
        }
        public Pedido construirPedido()
        {
            Pedido nuevoPedido = new Pedido();
            string direc = this.calleDireccion + "-" + this.alturaDireccion.ToString() + "," + this.ciudadDireccion.nombre;
            nuevoPedido.direccion = direc;
            nuevoPedido.referencia = this.referenciaDireccion;
            nuevoPedido.formaPago = this.formaPagoPedido;
            if (this.formaPagoPedido == "Efectivo")
                nuevoPedido.cantidadAPagar = this.montoAPagarPedido;
            if (this.fechaRecepcionPedido != "")
                nuevoPedido.tiempoRecepcion = Convert.ToDateTime(this.fechaRecepcionPedido);
            nuevoPedido.costoTotal = this.costoTotalPedido;
            nuevoPedido.productosPedidos = this.productosPedidos;
            guardarPedido(nuevoPedido);
            return nuevoPedido;
        }
        private void guardarPedido(Pedido pedido) { ObjetosHardcodeados.getInstancia().guardarPedido(pedido); }
    }
}